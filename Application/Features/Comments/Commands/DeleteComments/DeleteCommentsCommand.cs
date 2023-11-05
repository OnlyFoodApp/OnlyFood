using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Shared;


namespace Application.Features.Comments.Commands.DeleteComments
{
    public class DeleteCommentCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        //public int Roles { get; set; }


    }

    internal class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.Repository<Comment>().GetByIdAsync(command.Id);
            if (comment != null)
            {
                comment.IsDeleted = 1;
                comment.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Comment>().UpdateAsync(comment);
                comment.AddDomainEvent(new CommentDeletedEvent(comment));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(comment.Id, "Comment Deleted.");
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
