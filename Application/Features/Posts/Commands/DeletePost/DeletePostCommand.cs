using Application.Features.Posts.Commands.UpdatePost;
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

namespace Application.Features.Posts.Commands.DeletePost
{
   

    public class DeletePostCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        


    }

    internal class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeletePostCommand command, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdAsync(command.Id);
            if (post != null)
            {
                post.IsDeleted = 1;
                post.ModifiedBy = command.Id;
                post.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Post>().UpdateAsync(post);
                post.AddDomainEvent(new PostUpdatedEvent(post));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(post.Id, "Post Deleted.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Post Not Found.");
            }
        }
    }
}
