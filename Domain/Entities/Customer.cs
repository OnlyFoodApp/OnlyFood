using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{   
    public class Customer : Account
    {
        public string? Address { get; set; }
        public int RewardsPoints { get; set; }

        // Navigation Property
        public Account Account { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
