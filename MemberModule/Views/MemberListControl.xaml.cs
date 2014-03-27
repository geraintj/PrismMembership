using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrismMembership.Modules.Membership.Extensions;
using PrismMembership.Modules.Membership.ViewModels;

namespace PrismMembership.Modules.Membership.Views
{
    /// <summary>
    /// Interaction logic for MemberListControl.xaml
    /// </summary>
    [Export]
    public partial class MemberListControl : UserControl
    {
        private MemberListViewModel ViewModel;
        [ImportingConstructor]
        public MemberListControl(MemberListViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void SearchStringPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                ViewModel.SelectFullMatch();
            }
            else if (e.Key == Key.Down)
            {
                if (ViewModel.FoundMembers.Count > 0)
                {
                    e.Handled = true;
                    MemberList.Focus();
                }
            }
        }

        private void SearchStringLoaded(object sender, RoutedEventArgs e)
        {
            SearchString.BackgroundFocus();
        }
    }
}
