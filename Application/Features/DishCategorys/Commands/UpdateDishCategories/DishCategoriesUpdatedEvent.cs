using Domain.Common;
using Domain.Entities;


namespace Application.Features.DishCategorys.Commands.UpdateDishCategorys
{ 
    public class DishCategoryUpdatedEvent : BaseEvent
    {
        public DishCategory DishCategory { get; }


        public DishCategoryUpdatedEvent(DishCategory dishCategory)
        {
            DishCategory = dishCategory;
        }
    }
}
