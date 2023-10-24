using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dishs.Queries
{
    public class GetAllDishsDto : IMapFrom<Dish>
    {
        public string DishName { get; set; }
        public Guid MenuId { get; set; }
        public Guid DishCategoryId { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public byte IsDeleted { get; set; }
        public string? DishImage { get; set; }
        public string? DishIngredients { get; set; }

    }
}
