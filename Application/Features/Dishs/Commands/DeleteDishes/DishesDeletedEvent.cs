using Domain.Common;
using Domain.Entities;

namespace Application.Features.Dishes.Commands.DeleteDishes
{
    public class DishesDeletedEvent : BaseEvent
    {
        public Dish Dish { get; }

        public DishesDeletedEvent(Dish dish)
        {
            Dish = dish;
        }
    }
}
