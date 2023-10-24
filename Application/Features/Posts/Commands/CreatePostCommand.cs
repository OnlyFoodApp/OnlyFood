using Application.Common.Mappings;
using Application.Features.Certifications.Commands;
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

namespace Application.Features.Posts.Commands
{
    public record CreatePostCommand : IRequest<Result<Guid>>, IMapFrom<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AccountID { get; set; }
        public int DisplayIndex { get; set; }
        public string MediaURLs { get; set; }
        public byte IsDeleted { get; set; }
        public byte IsEdited { get; set; }

    }


    internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {
            var post = new Post()
            {
                Title = command.Title,
                Content = command.Content,
                AccountID = command.AccountID,
                DisplayIndex = command.DisplayIndex,
                MediaURLs = command.MediaURLs,
                IsDeleted = command.IsDeleted,
                IsEdited = command.IsEdited,

            };

            await _unitOfWork.Repository<Post>().AddAsync(post);
            post.AddDomainEvent(new PostCreateEvent(post));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(post.Id, $"Post: {post.Id} Created.");
        }


    }
}
