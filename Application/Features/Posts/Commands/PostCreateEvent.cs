using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands
{
    public class PostCreateEvent : BaseEvent
    {
        public Post Post { get; }


        public PostCreateEvent(Post Post)
        {
            Post = Post;
        }
    }
}
