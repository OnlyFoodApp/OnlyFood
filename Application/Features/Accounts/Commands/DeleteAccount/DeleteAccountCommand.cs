using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        //public int Roles { get; set; }


    }

    internal class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Repository<Account>().GetByIdAsync(command.Id);
            if (account != null)
            {
                account.ActiveStatus = 0;
                account.ModifiedBy = command.Id;
                account.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Account>().UpdateAsync(account);
                account.AddDomainEvent(new AccountDeleteEvent(account));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(account.Id, "Account Deleted.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Account Not Found.");
            }
        }
    }
}
