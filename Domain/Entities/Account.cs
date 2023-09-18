using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Account : BaseAuditableEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public GenderEnum Gender { get; set;}
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public int ActiveStatus { get; set; }
        [Required]
        public int Roles { get; set; }

        // Navigation Property
        public virtual Customer Customer { get; set; }
        public virtual Chef Chef { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
