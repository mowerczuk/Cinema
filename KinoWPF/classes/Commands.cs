using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinoWPF
{
    public static class Commands
    {
        public static readonly RoutedUICommand Confirm = new RoutedUICommand("Confirm", "Confirm", typeof(Commands));
        public static readonly RoutedUICommand Remove = new RoutedUICommand("Remove", "Remove", typeof(Commands));
        public static readonly RoutedUICommand Add = new RoutedUICommand("Add", "Add", typeof(Commands));
        public static readonly RoutedUICommand Find = new RoutedUICommand("Find", "Find", typeof(Commands));
        public static readonly RoutedUICommand Edit = new RoutedUICommand("Edit", "Edit", typeof(Commands));
        public static readonly RoutedUICommand Filter = new RoutedUICommand("Filter", "Filter", typeof(Commands));
        public static readonly RoutedUICommand PrevWeek = new RoutedUICommand("PrevWeek", "PrevWeek", typeof(Commands));
        public static readonly RoutedUICommand NextWeek = new RoutedUICommand("NextWeek", "NextWeek", typeof(Commands));
        public static readonly RoutedUICommand Continue = new RoutedUICommand("Continue", "Continue", typeof(Commands));
        public static readonly RoutedUICommand PrintTicket = new RoutedUICommand("PrintTicket", "PrintTicket", typeof(Commands));
    }
}
