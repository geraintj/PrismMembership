using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using PrismMembership.Data;
using PrismMembership.Services;

namespace PrismMembership.Modules.Membership.ViewModels
{
    [Export(typeof(MembershipListViewModel))]
    public class MembershipListViewModel
    {
        private readonly IMembershipService _membershipService;

        [ImportingConstructor]
        public MembershipListViewModel(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        private List<PrismMembership.Data.Membership> _membershipList;
        public List<PrismMembership.Data.Membership> MembershipList
        {
            get { return _membershipService.GetAllMemberships().ToList(); }
        }
    }
}
