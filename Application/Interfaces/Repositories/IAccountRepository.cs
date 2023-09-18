using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountByCustomerIdAsync(Guid CustomerId);
    }
}
