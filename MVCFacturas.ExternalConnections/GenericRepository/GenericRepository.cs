using Microsoft.EntityFrameworkCore;
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
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly MVCFacturasContext mVCFacturasContext;
        public GenericRepository(MVCFacturasContext MVCFacturasContext)
        {
            mVCFacturasContext = MVCFacturasContext;
        }

        public async Task<T> AddAsync(T obj)
        {
            try
            {
                await mVCFacturasContext.Set<T>().AddAsync(obj);
                await mVCFacturasContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity)
        {
            try
            {
                await mVCFacturasContext.Set<T>().AddRangeAsync(entity.ToList());
                await mVCFacturasContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> DeleteAsync(T obj)
        {
            try
            {
                mVCFacturasContext.Remove(obj);
                await mVCFacturasContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entity)
        {
            try
            {
                mVCFacturasContext.RemoveRange(entity);
                await mVCFacturasContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await mVCFacturasContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById<Z>(Z id)
        {
            return await mVCFacturasContext.Set<T>().FindAsync(id);
        }


        public async Task<IEnumerable<TResult>> ListSelectAsync<TResult>(Ispecification<T> spec, Expression<Func<T, TResult>> selector)
        {
            return await AppliSpecification(spec).Select(selector).ToListAsync();
        }

        public async Task<T> UpdateAsync(T obj)
        {

            try
            {
                mVCFacturasContext.Update(obj);
                await mVCFacturasContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        private IQueryable<T> AppliSpecification(Ispecification<T> spec)
        {
            return SpecificationsEvaluator<T>.GetQuery(mVCFacturasContext.Set<T>().AsQueryable(), spec);
        }
    }
}
