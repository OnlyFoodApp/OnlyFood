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
            var accounts = await _unitOfWork.Repository<Customer>().Entities
                .ProjectTo<GetAllCustomersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllCustomersDto>>.SuccessAsync(accounts);
        }
    }
}
