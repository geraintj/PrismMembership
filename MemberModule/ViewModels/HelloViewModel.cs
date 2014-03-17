using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace PrismMembership.Modules.Membership.ViewModels
{
    [Export(typeof(HelloViewModel))]
    public class HelloViewModel
    {
        public string Name
        {
            get { return "Hello"; }
        }
    }
}
