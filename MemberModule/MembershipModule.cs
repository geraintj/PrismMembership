using System;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using PrismMembership.Modules.Membership.ViewModels;
using PrismMembership.Modules.Membership.Views;

namespace PrismMembership.Modules.Membership
{
    [ModuleExport(typeof(MembershipModule))]
    public class MembershipModule : IModule
    {
        private readonly MembershipListViewModel _membershipListViewModel;
        private readonly MemberListViewModel _memberListViewModel;

        [ImportingConstructor]
        public MembershipModule(MembershipListViewModel membershipListViewModel, MemberListViewModel memberListViewModel)
        {
            _membershipListViewModel = membershipListViewModel;
            _memberListViewModel = memberListViewModel;
        }

        public void Initialize()
        {
            IRegionManager regionManager = (IRegionManager)ServiceLocator.Current.GetInstance(typeof(IRegionManager));
            //regionManager.Regions["MembershipRegion"].Add(new MembershipListControl(_membershipListViewModel));
            regionManager.Regions["MembershipRegion"].Add(new MemberListControl(_memberListViewModel));
        }
    }
}
