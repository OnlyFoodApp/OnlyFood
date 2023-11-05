using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands.UpdatePost
{

    public class PostUpdatedEvent : BaseEvent
    {
        public Post Post { get; }


        public PostUpdatedEvent(Post post)
        {
            Post = post;
        }
    }
}
