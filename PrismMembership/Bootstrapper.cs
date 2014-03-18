using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;

namespace PrismMembership
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new Shell();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            //AggregateCatalog.Catalogs.Add(
                //new AssemblyCatalog(typeof (PrismMembership.Modules.Membership.MembershipModule).Assembly));

            var path = System.IO.Path.GetDirectoryName(Application.ResourceAssembly.Location);
            if (path != null)
            {
                AggregateCatalog.Catalogs.Add(new DirectoryCatalog(path, "PrismMembership.Modules.Membership.dll"));
                AggregateCatalog.Catalogs.Add(new DirectoryCatalog(path, "PrismMembership.Data.dll"));
                AggregateCatalog.Catalogs.Add(new DirectoryCatalog(path, "PrismMembership.Services.dll"));
            }
        }
    }
}
