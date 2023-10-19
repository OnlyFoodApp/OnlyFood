
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Shared;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Payments.Queries.GetAllPayments
{
    public record GetAllPaymentsQuery : IRequest<Result<List<GetAllPaymentsDto>>>;

    internal class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, Result<List<GetAllPaymentsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetAllPaymentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllPaymentsDto>>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _unitOfWork.Repository<Payment>().Entities
                .ProjectTo<GetAllPaymentsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllPaymentsDto>>.SuccessAsync(payments);
        }
    }
}
