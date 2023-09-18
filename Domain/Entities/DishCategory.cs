using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class DishCategory : BaseAuditableEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Image { get; set;}
        public bool isActived { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    }
}
