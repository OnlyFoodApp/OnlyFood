using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Commands.UpdateLike
{

    public class LikeUpdatedEvent : BaseEvent
    {
        public Like Like { get; }


        public LikeUpdatedEvent(Like Like)
        {
            Like = Like;
        }
    }
}
