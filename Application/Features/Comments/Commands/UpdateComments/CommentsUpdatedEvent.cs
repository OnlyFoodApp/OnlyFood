using Domain.Common;
using Domain.Entities;


namespace Application.Features.Comments.Commands.UpdateComments
{ 
    public class CommentUpdatedEvent : BaseEvent
    {
        public Comment Comment { get; }


        public CommentUpdatedEvent(Comment comment)
        {
            Comment = comment;
        }
    }
}
