using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismMembership.Data
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> All();
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate);
    }
}
