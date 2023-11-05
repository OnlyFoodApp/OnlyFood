using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Commands.DeleteLike
{
    public class LikeDeletedEvent : BaseEvent
    {
        public Like Like { get; }


        public LikeDeletedEvent(Like Like)
        {
            Like = Like;
        }
    }


}
