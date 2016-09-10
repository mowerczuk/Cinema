using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KinoWPF.classes
{
    [Serializable]
    public class Database
    {
        private ObservableCollection<Movie> movies;
        private ObservableCollection<Show> shows;
        private ObservableCollection<Reservation> reservations;

        public ObservableCollection<Movie> Movies
        {
            get
            {
                return movies;
            }
        }
        public ObservableCollection<Show> Shows
        {
            get
            {
                return shows;
            }
        }
        public ObservableCollection<Reservation> Reservations
        {
            get
            {
                return reservations;
            }
        }
        public Database()
        {
            movies = new ObservableCollection<Movie>();
            shows = new ObservableCollection<Show>();
            reservations = new ObservableCollection<Reservation>();
        }
        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
        public void AddShow(Show show)
        {
            Shows.Add(show);
        }
        public void AddReservation(Reservation res)
        {
            reservations.Add(res);
        }
        //private Database(SerializationInfo info, StreamingContext context)
        //{
        //    movies = info.GetValue("movies", typeof(ObservableCollection<Movie>)) as ObservableCollection<Movie>;
        //    shows = info.GetValue("shows", typeof(ObservableCollection<Show>)) as ObservableCollection<Show>;
        //    reservations = info.GetValue("reservations", typeof(List<Reservation>)) as List<Reservation>;
        //}

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("movies", movies);
        //    info.AddValue("shows", shows);
        //    info.AddValue("reservation", reservations);
        //}
    }
}
