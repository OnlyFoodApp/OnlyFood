using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Commands.UpdateLike
{
    

    public class UpdateLikeCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }

        public Guid AccountId { get; set; }


    }

    internal class UpdateLikeCommandHandler : IRequestHandler<UpdateLikeCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateLikeCommand command, CancellationToken cancellationToken)
        {
            var like = await _unitOfWork.Repository<Like>().GetByIdAsync(command.Id);
            if (like != null)
            {
                like.PostId = command.PostId;
                like.AccountId = command.AccountId;
                like.ModifiedBy = command.Id;
                like.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Like>().UpdateAsync(like);
                /*like.AddDomainEvent(new LikeUpdatedEvent(like));*/

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(like.Id, "Like Updated.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Like Not Found.");
            }
        }
    }
}
