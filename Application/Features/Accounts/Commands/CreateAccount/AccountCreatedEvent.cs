using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Accounts.Commands.CreateAccount
{
    public class AccountCreatedEvent : BaseEvent
    {
        public Account Account { get;}


        public AccountCreatedEvent(Account account)
        {
            Account = account;
        }
    }
}
