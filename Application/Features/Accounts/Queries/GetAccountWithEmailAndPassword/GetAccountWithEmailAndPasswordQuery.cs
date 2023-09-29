using Application.Features.Accounts.Queries.GetAllAccounts;
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

namespace Application.Features.Accounts.Queries.GetAccountWithEmailAndPassword
{
    public record GetAccountWithEmailAndPasswordQuery : IRequest<Result<GetAccountWithEmailAndPasswordDto>>;
    internal class GetAccountWithEmailAndPasswordQueryHandler : IRequestHandler<GetAccountWithEmailAndPasswordQuery, Result<GetAccountWithEmailAndPasswordDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountWithEmailAndPasswordQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetAccountWithEmailAndPasswordDto>> Handle(GetAccountWithEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Repository<Account>().Entities
                .ProjectTo<GetAccountWithEmailAndPasswordDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return await Result<GetAccountWithEmailAndPasswordDto>.SuccessAsync(account);
        }
    }
}
