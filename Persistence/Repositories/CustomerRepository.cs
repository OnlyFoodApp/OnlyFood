using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IGenericRepository<Customer> _repository;

        public CustomerRepository(IGenericRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task<List<Customer>> GetCustomerByAccountIdAsync(Guid accountId)
        {
            return await _repository.Entities.Where(x => x.Customer.Id == accountId).ToListAsync();
        }
    }
}
