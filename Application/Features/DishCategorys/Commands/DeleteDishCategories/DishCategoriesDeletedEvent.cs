using Domain.Common;
using Domain.Entities;

namespace Application.Features.DishCategorys.Commands.DeleteDishCategorys
{
    public class DishCategoryDeletedEvent : BaseEvent
    {
        public DishCategory DishCategory { get; }

        public DishCategoryDeletedEvent(DishCategory dishCategory)
        {
            DishCategory = dishCategory;
        }
    }
}
