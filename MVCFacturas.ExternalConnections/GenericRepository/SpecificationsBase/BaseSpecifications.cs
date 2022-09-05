using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.ExternalConnections.GenericRepository.Specifications
{
    public abstract class BaseSpecifications<T> : Ispecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> Select { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginEnable { get; private set; }

        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected virtual void AddSelect(Expression<Func<T, object>> select)
        {
            Select = select;
        }
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPaginEnable = true;
        }

    }
}
