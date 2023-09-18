using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IGenericRepository<Account> _repository;

        public AccountRepository(IGenericRepository<Account> repository)
        {
            _repository = repository;
        }
        public async Task<List<Account>> GetAccountByCustomerIdAsync(Guid CustomerId)
        {
            return await _repository.Entities.Where(x => x.Customer.AccountId == CustomerId).ToListAsync();
        }
    }
}
