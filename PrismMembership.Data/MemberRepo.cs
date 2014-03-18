using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismMembership.Data
{
    public class MemberRepo : IMemberRepo
    {
        public IEnumerable<Member> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> Query(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Member Single(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
