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
        public string Username { get; set; }
        public string Password { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set;}
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public int ActiveStatus { get; set; }
        public int Roles { get; set; }

        // Navigation Property
        public virtual Customer? Customer { get; set; }
        public virtual Chef? Chef { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
