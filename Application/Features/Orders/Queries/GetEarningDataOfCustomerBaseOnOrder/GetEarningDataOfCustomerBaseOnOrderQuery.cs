using Application.Features.Accounts.Queries.GetAccountWithEmailAndPassword;
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
using Application.Features.Accounts.Queries.GetAccountById;
using Application.Features.Orders.Queries.GetAllOrders;

namespace Application.Features.Orders.Queries.GetEarningDataOfCustomerBaseOnOrder
{
    public record GetEarningDataOfCustomerBaseOnOrderQuery : IRequest<Result<GetEarningDataOfCustomerBaseOnOrderDto>>;

    internal class GetEarningDataOfCustomerBaseOnOrderQueryHandler : IRequestHandler<GetEarningDataOfCustomerBaseOnOrderQuery, Result<GetEarningDataOfCustomerBaseOnOrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetEarningDataOfCustomerBaseOnOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetEarningDataOfCustomerBaseOnOrderDto>> Handle(GetEarningDataOfCustomerBaseOnOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Repository<Order>().Entities.Where(o => o.Status == 2)
                .ProjectTo<GetAllOrdersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            double sum = 0;

            foreach (var order in orders)
            {
                sum += order.TotalAmount;
            }

            GetEarningDataOfCustomerBaseOnOrderDto earningData = new GetEarningDataOfCustomerBaseOnOrderDto();
            earningData.TotalAmount = (float)sum;
            earningData.Title = "Customer";

            return await Result<GetEarningDataOfCustomerBaseOnOrderDto>.SuccessAsync(earningData);
        }
    }
}
