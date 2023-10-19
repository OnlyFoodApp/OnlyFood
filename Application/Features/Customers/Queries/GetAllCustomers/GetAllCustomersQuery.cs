using Application.Features.Chefs.Queries.GetAllChefs;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Accounts.Queries.GetAllAccounts;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public record GetAllCustomersQuery : IRequest<Result<List<GetAllCustomersDto>>>;

    internal class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, Result<List<GetAllCustomersDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCustomersDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.Repository<Customer>().Entities
                .ProjectTo<GetAllCustomersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var accounts = await _unitOfWork.Repository<Account>().Entities
                .ProjectTo<GetAllAccountsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var account in accounts)
            {
                foreach (var customer in customers)
                {
                    if (customer.Account.Id.Equals(account.Id))
                    {
                        customer.Account.Username = account.Username;
                        customer.Account.Password = account.Password;
                        customer.Account.Email = account.Email;
                        customer.Account.FirstName = account.FirstName;
                        customer.Account.LastName = account.LastName;
                        customer.Account.PhoneNumber = account.PhoneNumber;
                        customer.Account.DateOfBirth = account.DateOfBirth;
                        customer.Account.Gender = account.Gender;
                        customer.Account.ProfilePicture = account.ProfilePicture;
                        customer.Account.Bio = account.Bio;
                        customer.Account.Roles = account.Roles;
                    }
                }
            }

            return await Result<List<GetAllCustomersDto>>.SuccessAsync(customers);
        }
    }
}
