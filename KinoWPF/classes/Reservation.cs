using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KinoWPF
{
    [Serializable]
    public enum Ticket
    {
        Standard,
        HalfPrices
    };

    [Serializable]
    public class Reservation : INotifyPropertyChanged
    {
        #region fields
        private Show show;
        private string name, surname;
        private List<string> seats;
        private Ticket ticketType;
        private bool wasPaid;
        private int id;
        #endregion
        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Reservation()
        {
            seats = new List<string>();
            wasPaid = true;
            name = "";
            surname = "";

        }

        public Reservation(Show argShow, string argName, string argSurname, List<string> argSeats, Ticket argTicketType, bool argWasPaid, int argId)
        {
            show = argShow;
            name = argName;
            surname = argSurname;
            seats = argSeats;
            ticketType = argTicketType;
            wasPaid = argWasPaid;
            id = argId;
        }

        #region get/sets
        public Show Show
        {
            get
            {
                return show;
            }
            set
            {
                show = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                onPropertyChanged(this, "Name");
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                onPropertyChanged(this, "Surname");
            }
        }
        public List<string> Seats
        {
            get
            {
                return seats;
            }
            set
            {
                seats = value;
                onPropertyChanged(this, "Seats");
            }
        }
        public Ticket TicketType
        {
            get
            {
                return ticketType;
            }
            set
            {
                ticketType = value;
                onPropertyChanged(this, "TicketType");
            }
        }
        public bool WasPaid
        {
            get
            {
                return wasPaid;
            }
            set
            {
                wasPaid = value;
                onPropertyChanged(this, "WasPaid");
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        #endregion

        public string GetTicketString()
        {
            if (ticketType == Ticket.HalfPrices)
            {
                return "Ulgowy";
            }
            else
            {
                return "Normalny";
            }
        }
    }
}
