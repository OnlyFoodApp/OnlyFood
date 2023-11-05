using Domain.Common;
using Domain.Entities;


namespace Application.Features.Dishes.Commands.UpdateDishes
{ 
    public class DishesUpdatedEvent : BaseEvent
    {
        public Dish Dish { get; }


        public DishesUpdatedEvent(Dish dish)
        {
            Dish = dish;
        }
    }
}
