using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class CustomerRepositoryWithNoBaseEntity : ICustomerRepository
    {
        private readonly IGenericRepositoryWithNoBaseEntity<Customer> _repository;

        public CustomerRepositoryWithNoBaseEntity(IGenericRepositoryWithNoBaseEntity<Customer> repository)
        {
            _repository = repository;
        }
    }
}
