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
        private readonly HelloViewModel _helloViewModel;

        [ImportingConstructor]
        public MembershipModule(MembershipListViewModel membershipListViewModel)
        {
            _membershipListViewModel = membershipListViewModel;
        }

        public void Initialize()
        {
            IRegionManager regionManager = (IRegionManager)ServiceLocator.Current.GetInstance(typeof(IRegionManager));
            regionManager.Regions["MembershipRegion"].Add(new MembershipListControl(_membershipListViewModel));
        }
    }
}
