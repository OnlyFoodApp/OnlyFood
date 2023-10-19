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
            var accounts = await _unitOfWork.Repository<Domain.Entities.Chef>().Entities
                .ProjectTo<GetAllChefsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllChefsDto>>.SuccessAsync(accounts);
        }
    }
}
