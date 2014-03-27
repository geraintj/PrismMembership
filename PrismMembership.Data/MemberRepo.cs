using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismMembership.Data
{
    [Export(typeof(IMemberRepo))]
    public class MemberRepo : IMemberRepo
    {
        private IObjectSet<Member> _objectSet;

        public MemberRepo()
        {
            _objectSet = new ObjectContext("name=Entities").CreateObjectSet<Member>();
        }
        public IEnumerable<Member> All()
        {
            return _objectSet.ToList();
        }

        public IEnumerable<Member> Query(Expression<Func<Member, bool>> predicate)
        {
            return _objectSet.Where(predicate).AsEnumerable();
        }

        public Member Single(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
