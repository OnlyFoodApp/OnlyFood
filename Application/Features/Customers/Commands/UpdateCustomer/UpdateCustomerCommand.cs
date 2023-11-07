using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Result<Guid>>, IMapFrom<Account>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string? PhoneNumber { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public int Roles { get; set; }
        public int RewardsPoints { get; set; }
        public string? Address { get; set; }

    }

    internal class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {


            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(command.Id);
            if (customer != null)
            {
                var account = await _unitOfWork.Repository<Account>().GetByIdAsync(customer.AccountId);
                if (account != null)
                {
                    account.Username = command.Username;
                    account.Password = command.Password;
                    account.FirstName = command.FirstName;
                    account.PhoneNumber = command.PhoneNumber;
                    account.Email = command.Email;
                    account.DateOfBirth = command.DateOfBirth;
                    account.Gender = command.Gender;
                    account.ActiveStatus = 0;
                    account.ModifiedBy = command.Id;
                    account.LastModifiedDate = DateTime.Now;

                    await _unitOfWork.Repository<Account>().UpdateAsync(account);
                    account.AddDomainEvent(new AccountUpdatedEvent(account));

                    customer.Address = command.Address;
                    customer.RewardsPoints = command.RewardsPoints;
                    await _unitOfWork.Repository<Customer>().UpdateAsync(customer);
                    customer.AddDomainEvent(new CustomerUpdatedEvent(customer));

                    await _unitOfWork.Save(cancellationToken);

                    return await Result<Guid>.SuccessAsync(account.Id, "Customer Updated.");
                }
                return await Result<Guid>.FailureAsync("Customer Not Found.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Customer Not Found.");
            }
        }
    }
}
