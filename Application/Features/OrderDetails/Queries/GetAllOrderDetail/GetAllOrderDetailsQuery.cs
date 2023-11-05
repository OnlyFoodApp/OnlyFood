using Application.Features.Accounts.Queries.GetAccountById;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Posts.Queries;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderDetails.Queries.GetAllOrderDetail
{
   
    public record GetAllOrderDetailsQuery : IRequest<Result<List<GetAllOrderDetailsDto>>>;

    internal class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQuery, Result<List<GetAllOrderDetailsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetAllOrderDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllOrderDetailsDto>>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
        {

            var orderDetails = await _unitOfWork.Repository<OrderDetail>().Entities
                .ProjectTo<GetAllOrderDetailsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllOrderDetailsDto>>.SuccessAsync(orderDetails);
        }


    }
}
