using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Commands
{
    

    public class LikeCreateEvent : BaseEvent
    {
        public Like Like { get; }


        public LikeCreateEvent(Like Like)
        {
            Like = Like;
        }
    }
}
