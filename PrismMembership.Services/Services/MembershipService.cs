using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismMembership.Data;

namespace PrismMembership.Services
{
    [Export(typeof(IMembershipService))]
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepo _membershipRepo;

        [ImportingConstructor]
        public MembershipService(IMembershipRepo membershipRepo)
        {
            _membershipRepo = membershipRepo;
        }

        public IEnumerable<Membership> GetAllMemberships()
        {
            return _membershipRepo.All();
            //return new List<Membership>()
            //{
            //    new Membership() {FID = "One", Surname = "Name", Renewal_Date = DateTime.Now, Post_Code = "XXXX"},
            //    new Membership() {FID = "Two", Surname = "Name", Renewal_Date = DateTime.Now, Post_Code = "XXXX"},
            //    new Membership() {FID = "Three", Surname = "Name", Renewal_Date = DateTime.Now, Post_Code = "XXXX"},
            //}.AsEnumerable();
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
