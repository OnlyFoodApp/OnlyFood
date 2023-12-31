﻿
using Application.Common.Mappings;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;

namespace Application.Features.Accounts.Commands.CreateAccount
{
    public record CreateAccountCommand : IRequest<Result<Guid>>, IMapFrom<Account>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public int Roles { get; set; }

    }

    internal class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            var account = new Account()
            {
                Username = command.Username,
                Password = command.Password,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
                Gender = command.Gender,
                Email = command.Email,
                Roles = command.Roles,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            await _unitOfWork.Repository<Account>().AddAsync(account);
            account.AddDomainEvent(new AccountCreatedEvent(account));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(account.Id, "Account Created.");
        }
    }
}
