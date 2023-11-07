using Application.Features.Accounts.Queries.GetAllAccounts;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Queries.GetCustomerById
{
    public record GetCustomerByIdQuery(Guid id) : IRequest<Result<GetCustomerByIdDto>>;

    internal class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<GetCustomerByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCustomerByIdDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {

            var customer = await _unitOfWork.Repository<Customer>().Entities.Where(a => a.Id.Equals(request.id))
                .ProjectTo<GetCustomerByIdDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);


            return await Result<GetCustomerByIdDto>.SuccessAsync(customer);
        }
    }
}
