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

namespace Application.Features.Comments.Commands
{
    public record CreateCommentCommand : IRequest<Result<Guid>>, IMapFrom<Comment>
    {
        public Guid AccountId { get; set; }
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public int? DisplayIndex { get; set; }
        public Guid? ParentCommentId { get; set; } = Guid.Empty;
        public virtual Comment ParentComment { get; set; }
        public virtual Post Post { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Comment>? ChildComments { get; set; }
        public byte IsDeleted { get; set; }

        public byte ISEdited { get; set; }

    }


    internal class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            var comment = new Comment()
            {
                AccountId = command.AccountId,
                PostId = command.PostId,
                Text = command.Text,
                DisplayIndex = command.DisplayIndex,
                ParentCommentId = command.ParentCommentId,
                ParentComment = command.ParentComment,
                Post = command.Post,
                Account = command.Account,
                ChildComments = command.ChildComments,
                IsDeleted = command.IsDeleted,
                ISEdited = command.ISEdited,

            };

            await _unitOfWork.Repository<Comment>().AddAsync(comment);
            comment.AddDomainEvent(new CommentCreateEvent(comment));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(comment.Id, $"Comment: {comment.Id} Created.");
        }


    }
}
