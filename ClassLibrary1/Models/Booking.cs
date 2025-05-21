using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public enum BookingType
    {//BookingType enum til at definere forskellig type af bookinger
        Aktivitet,
        Besøg
    }
    public class Booking
    {  // Model for booking af dyrlæg og aktiviteter 
        private static int _nextId = 0;
        //Unik ID til booking
        public int BookingId { get; set; }
        public BookingType Type { get; set; }
        public DateTime StartTid {  get; set; }
        public DateTime SlutTid { get { return StartTid.AddHours(Varighed); } }
        public int Varighed { get; set; } // i timer
        public Kunde Booker { get;}
        public Dyr BookedDyr { get; set; } // Dyr der bookes til aktiviteten

        public Booking(BookingType type, DateTime startTid, int varighed, Kunde booker)
        {//Constructor til at initilaizere properties
            BookingId = ++_nextId;
            Type = type;
            StartTid = startTid;
            Varighed = varighed;
            Booker = booker;
        }

        /// <summary>
        /// Initialiserer en ny booking og tildeler et unikt ID.
        /// ID'et øges automatisk med hver ny booking.
        /// </summary>


        public Booking()
        {
            BookingId = _nextId++;
        }

        public override string ToString()
        {//Override ToString metod til at returnere en formatteret string af bookingen
            return $"BookingId: {BookingId} | StartTid: {StartTid} | SlutTid: {SlutTid} | Varighed: {Varighed} timer " +
                $"| Booker: {Booker}";
        }
    }
}
