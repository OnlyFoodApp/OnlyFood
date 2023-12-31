﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Accounts.Commands.DeleteAccount
{
    public class AccountDeletedEvent : BaseEvent
    {
        public Account Account { get; }

        public AccountDeletedEvent(Account account)
        {
            Account = account;
        }
    }
}
