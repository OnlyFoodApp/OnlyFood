using Domain.Common;
using Domain.Entities;

namespace Application.Features.Comments.Commands.DeleteComments
{
    public class CommentDeletedEvent : BaseEvent
    {
        public Comment Comment { get; }

        public CommentDeletedEvent(Comment comment)
        {
            Comment = comment;
        }
    }
}
