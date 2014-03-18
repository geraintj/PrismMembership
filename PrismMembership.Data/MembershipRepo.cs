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
    [Export(typeof(IMembershipRepo))]
    public class MembershipRepo : IMembershipRepo
    {
        private IObjectSet<Membership> _objectSet;

        public MembershipRepo()
        {
            _objectSet = new ObjectContext("name=Entities").CreateObjectSet<Membership>();
        }

        public IEnumerable<Membership> All()
        {
            return _objectSet.ToList();
        }

        public IEnumerable<Membership> Query(Expression<Func<Membership, bool>> predicate)
        {
            return _objectSet.Where(predicate).AsEnumerable();
        }

        public Membership Single(Expression<Func<Membership, bool>> predicate)
        {
            return _objectSet.Single(predicate);
        }
    }
}
