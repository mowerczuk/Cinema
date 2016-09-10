using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KinoWPF
{
    [Serializable]
    public class Movie : INotifyPropertyChanged
    {
        #region fields
        private string title, director, writer, genre, production, description, imgFileName;
        private DateTime? premiereDate;
        private int length;
        private int numberOfShows;

        [NonSerialized]
        private Image img;
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region properties

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                onPropertyChanged(this, "Title");

            }
        }
        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
                onPropertyChanged(this, "Director");
            }
        }
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                onPropertyChanged(this, "Genre");
            }
        }
        public string Production
        {
            get
            {
                return production;
            }
            set
            {
                production = value;
                onPropertyChanged(this, "Production");
            }
        }
        public DateTime? PremiereDate
        {
            get
            {
                return premiereDate;
            }
            set
            {
                premiereDate = value;
                onPropertyChanged(this, "PremiereDateOnly");
            }
        }

        public string PremiereDateOnly
        {
            get
            {
                return premiereDate.Value.Date.ToString("dd/MM/yyyy");
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                onPropertyChanged(this, "LengthString");
            }
        }
        public string LengthString
        {
            get
            {
                return length + " min";
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                onPropertyChanged(this, "Description");
            }
        }
        public string Writer
        {
            get
            {
                return writer;
            }
            set
            {
                writer = value;
                onPropertyChanged(this, "Writer");
            }
        }
        public string ImgFileName
        {
            get
            {
                return imgFileName;
            }
            set
            {
                imgFileName = value;
            }
        }
        public Image Img
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
                onPropertyChanged(this, "Img");
            }
        }
        public int NumberOfShows
        {
            get
            {
                return numberOfShows;
            }
            set
            {
                numberOfShows = value;
            }
        }
        #endregion
        #region constructors

        public Movie()
        {
            title = "";
            director = "";
            genre = "";
            writer = "";
            length = 0;
            premiereDate = null;
            img = null;
        }
        public Movie(Movie mov)
        {
            title = mov.Title;
            director = mov.Director;
            description = mov.Description;
            writer = mov.Writer;
            genre = mov.Genre;
            production = mov.Production;
            premiereDate = mov.PremiereDate;
            length = mov.Length;
            img = mov.Img;
            imgFileName = mov.imgFileName;
        }
        #endregion
        #region methods
        public override string ToString()
        {
            return title;
        }

        public void CreateImageFromFileName()
        {
            img = new Image();
            img.Source = new BitmapImage(new Uri(imgFileName));
        }
        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
