using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DishCategorys.Commands
{

    public class DishCategoryCreateEvent : BaseEvent
    {
        public DishCategory DishCategory { get; }


        public DishCategoryCreateEvent(DishCategory dishCategory)
        {
            DishCategory = dishCategory;
        }
    }
}
