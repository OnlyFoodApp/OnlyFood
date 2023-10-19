using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Accounts.Commands.CreateAccount;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Shared;
using Application.Common.Mappings;

namespace Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Result<Guid>>, IMapFrom<Account>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string? PhoneNumber { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public int Roles { get; set; }
        public string Address { get; set; }
        public int RewardsPoints { get; set; }
    }

    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {


            var account = new Account()
            {
                Username = command.Username,
                Password = command.Password,
                FirstName = command.FirstName,
                LastName = command.LastName,
                PhoneNumber = command.PhoneNumber,
                DateOfBirth = command.DateOfBirth,
                Gender = command.Gender,
                Email = command.Email,
                Roles = command.Roles,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Customer = new Customer()
                {
                    Address = command.Address,
                    RewardsPoints = command.RewardsPoints,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                }
            };



            await _unitOfWork.Repository<Account>().AddAsync(account);
            account.AddDomainEvent(new AccountCreatedEvent(account));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(account.Id, "Customer Created.");
        }
    }
}
