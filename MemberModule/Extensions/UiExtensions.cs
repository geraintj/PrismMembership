using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PrismMembership.Modules.Membership.Extensions
{
    public static class UiExtensions
    {
        public static void BackgroundFocus(this UIElement el)
        {
            Action a = () => Keyboard.Focus(el);
            el.Dispatcher.BeginInvoke(DispatcherPriority.Input, a);
        }
    }
}
