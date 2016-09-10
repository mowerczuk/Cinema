using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace KinoWPF
{
    /// <summary>
    /// Interaction logic for TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        public TicketWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TicketData.Height = Ticket.Height - 20;
            TicketData.Width = Ticket.Width - 20;
            TicketData.Margin = new Thickness(10);
        }

        private void TicketMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PrintButtonClick(object sender, RoutedEventArgs e)
        {
            PrintDialog printTicket = new PrintDialog();
            if (printTicket.ShowDialog() == true)
            {
                Ticket.LayoutTransform = new ScaleTransform(1, 1);
                int pageMargin = 10;
                Size pageSize = new Size(printTicket.PrintableAreaWidth - pageMargin * 2, printTicket.PrintableAreaHeight - pageMargin * 2);
                Ticket.Measure(pageSize);
                Ticket.Arrange(new Rect(pageMargin, pageMargin, pageSize.Width, pageSize.Height));

                printTicket.PrintVisual(Ticket, "A simple drawing");

                Ticket.LayoutTransform = null;
            }

            Close();
        }

        public void SetTicketData(
            string argTitle,
            string argShortDate,
            string argShortStartTime,
            int argHall,
            string argSeats,
            string argName,
            string argSurname,
            string argTicket)
        {
            LabelTicketTitle.Content = argTitle;
            LabelTicketDate.Content = argShortDate;
            LabelTicketTime.Content = argShortStartTime;
            LabelTicketHall.Content = argHall;
            LabelTicketSeats.Content = argSeats;
            LabelTicketName.Content = argName;
            LabelTicketSurname.Content = argSurname;
            LabelTicketType.Content = argTicket;
        }
    }
}
