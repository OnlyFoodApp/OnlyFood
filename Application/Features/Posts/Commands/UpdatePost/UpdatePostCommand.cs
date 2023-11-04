using Application.Features.Payments.Commands.UpdatePayment;
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

namespace Application.Features.Posts.Commands.UpdatePost
{

    public class UpdatePostCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AccountID { get; set; }
        public int DisplayIndex { get; set; }
        public string MediaURLs { get; set; }
        public byte IsDeleted { get; set; }
        public byte IsEdited { get; set; }


    }

    internal class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdAsync(command.Id);
            if (post != null)
            {
                post.Title = command.Title;
                post.Content = command.Content;
                post.IsDeleted = command.IsDeleted;
                post.IsEdited = command.IsEdited;
                post.AccountID = command.AccountID;
                post.DisplayIndex = command.DisplayIndex;
                post.MediaURLs = command.MediaURLs;
                post.ModifiedBy = command.Id;
                post.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Post>().UpdateAsync(post);
                post.AddDomainEvent(new PostUpdatedEvent(post));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(post.Id, "Post Updated.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Post Not Found.");
            }
        }
    }
}
