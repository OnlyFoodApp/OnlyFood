using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Shared;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        //public int Roles { get; set; }


    }

    internal class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Repository<Account>().GetByIdAsync(command.Id);
            if (account != null)
            {
                account.Username = command.Username;
                account.Username = command.Username;
                account.FirstName = command.FirstName;
                account.LastName = command.LastName;
                account.Email = command.Email;
                account.DateOfBirth = command.DateOfBirth;
                account.Gender = command.Gender;
                account.ModifiedBy = command.Id;
                account.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Account>().UpdateAsync(account);
                account.AddDomainEvent(new AccountDeleteEvent(account));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(account.Id, "Account Updated.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Account Not Found.");
            }
        }
    }
}
