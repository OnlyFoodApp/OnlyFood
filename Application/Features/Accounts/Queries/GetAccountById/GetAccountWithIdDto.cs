using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountWithIdDto : IMapFrom<Account>
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
    }
}
