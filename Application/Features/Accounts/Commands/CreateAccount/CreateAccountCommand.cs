using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared;

namespace Application.Features.Accounts.Commands.CreateAccount
{
    public record CreateAccountCommand : IRequest<Result<Guid>>, IMapFrom<Customer>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public int Role { get; set; }

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
                Roles = command.Role
            };

            await _unitOfWork.Repository<Account>().AddAsync(account);
            account.AddDomainEvent(new AccountCreatedEvent(account));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(account.Id, "Account Created.");
        }
    }
}
