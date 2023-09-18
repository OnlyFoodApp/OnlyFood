using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Dish : BaseAuditableEntity   
    {
        [Required]
        public string DishName { get; set; }
        [Required]
        [ForeignKey("Menu")]
        public Guid MenuId { get; set; }
        [Required]
        [ForeignKey("DishCategory")]
        public Guid DishCategoryId { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public string? DishImage { get; set; }
        public string? DishIngredients { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual DishCategory DishCategory { get; set; }
        public virtual Menu Menu { get; set; }

    }
}
