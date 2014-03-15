using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrismMembership.Data
{
    [Export]
    public class Repo<T> : IRepo<T> where T : class
    {
        private IObjectSet<T> _objectSet;

        public Repo()
        {
            _objectSet = new ObjectContext("name=MembershipEntities").CreateObjectSet<T>();
        }

        public IEnumerable<T> All()
        {
            return _objectSet.ToList();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where(predicate).AsEnumerable();
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Single(predicate);
        }
    }
}
