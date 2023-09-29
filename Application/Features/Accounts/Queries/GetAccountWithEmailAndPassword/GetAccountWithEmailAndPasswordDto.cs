using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Accounts.Queries.GetAccountWithEmailAndPassword
{
    public class GetAccountWithEmailAndPasswordDto : IMapFrom<Account>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
