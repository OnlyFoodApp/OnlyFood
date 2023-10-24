using Application.Common.Mappings;
using Application.Features.Dishs.Commands;
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

namespace Application.Features.Likes.Commands
{
  
    public record CreateLikeCommand : IRequest<Result<Guid>>, IMapFrom<Like>
    {
        public Guid PostId { get; set; }

        public Guid AccountId { get; set; }

    }


    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateLikeCommand command, CancellationToken cancellationToken)
        {
            var like = new Like()
            {
                PostId = command.PostId,
                AccountId = command.AccountId

            };

            await _unitOfWork.Repository<Like>().AddAsync(like);
            like.AddDomainEvent(new LikeCreateEvent(like));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(like.Id, $"Like: {like.Id} Created.");
        }


    }
}
