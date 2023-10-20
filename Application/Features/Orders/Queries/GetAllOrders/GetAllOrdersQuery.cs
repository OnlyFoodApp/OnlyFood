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
using Application.Features.Accounts.Queries.GetAccountById;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public record GetAllOrdersQuery : IRequest<Result<List<GetAllOrdersDto>>>;

    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Result<List<GetAllOrdersDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllOrdersDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Repository<Order>().Entities
                .ProjectTo<GetAllOrdersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            foreach (var order in orders)
            {
                var customer = _unitOfWork.Repository<Customer>().Entities
                    .Where(a => a.Id.Equals(order.CustomerId)).ToList().FirstOrDefault();

                var account = await _unitOfWork.Repository<Account>().Entities.Where(a => a.Id.Equals(customer.AccountId))
                    .ProjectTo<GetAccountWithIdDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);
                if (account != null)
                {
                    order.CustomerName = account.FirstName + " " + account.LastName;
                }
            }

            return await Result<List<GetAllOrdersDto>>.SuccessAsync(orders);
        }
    }
}
