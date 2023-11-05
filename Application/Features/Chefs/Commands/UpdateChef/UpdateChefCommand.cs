using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Application.Features.Accounts.Commands.CreateAccount;
using Application.Features.Accounts.Commands.DeleteAccount;
using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Features.Chef.Commands.UpdateChef;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;

namespace Application.Features.Chefs.Commands.UpdateChef
{
    public class UpdateChefCommand : IRequest<Result<Guid>>, IMapFrom<Account>
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
        public string Experience { get; set; }
        public string? Awards { get; set; }

    }

    internal class UpdateChefCommandHandler : IRequestHandler<UpdateChefCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateChefCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateChefCommand command, CancellationToken cancellationToken)
        {


            var chef = await _unitOfWork.Repository<Domain.Entities.Chef>().GetByIdAsync(command.Id);
            if (chef != null)
            {
                var account = await _unitOfWork.Repository<Account>().GetByIdAsync(chef.AccountId);
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

                    chef.Experience = command.Experience;
                    chef.Awards = command.Awards;
                    await _unitOfWork.Repository<Domain.Entities.Chef>().UpdateAsync(chef);
                    chef.AddDomainEvent(new ChefUpdatedEvent(chef));

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
