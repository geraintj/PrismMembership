using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismMembership.Data
{
    public interface IMembershipRepo
    {
        IEnumerable<Membership> All();
        IEnumerable<Membership> Query(Expression<Func<Membership, bool>> predicate);
        Membership Single(Expression<Func<Membership, bool>> predicate);
    }
}
