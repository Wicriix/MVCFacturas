using Microsoft.EntityFrameworkCore;
using MVCFacturas.ExternalConnections.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.ExternalConnections.GenericRepository.Specifications
{
    public class SpecificationsEvaluator<T> where T: EntityBase
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, Ispecification<T> specification)
        {
            var query = inputQuery;

            if(specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.Includes.Count > 0)
            {
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (specification.IsPaginEnable)
            {
                query = query
                    .Skip((specification.Skip == 1 ? 0 : (specification.Skip - 1)) * specification.Take)
                    .Take(specification.Take);
            }

            return query;
        }
    }
}
