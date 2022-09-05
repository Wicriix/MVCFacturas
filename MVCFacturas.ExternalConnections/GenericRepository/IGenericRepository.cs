using MVCFacturas.ExternalConnections.DbContexts;
using MVCFacturas.ExternalConnections.GenericRepository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.ExternalConnections.GenericRepository
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<IEnumerable<TResult>> ListSelectAsync<TResult>(Ispecification<T> spec, Expression<Func<T, TResult>> selector);
        Task<T> GetById<Z>(Z id);
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<T> DeleteAsync(T obj);
        Task DeleteRangeAsync(IEnumerable<T> entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity);

    }
}
