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
    public class ChefRepository : IChefRepository
    {
        private readonly IGenericRepository<Chef> _repository;

        public ChefRepository(IGenericRepository<Chef> repository)
        {
            _repository = repository;
        }

        public async Task<List<Chef>> GetAllChefAsync()
        {
            return await _repository.Entities.Where(x => x.Account.Roles == 1).ToListAsync();
        }
    }
}
