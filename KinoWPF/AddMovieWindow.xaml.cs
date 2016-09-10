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
using Microsoft.Win32;
using System.IO;
using KinoWPF.classes;
using System.Collections.ObjectModel;

namespace KinoWPF
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class AddMovieWindow : Window
    {
        #region fields
        private Movie Movie;
        private Movie oldMovie;
        private Database database;
        #endregion
        #region properties

        public bool isEdit, movieErrors;
        #endregion
        #region constructors
        public AddMovieWindow(Database db)
        {
            InitializeComponent();
            Movie = new Movie();
            database = db;
            MainGrid.DataContext = Movie;
        }
        public AddMovieWindow(Movie movie, Database db)
        {
            InitializeComponent();
            Movie = new Movie(movie);
            oldMovie = movie;
            isEdit = true;
            database = db;
            foreach (Show s in db.Shows)
            {
                if (s.Movie == movie)
                {
                    TBLength.IsEnabled = false;
                    break;
                }
            }

        }
        #endregion

        #region validation
        private bool HasErrors(DependencyObject gridInfo)
        {
            foreach (object child in LogicalTreeHelper.GetChildren(gridInfo))
            {
                TextBox element = child as TextBox;
                if (element == null)
                {
                    continue;
                }
                if (Validation.GetHasError(element) || HasErrors(element))
                {
                    return true;
                }
            }
            return false;
        }
        private void movieValidationError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                BTConfirm.IsEnabled = false;
                movieErrors = true;
            }
            else if (!HasErrors(MainGrid))
            {
                BTConfirm.IsEnabled = true;
                movieErrors = false;
            }
        }
        #endregion
        #region methods

        private void BTLoadPoster(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Wybierz obraz";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //    File.Copy(op.FileName, "/Images/");
                image.Source = new BitmapImage(new Uri(op.FileName));
                Movie.Img = new Image();
                Movie.Img.Source = new BitmapImage(new Uri(op.FileName));
                Movie.ImgFileName = op.FileName;
            }
        }
        #endregion
        #region commands
        private void ConfirmMovie_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (TBTitle.Text != "" && !movieErrors)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void ConfirmMovie_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (isEdit == false)
            {
                database.AddMovie(Movie);
            }
            else
            {
                oldMovie.Title = Movie.Title;
                oldMovie.Director = Movie.Director;
                oldMovie.Description = Movie.Description;
                oldMovie.Img = Movie.Img;
                oldMovie.PremiereDate = Movie.PremiereDate;
                oldMovie.Length = Movie.Length;
                oldMovie.Writer = Movie.Writer;
                oldMovie.Genre = Movie.Genre;
                oldMovie.Production = Movie.Production;
                oldMovie.ImgFileName = Movie.ImgFileName;
            }
            Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

        #region events
        private void LoadWindow(object sender, RoutedEventArgs e)
        {
            MainGrid.DataContext = Movie;

        }
        #endregion
    }
}

