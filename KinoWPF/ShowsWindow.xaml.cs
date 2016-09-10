using KinoWPF.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class ShowsWindow : Window
    {
        Database data;
        DateTime dt;
        ObservableCollection<Show> showsToAdd;
        List<Show> showsToRemove;
        ObservableCollection<string> halls;
        ObservableCollection<Movie> movies;
        int week = 0;
        public ShowsWindow(Database db)
        {
            InitializeComponent();

            data = db;

            showsToAdd = new ObservableCollection<Show>(data.Shows);
            showsToRemove = new List<Show>();
            halls = new ObservableCollection<string> { "Wszystkie", "1", "2", "3", "4", "5" };
            movies = new ObservableCollection<Movie>(db.Movies);

            Movie placeHolder = new Movie();
            placeHolder.Title = "Wszystkie";
            movies.Insert(0, placeHolder);

            dt = DateTime.Today;

            CBMovies.ItemsSource = movies;
            CBMovies.SelectedIndex = 0;
            CBHalls.ItemsSource = halls;
            CBHalls.SelectedIndex = 0;
            LBDateFrom.Content = dt.ToString("dd/MM/yyyy");
            LBDateTo.Content = dt.AddDays(7).ToString("dd/MM/yyyy");
            Week w = new Week(dt);
            LBChosenDates.ItemsSource = showsToAdd;
            GridDays.DataContext = w;
            View.GroupDescriptions.Add(new PropertyGroupDescription("Title"));
            View.SortDescriptions.Add(new SortDescription("ShowDate", ListSortDirection.Ascending));
        }
        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(showsToAdd);
            }
        }
        private void Filter()
        {
            View.Filter = delegate (object item)
            {
                Show s = item as Show;
                if (s != null)
                {
                    if ((CBMovies.SelectedItem as Movie).Title != "Wszystkie")
                    {
                        string hall = CBHalls.SelectedItem as string;
                        if ((CBHalls.SelectedItem as string) != "Wszystkie")
                        {
                            if (s.Movie == CBMovies.SelectedItem && s.Hall == int.Parse(hall) && s.ShowDate.Value.CompareTo(dt) >= 0 && s.ShowDate.Value.CompareTo(dt.AddDays(7)) <= 0)
                            {
                                return true;
                            }
                            return false;
                        }
                        else
                        {
                            if (s.Movie == CBMovies.SelectedItem && s.ShowDate.Value.CompareTo(dt) >= 0 && s.ShowDate.Value.CompareTo(dt.AddDays(7)) <= 0)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    else
                    {
                        string hall = CBHalls.SelectedItem as string;
                        if ((CBHalls.SelectedItem as string) != "Wszystkie")
                        {
                            if (s.Hall == int.Parse(hall) && s.ShowDate.Value.CompareTo(dt) >= 0 && s.ShowDate.Value.CompareTo(dt.AddDays(7)) <= 0)
                            {
                                return true;
                            }
                            return false;
                        }
                        else
                        {
                            if (s.ShowDate.Value.CompareTo(dt) >= 0 && s.ShowDate.Value.CompareTo(dt.AddDays(7)) <= 0)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                }
                return false;

            };
        }
        private void GenerateTable(object sender, RoutedEventArgs e)
        {
            if (CBMovies.SelectedIndex == -1 || CBHalls.SelectedIndex == -1) return;
            Filter();
            TurnAllButtonsOn();
            Button btn;
            TimeSpan tempStartTime = new TimeSpan(10, 0, 0);
            TimeSpan tempEndTime = tempStartTime.Add(new TimeSpan(0, (CBMovies.SelectedItem as Movie).Length, 0)).Add(new TimeSpan(0, 30, 0));
            int row;
            bool cont = false;
            for (int day = 0; day < 7; day++)
            {
                tempStartTime = new TimeSpan(10, 0, 0);
                tempEndTime = tempStartTime.Add(new TimeSpan(0, (CBMovies.SelectedItem as Movie).Length, 0));
                row = 0;
                while (tempStartTime.CompareTo(new TimeSpan(22, 30, 0)) < 0)
                {
                    cont = false;
                    btn = LogicalTreeHelper.FindLogicalNode(DataGrid, "btn" + row + "" + day) as Button;
                    foreach (Show s in showsToAdd)
                    {
                        if (!s.ShowDate.Equals(dt.AddDays(day)))
                        {
                            continue;
                        }
                        else
                        {
                            int hall;
                            if (int.TryParse(CBHalls.SelectedItem as string, out hall))
                            {
                                if (hall == s.Hall && ((tempEndTime.CompareTo(s.StartTime) >= 0 && tempEndTime.CompareTo(s.EndTime) <= 0) ||
                                    (tempStartTime.CompareTo(s.StartTime) >= 0 && tempStartTime.CompareTo(s.EndTime) <= 0)))
                                {
                                    cont = true;
                                    break;
                                }
                            }

                        }
                    }

                    if (cont)
                        btn.IsEnabled = false;

                    row++;
                    tempStartTime = tempStartTime.Add(new TimeSpan(0, 30, 0));
                    tempEndTime = tempEndTime.Add(new TimeSpan(0, 30, 0));
                }
            }
        }

        private void TurnAllButtonsOn()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    Button btn = LogicalTreeHelper.FindLogicalNode(DataGrid, "btn" + j + "" + i) as Button;
                    btn.IsEnabled = true;
                }
            }
        }
        private void FinishEditing(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
            foreach (Show s in showsToRemove)
            {
                if (data.Shows.Contains(s))
                {
                    data.Shows.Remove(s);
                    s.Movie.NumberOfShows--;
                }
            }
            foreach (Show s in showsToAdd)
            {
                if (!data.Shows.Contains(s))
                {
                    data.Shows.Add(s);
                    s.Movie.NumberOfShows++;
                }
            }
            Close();
        }

        #region commands
        private void PrevWeek_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            dt = dt.AddDays(-7);
            if (LBDateFrom != null)
            {
                LBDateFrom.Content = dt.ToString("dd/MM/yyyy");
            }
            if (LBDateTo != null)
            {
                LBDateTo.Content = dt.AddDays(7).ToString("dd/MM/yyyy");
            }
            Week w = new Week(dt);
            Filter();
            GridDays.DataContext = w;
            week--;
            GenerateTable(null, null);
        }

        private void PrevWeek_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (LBDateFrom != null && LBDateFrom.Content.ToString() != DateTime.Today.ToString("dd/MM/yyyy"))
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void NextWeek_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (LBDateFrom != null && LBDateTo != null)
            {
                dt = dt.AddDays(7);
                LBDateFrom.Content = dt.ToString("dd/MM/yyyy");
                LBDateTo.Content = dt.AddDays(7).ToString("dd/MM/yyyy");
                Week w = new Week(dt);
                Filter();
                GridDays.DataContext = w;
                week++;
                GenerateTable(null, null);
            }
        }
        private void NextWeek_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void RemoveShow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Show s = e.Parameter as Show;
            TimeSpan diff = s.ShowDate.Value - dt;
            int day = diff.Days;

            showsToRemove.Add(s);
            showsToAdd.Remove(s);
            GenerateTable(null, null);
        }
        private void AddShow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TimeSpan ts = new TimeSpan(10, 0, 0);
            Button btn = e.Source as Button;

            int row = Grid.GetRow(btn);
            int day = Grid.GetColumn(btn);

            for (int i = 0; i < row; i++)
            {
                ts = ts.Add(new TimeSpan(0, 30, 0));
            }

            Show show = new Show(CBMovies.SelectedItem as Movie);
            show.StartTime = ts;
            show.ShowDate = dt.AddDays(day);
            show.Hall = int.Parse(CBHalls.Text);
            showsToAdd.Add(show);
            GenerateTable(null, null);
        }
        private void AddShow_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Movie mov = CBMovies.SelectedItem as Movie;
            Button btn = e.Source as Button;
            int days = Grid.GetColumn(btn);
            string hall = CBHalls.SelectedItem as string;
            if (CBMovies.SelectedIndex > 0 && hall != "Wszystkie" && mov.PremiereDate != null && mov.PremiereDate.Value.CompareTo(dt.AddDays(days)) <= 0 && mov.Length > 0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        #endregion

        private void KeyShortcuts(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                if (BTPrev.IsEnabled == true)
                {
                    PrevWeek_Executed(null, null);
                }
            }
            if (e.Key == Key.Right)
            {
                if (BTNext.IsEnabled == true)
                {
                    NextWeek_Executed(null, null);
                }
            }
            e.Handled = true;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

