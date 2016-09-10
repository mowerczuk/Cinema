using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace KinoWPF
{
    [Serializable]
    public class Show
    {
        #region fields
        private Movie movie;
        private List<Reservation> reservations;
        #endregion
        #region properties
        public DateTime? ShowDate
        {
            get; set;
        }
        public TimeSpan StartTime
        {
            get; set;
        }
        public TimeSpan EndTime
        {
            get
            {
                TimeSpan endTime = StartTime.Add(new TimeSpan(0, Movie.Length, 0)).Add(new TimeSpan(0, 30, 0));
                return endTime;
            }
        }
        public int Hall
        {
            get; set;
        }
        public List<Reservation>Reservations
        {
            get
            {
                return reservations;
            }
        }
        public Movie Movie
        {
            get
            {
                return movie;
            }
        }
        #endregion
        #region constructors
        public Show(Movie mov)
        {
            reservations = new List<Reservation>();
            movie = mov;
        }
        #endregion
        public string ShortDate
        {
            get
            {
                return ShowDate.Value.ToShortDateString();
            }
        }
        public string ShortStartTime
        {
            get
            {
                return StartTime.ToString(@"hh\:mm");
            }
        }
        public string ShortEndTime
        {
            get
            {
                return EndTime.ToString(@"hh\:mm");
            }
        }
        public string Title
        {
            get
            {
                return Movie.Title;
            }
        }
        public void RefreshMovieImg()
        {
            Movie.Img = new Image();
            Movie.Img.Source = new BitmapImage(new Uri(Movie.ImgFileName));
        }
        public override string ToString()
        {
            return ShowDate.Value.ToShortDateString() + " " + StartTime.ToString();
        }

    }
}
