using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismMembership.Data
{
    public interface IMemberRepo
    {
        IEnumerable<Member> All();
        IEnumerable<Member> Query(Expression<Func<Member, bool>> predicate);
        Member Single(Expression<Func<Member, bool>> predicate);
    }
}
