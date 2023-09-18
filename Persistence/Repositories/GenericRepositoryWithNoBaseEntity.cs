﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class GenericRepositoryWithNoBaseEntity<T> : IGenericRepositoryWithNoBaseEntity<T> where T : BaseAuditableEntityWithoutId
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryWithNoBaseEntity(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        //public Task UpdateAsync(T entity)
        //{
        //    T exist = _dbContext.Set<T>().Find(entity.);
        //    _dbContext.Entry(exist).CurrentValues.SetValues(entity);
        //    return Task.CompletedTask;
        //}

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
