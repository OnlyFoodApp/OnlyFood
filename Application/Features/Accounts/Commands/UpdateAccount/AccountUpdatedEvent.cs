
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Accounts.Commands.UpdateAccount
{
    public class AccountUpdatedEvent : BaseEvent
    {
        public Account Account { get; }

        public AccountUpdatedEvent(Account account)
        {
            Account = account;
        }
    }
}
