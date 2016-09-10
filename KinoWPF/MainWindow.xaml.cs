using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;
using KinoWPF.classes;
using System.Globalization;

namespace KinoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region fields
        DateTime currentDate;
        Reservation tmpReservation;
        Database db = new Database();
        CultureInfo cultureInfo = new CultureInfo("pl-PL");
        ShowsGrouper showsGrouper;
        #endregion
        public MainWindow()
        {
            InitializeComponent();

            showsGrouper = new ShowsGrouper();
            try
            {
                db = ReadFromBinaryFile<Database>("database.bin");
                LoadImages();
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show(this, "Nie można załadować bazy danych, uruchomić program bez załadowania bazy danych?", 
                    "Cannot load database", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    Close();
                }
                else
                {
                    db = new Database();
                }
            }

            currentDate = DateTime.Today;
            tmpReservation = new Reservation();

            LBRepertuar.ItemsSource = db.Movies;
            LBShows.ItemsSource = db.Shows;
            LBReservedList.ItemsSource = db.Reservations;
            NewReservationGrid.DataContext = tmpReservation;
            var plDay = cultureInfo.DateTimeFormat.GetDayName(currentDate.DayOfWeek);
            LBCurrentDate.Content = plDay.ToString() + ", " + currentDate.ToString("dd/MM/yyyy");
            ApplyDateFilter();
            GroupHours();
            SortStartTime();
        }

        #region File Save&Load
        public void LoadImages()
        {
            foreach (Movie m in db.Movies)
            {
                m.CreateImageFromFileName();
            }
        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
        #endregion
        #region methods
        private void ReservationSelected(object sender, SelectionChangedEventArgs e)
        {
            if (LBReservedList.SelectedIndex > -1 && CBPaid.IsChecked == false)
            {
                GBReservationDetails.IsEnabled = true;
            }
            else
            {
                GBReservationDetails.IsEnabled = false;
            }

            //if (GBReservationDetails.IsEnabled == false && CBPaid.IsChecked == false)
            //{
            //    GBReservationDetails.IsEnabled = true;
            //}
            //else
            //{
            //    GBReservationDetails.IsEnabled = false;
            //}
        }
        private void WasPaid(object sender, RoutedEventArgs e)
        {
            if (CBPaid.IsChecked == true)
            {
                CBPaid.IsEnabled = false;
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            WriteToBinaryFile<Database>("database.bin", db);
            this.Close();
        }

        private void AddMovie(object sender, RoutedEventArgs e)
        {
            AddMovieWindow newMovie = new AddMovieWindow(db);
            newMovie.Show();
        }
        public int FindAvailableId()
        {
            int id = 1;
            bool sw = true;
            if (db.Reservations == null || db.Reservations.Count == 0)
            {
                sw = false;
            }
            while (sw)
            {
                foreach (Reservation r in db.Reservations)
                {
                    if (r.Id == id)
                    {
                        id++;
                        sw = true;
                        break;
                    }
                    sw = false;
                }
            }
            return id;
        }
        private void OpenShowsWindow(object sender, RoutedEventArgs e)
        {
            ShowsWindow shows = new ShowsWindow(db);

            shows.Show();
        }
        private void DisplayShowsForToday(object sender, RoutedEventArgs e)
        {
            BTShowAll.Visibility = Visibility.Collapsed;
            BTPrev.Visibility = Visibility.Visible;
            BTNext.Visibility = Visibility.Visible;
            LBCurrentDate.Visibility = Visibility.Visible;
            ApplyDateFilter();
            GroupHours();
            TBGroupHeader.Text = "Wszystkie seanse";           
        }
        private void KeyShortcuts(object sender, KeyEventArgs e)
        {
            if (TCMainWindow.SelectedIndex == 1)
            {
                if (e.Key == Key.Left)
                {
                    if (BTPrev.IsEnabled == true)
                    {
                        PrevWeek_Executed(null, null);
                    }
                    e.Handled = true;
                }
                if (e.Key == Key.Right)
                {
                    if (BTNext.IsEnabled == true)
                    {
                        NextWeek_Executed(null, null);
                    }
                    e.Handled = true;
                }
            }
        }
        private void EditMovie(object sender, MouseButtonEventArgs e)
        {
            AddMovieWindow newMovie = new AddMovieWindow(LBRepertuar.SelectedItem as Movie, db);
            newMovie.Show();
        }
        #endregion
        #region groups&sorts methods
        private ListCollectionView MoviesView
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(db.Movies);
            }
        }
        private void SortNone(object sender, RoutedEventArgs e)
        {
            MoviesView.SortDescriptions.Clear();
        }

        private void SortTitle(object sender, RoutedEventArgs e)
        {
            MoviesView.SortDescriptions.Clear();
            MoviesView.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
        }

        private void SortPremiereDate(object sender, RoutedEventArgs e)
        {
            MoviesView.SortDescriptions.Clear();
            MoviesView.SortDescriptions.Add(new SortDescription("PremiereDate", ListSortDirection.Descending));
        }
        private void SortStartTime()
        {
            ShowsView.SortDescriptions.Clear();
            ShowsView.SortDescriptions.Add(new SortDescription("StartTime", ListSortDirection.Ascending));
        }
        private void SortShowDate()
        {
            ShowsView.SortDescriptions.Clear();
            ShowsView.SortDescriptions.Add(new SortDescription("ShowDate", ListSortDirection.Ascending));
        }
        private void GroupNone(object sender, RoutedEventArgs e)
        {
            MoviesView.GroupDescriptions.Clear();
        }

        private void GroupGenre(object sender, RoutedEventArgs e)
        {
            MoviesView.GroupDescriptions.Clear();
            MoviesView.GroupDescriptions.Add(new PropertyGroupDescription("Genre"));
        }

        private void GroupProduction(object sender, RoutedEventArgs e)
        {
            MoviesView.GroupDescriptions.Clear();
            MoviesView.GroupDescriptions.Add(new PropertyGroupDescription("Production"));
        }
        private void GroupDate()
        {
            ShowsView.GroupDescriptions.Clear();
            ShowsView.GroupDescriptions.Add(new PropertyGroupDescription("ShortDate"));

        }
        private void GroupHours()
        {
            ShowsView.GroupDescriptions.Clear();
            ShowsView.GroupDescriptions.Add(new PropertyGroupDescription("StartTime", showsGrouper));
        }
        #endregion
        #region filters
        public ListCollectionView ShowsView
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(db.Shows);
            }
        }
        private ListCollectionView ReservationsView
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(db.Reservations);
            }
        }
        private void RemoveFilter()
        {
            ShowsView.Filter = null;
        }
        private void ApplyDateFilter()
        {
            ShowsView.Filter = delegate (object item)
            {
                Show show = item as Show;
                if (show.ShowDate == currentDate)
                {
                    return true;
                }
                return false;
            };
        }
        private void ApplyTitleFilter()
        {
            ShowsView.Filter = delegate (object item)
            {
                Show show = item as Show;
                if (show.Movie.Title == (LBRepertuar.SelectedItem as Movie).Title)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
        }
        private void ReservFilterChanged(object sender, TextChangedEventArgs e)
        {
            ReservationsView.Filter = delegate (object item)
            {
                Reservation res = item as Reservation;
                if (TBId.Text != "")
                {
                    int id;
                    if (int.TryParse(TBId.Text, out id))
                    {
                        if (cultureInfo.CompareInfo.IndexOf(res.Name, TBResName.Text, CompareOptions.IgnoreCase) >= 0 && cultureInfo.CompareInfo.IndexOf(res.Surname, TBResSurname.Text, CompareOptions.IgnoreCase) >= 0 && res.Id == id)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    if (cultureInfo.CompareInfo.IndexOf(res.Name, TBResName.Text, CompareOptions.IgnoreCase) >= 0 && cultureInfo.CompareInfo.IndexOf(res.Surname, TBResSurname.Text, CompareOptions.IgnoreCase) >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            };
        }
        #endregion
        #region commands
        private void Remove_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox lb = e.Parameter as ListBox;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Jesteś pewien?", "Potwierdź usunięcie", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if ((lb.SelectedItem as Movie) != null)
                {
                    foreach(Show s in db.Shows.ToList())
                    {
                        if (s.Movie == lb.SelectedItem as Movie)
                        {
                            db.Shows.Remove(s);
                        }
                    }
                    foreach(Reservation r in db.Reservations.ToList())
                    {
                        if (r.Show.Movie == lb.SelectedItem as Movie)
                        {
                            db.Reservations.Remove(r);
                        }
                    }
                    db.Movies.Remove(lb.SelectedItem as Movie);
                }
                else if ((lb.SelectedItem as Reservation) != null)
                {
                    Reservation res = lb.SelectedItem as Reservation;
                    db.Reservations.Remove(res);
                    foreach (Show s in db.Shows)
                    {
                        if (s == res.Show)
                        {
                            s.Reservations.Remove(res);
                            break;
                        }
                    }
                    
                }
            }
        }

        private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox lb = e.Parameter as ListBox;
            if ((lb.SelectedItem as Movie) != null)
            {
                AddMovieWindow newMovie = new AddMovieWindow(lb.SelectedItem as Movie, db);
                newMovie.ShowDialog();
            }

        }
        private void EditOrRemove_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ListBox lb = e.Parameter as ListBox;
            if (lb != null && lb.SelectedIndex != -1)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void AddReservation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            tmpReservation.Id = FindAvailableId();
            tmpReservation.Show= LBShows.SelectedItem as Show;
            db.AddReservation(tmpReservation);
            (LBShows.SelectedItem as Show).Reservations.Add(tmpReservation);
            LBReservedList.Items.Refresh();

            tmpReservation = new Reservation();
            NewReservationGrid.DataContext = tmpReservation;
            TCMainWindow.SelectedIndex = 2;
            LBReservedList.SelectedItem = tmpReservation;

        }
        private void AddReservation_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (TBReservedName != null &&
                TBReservedSurname != null &&
                TBPlace != null &&
                TBName.Text != "" && !Validation.GetHasError(TBName) &&
                TBSurname.Text != "" && !Validation.GetHasError(TBSurname) &&
                TBPlace.Text != "")
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void FindSeats_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is Show)
            {
                Show show = e.Parameter as Show;
                HallWindow newHall = new HallWindow(show);
                if (newHall.ShowDialog() == true)
                {
                    tmpReservation.Seats = newHall.reservedSeats;
                }
            }
            else
            {
                Reservation reservation = e.Parameter as Reservation;
                HallWindow newHall = new HallWindow(reservation);
                if (newHall.ShowDialog() == true)
                {
                    reservation.Seats = newHall.reservedSeats;
                }
            }
        }
        private void FindSeats_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((e.Parameter) != null)
            {
                if (e.Parameter is Reservation)
                {
                    if (CBPaid.IsChecked == false)
                    {
                        e.CanExecute = true;
                    }
                    else
                    {
                        e.CanExecute = false;
                    }
                }
                else
                {
                    e.CanExecute = true;
                }
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void NextWeek_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(1);
            var plDay = cultureInfo.DateTimeFormat.GetDayName(currentDate.DayOfWeek);
            LBCurrentDate.Content = plDay.ToString() + ", " + currentDate.ToString("dd/MM/yyyy");
            tmpReservation.Seats = new List<string>();
            ApplyDateFilter();
        }
        private void PrevWeek_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-1);
            var plDay = cultureInfo.DateTimeFormat.GetDayName(currentDate.DayOfWeek);
            LBCurrentDate.Content = plDay.ToString() + ", " + currentDate.ToString("dd/MM/yyyy");
            tmpReservation.Seats = new List<string>();
            ApplyDateFilter();
        }
        private void Continue_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            BTPrev.Visibility = Visibility.Hidden;
            BTNext.Visibility = Visibility.Hidden;
            LBCurrentDate.Visibility = Visibility.Hidden;
            BTShowAll.Visibility = Visibility.Visible;
            TBGroupHeader.Text = "Seanse na \"" + (LBRepertuar.SelectedItem as Movie).Title + "\"";
            ApplyTitleFilter();
            GroupDate();
            SortShowDate();
            TCMainWindow.SelectedIndex++;
        }
        private void Continue_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (LBRepertuar.SelectedIndex != -1)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void PrintTicket_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (LBReservedList.SelectedIndex > -1 && CBPaid.IsChecked == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }

        }

        private void PrintTicket_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Reservation tmpR = LBReservedList.SelectedItem as Reservation;
            Show tmpS = tmpR.Show;

            TicketWindow printTicket = new TicketWindow();

            printTicket.SetTicketData(tmpS.Title, tmpS.ShortDate, tmpS.ShortStartTime, tmpS.Hall, TBReservedPlace.Text, tmpR.Name, tmpR.Surname, tmpR.GetTicketString());

            printTicket.Show();
        }

        #endregion


    }
}
