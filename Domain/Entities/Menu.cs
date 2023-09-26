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
    public class Menu : Campaign
    {
        public byte IsDeleted { get; set; }
        public byte IsEdited { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    }
}
