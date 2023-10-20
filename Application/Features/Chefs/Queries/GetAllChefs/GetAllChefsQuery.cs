using Application.Features.Accounts.Queries.GetAllAccounts;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Chefs.Queries.GetAllChefs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Chefs.Queries.GetAllChefs
{
    public record GetAllChefsQuery : IRequest<Result<List<GetAllChefsDto>>>;

    internal class GetAllChefsQueryHandler : IRequestHandler<GetAllChefsQuery, Result<List<GetAllChefsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetAllChefsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllChefsDto>>> Handle(GetAllChefsQuery request, CancellationToken cancellationToken)
        {
            var chefs = await _unitOfWork.Repository<Domain.Entities.Chef>().Entities
                .ProjectTo<GetAllChefsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var accounts = await _unitOfWork.Repository<Account>().Entities
                .ProjectTo<GetAllAccountsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var account in accounts)
            {
                foreach (var chef in chefs)
                {
                    if (chef.Account.Id.Equals(account.Id))
                    {
                        chef.Account.Username = account.Username;
                        chef.Account.Password = account.Password;
                        chef.Account.Email = account.Email;
                        chef.Account.FirstName = account.FirstName;
                        chef.Account.LastName = account.LastName;
                        chef.Account.PhoneNumber = account.PhoneNumber;
                        chef.Account.DateOfBirth = account.DateOfBirth;
                        chef.Account.Gender = account.Gender;
                        chef.Account.ProfilePicture = account.ProfilePicture;
                        chef.Account.Bio = account.Bio;
                        chef.Account.Roles = account.Roles;
                    }
                }
            }
            return await Result<List<GetAllChefsDto>>.SuccessAsync(chefs);
        }
    }
}
