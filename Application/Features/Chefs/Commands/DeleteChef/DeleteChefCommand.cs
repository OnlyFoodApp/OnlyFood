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

namespace Application.Features.Chefs.Commands.DeleteChef
{
    public class DeleteChefCommand : IRequest<Result<Guid>>, IMapFrom<Account>
    {
        public Guid Id { get; set; }

    }

    internal class DeleteChefCommandHandler : IRequestHandler<DeleteChefCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteChefCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteChefCommand command, CancellationToken cancellationToken)
        {


            var chef = await _unitOfWork.Repository<Domain.Entities.Chef>().GetByIdAsync(command.Id);
            if (chef != null)
            {
                var account = await _unitOfWork.Repository<Account>().GetByIdAsync(chef.AccountId);
                if (account != null)
                {
                    account.ActiveStatus = 0;
                    account.ModifiedBy = command.Id;
                    account.LastModifiedDate = DateTime.Now;
                    await _unitOfWork.Repository<Account>().UpdateAsync(account);
                    account.AddDomainEvent(new AccountDeletedEvent(account));

                    await _unitOfWork.Save(cancellationToken);

                    return await Result<Guid>.SuccessAsync(account.Id, "Account Deleted.");
                }
                return await Result<Guid>.FailureAsync("Account Not Found.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Account Not Found.");
            }
        }
    }
}
