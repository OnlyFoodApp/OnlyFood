using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepositoryWithNoBaseEntity<T> where T : class
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        //Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
