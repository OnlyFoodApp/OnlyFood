using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands.DeletePost
{
    
    public class PostDeletedEvent : BaseEvent
    {
        public Post Post { get; }


        public PostDeletedEvent(Post post)
        {
            Post = post;
        }
    }
}
