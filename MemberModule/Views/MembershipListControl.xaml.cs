﻿using System;
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
using PrismMembership.Modules.Membership.ViewModels;

namespace PrismMembership.Modules.Membership.Views
{
    /// <summary>
    /// Interaction logic for MembershipListControl.xaml
    /// </summary>
    [Export]
    public partial class MembershipListControl : UserControl
    {
        [ImportingConstructor]
        public MembershipListControl(MembershipListViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
