using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Application.Features.Accounts.Commands.CreateAccount;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;

namespace Application.Features.Chef.Commands.CreateChef
{
    public class CreateChefCommand : IRequest<Result<Guid>>, IMapFrom<Account>
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
        public string Experience { get; set; }
        public string? Awards { get; set; }

    }

    internal class CreateChefCommandHandler : IRequestHandler<CreateChefCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateChefCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateChefCommand command, CancellationToken cancellationToken)
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
                Chef = new Domain.Entities.Chef()
                {
                    Awards = command.Awards,
                    Experience = command.Experience,
                }
            };

           

            await _unitOfWork.Repository<Account>().AddAsync(account);
            account.AddDomainEvent(new AccountCreatedEvent(account));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(account.Id, "Chef Created.");
        }
    }
}
