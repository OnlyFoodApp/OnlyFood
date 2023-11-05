using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Commands
{
    public class CommentCreateEvent : BaseEvent
    {
        public Comment Comment { get; }


        public CommentCreateEvent(Comment comment)
        {
            Comment = comment;
        }
    }
}
