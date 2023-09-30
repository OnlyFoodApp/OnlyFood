using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Chef.Querries.GetChefWithId
{
    public class GetChefWithIdDto : IMapFrom<Account>, IMapFrom<Domain.Entities.Chef>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Enum Gender { get; set; }
        public string ProfilePicture { get; set; }
        public string Bio { get; set; }
        public int Roles { get; set; }
        public string? Experience { get; set; } 
        public string? Awards { get; set; }
    }
}
