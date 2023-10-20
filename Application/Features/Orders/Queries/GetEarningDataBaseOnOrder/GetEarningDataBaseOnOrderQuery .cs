using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetEarningDataOfCustomerBaseOnOrder;
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

namespace Application.Features.Orders.Queries.GetEarningDataBaseOnOrder
{
    public record GetEarningDataBaseOnOrderQuery : IRequest<Result<GetEarningDataBaseOnOrderDto>>;

    internal class GetEarningDataBaseOnOrderQueryHandler : IRequestHandler<GetEarningDataBaseOnOrderQuery, Result<GetEarningDataBaseOnOrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetEarningDataBaseOnOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetEarningDataBaseOnOrderDto>> Handle(GetEarningDataBaseOnOrderQuery request, CancellationToken cancellationToken)
        {
            var ordersByCustomer = await _unitOfWork.Repository<Order>().Entities
                .ProjectTo<GetAllOrdersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            var ordersBySale = await _unitOfWork.Repository<Order>().Entities.Where(o => o.Status == 2)
                .ProjectTo<GetAllOrdersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            double sumCustomer = 0;
            double sumProduct = 0;
            double sumSale = 0;

            foreach (var order in ordersByCustomer)
            {
                sumCustomer += order.TotalAmount;
            }


            foreach (var order in ordersBySale)
            {
                sumSale += order.TotalAmount;
            }

            GetEarningDataBaseOnOrderDto earningData = new GetEarningDataBaseOnOrderDto();
            earningData.Customer.TotalAmount = (float)sumCustomer;
            earningData.Customer.Title = "Customers";

            earningData.Product.TotalAmount = (float)sumProduct;
            earningData.Product.Title = "Products";

            earningData.Sales.TotalAmount = (float)sumSale;
            earningData.Sales.Title = "Sales";

            return await Result<GetEarningDataBaseOnOrderDto>.SuccessAsync(earningData);
        }
    }
}
