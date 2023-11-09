using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DishCategorys.Queries
{
   
    public class GetAllDishCategoriesDto : IMapFrom<DishCategory>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public byte isActived { get; set; }

    }
}
