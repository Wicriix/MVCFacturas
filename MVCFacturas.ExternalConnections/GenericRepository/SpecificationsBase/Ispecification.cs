using MVCFacturas.ExternalConnections.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVCFacturas.ExternalConnections.GenericRepository.Specifications
{
    public interface Ispecification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }

        int Take { get; }
        int Skip { get; }
        bool IsPaginEnable { get; }

    }
}