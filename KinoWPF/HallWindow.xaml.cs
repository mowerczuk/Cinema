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
    /// Interaction logic for HallWindow.xaml
    /// </summary>
    public partial class HallWindow : Window
    {
        public List<string> reservedSeats;

        public HallWindow(Show s)
        {
            InitializeComponent();
            reservedSeats = new List<string>();
            PrepareHall(s);
        }
        public HallWindow(Reservation res)
        {
            InitializeComponent();
            reservedSeats = new List<string>(res.Seats);
            res.Seats = new List<string>();

            PrepareHall(res.Show);
        }
        private void SeatClick(object sender, RoutedEventArgs e)
        {
            Button CurrentSeat = (Button)sender;

            if (CurrentSeat.Background == Brushes.DeepSkyBlue)   // odznaczanie
            {
                CurrentSeat.ClearValue(BackgroundProperty);
                reservedSeats.Remove(CurrentSeat.Content.ToString());

            }
            else    // zaznaczanie
            {
                CurrentSeat.SetValue(BackgroundProperty, Brushes.DeepSkyBlue);
                reservedSeats.Add(CurrentSeat.Content.ToString());
            }

            reservedSeats.Sort();
        }
        private void PrepareHall(Show show)
        {
            Button btn;
            foreach (Reservation reservation in show.Reservations)
            {
                foreach(string seat in reservation.Seats)
                {
                    btn = LogicalTreeHelper.FindLogicalNode(SeatsGrid, seat) as Button;
                    btn.IsEnabled = false;
                }
            }
            foreach (string seat in reservedSeats)
            {
                btn = LogicalTreeHelper.FindLogicalNode(SeatsGrid, seat) as Button;
                btn.SetValue(BackgroundProperty, Brushes.DeepSkyBlue);
            }
        }
        private void AcceptButton(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
