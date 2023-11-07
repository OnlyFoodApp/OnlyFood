using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Application.Features.Accounts.Commands.DeleteAccount;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;

namespace Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Result<Guid>>, IMapFrom<Account>
    {
        public Guid Id { get; set; }

    }

    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {


            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(command.Id);
            if (customer != null)
            {
                var account = await _unitOfWork.Repository<Account>().GetByIdAsync(customer.AccountId);
                if (account != null)
                {
                    account.ActiveStatus = 0;
                    account.ModifiedBy = command.Id;
                    account.LastModifiedDate = DateTime.Now;
                    await _unitOfWork.Repository<Account>().UpdateAsync(account);
                    account.AddDomainEvent(new AccountDeletedEvent(account));

                    await _unitOfWork.Save(cancellationToken);

                    return await Result<Guid>.SuccessAsync(account.Id, "Customer Deleted.");
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
