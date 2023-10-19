
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Accounts.Commands.UpdateAccount
{
    public class AccountDeleteEvent : BaseEvent
    {
        public Account Account { get; }

        public AccountDeleteEvent(Account account)
        {
            Account = account;
        }
    }
}
