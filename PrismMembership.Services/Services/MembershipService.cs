using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismMembership.Data;

namespace PrismMembership.Services
{
    [Export]
    public class MembershipService : IMembershipService
    {
        private readonly IRepo<Membership> _membershipRepo;

        [ImportingConstructor]
        public MembershipService(IRepo<Membership> membershipRepo)
        {
            _membershipRepo = membershipRepo;
        }

        public IEnumerable<Membership> GetAllMemberships()
        {
            return _membershipRepo.All();
        }

        public IEnumerable<Membership> SearchMemberships(string surname)
        {
            return _membershipRepo.Query(m => m.Surname.StartsWith(surname));
        }

        public Membership GetMembership(string fId)
        {
            return _membershipRepo.Single(m => m.FID == fId);
        }
    }
}
