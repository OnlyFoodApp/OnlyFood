using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dishs.Commands
{
    public class DishCreateEvent : BaseEvent
    {
        public DishCategory DishCategory { get; }


        public DishCreateEvent(Dish Dish)
        {
            Dish = Dish;
        }
    }
}
