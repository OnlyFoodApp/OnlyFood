using Application.Features.Comments.Commands.UpdateComments;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Shared;


namespace Application.Features.Comments.Commands.UpdateComments
{
    public class UpdateCommentCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int? DisplayIndex { get; set; }
        //public int Roles { get; set; }


    }

    internal class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateCommentCommand command, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.Repository<Comment>().GetByIdAsync(command.Id);
            if (comment != null)
            {
                comment.Text = command.Text;
                comment.DisplayIndex = command.DisplayIndex;
                comment.LastModifiedDate = DateTime.Now;
                comment.ISEdited = 1;
                await _unitOfWork.Repository<Comment>().UpdateAsync(comment);
                comment.AddDomainEvent(new CommentUpdatedEvent(comment));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(comment.Id, "Comment Updated.");
            }
            else
            {
                await Result<Guid>.FailureAsync("Comment Not Found.");
                throw new NotFoundException();
            }
        }
    }
}
