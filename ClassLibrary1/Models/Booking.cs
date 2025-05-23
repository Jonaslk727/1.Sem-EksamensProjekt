namespace ClassLibrary1.Models
{
    /// <summary>
    /// Klasse: Booking  
    /// Håndterer booking af aktiviteter og besøg på Roskilde Dyreinternat.  
    /// Indeholder information om bookingtype, tidsramme, varighed,  
    /// bookende kunde og eventuelt tilknyttet dyr.  
    /// Genererer automatisk et unikt BookingId.  
    /// </summary>

    /// Enum: BookingType  
    /// Definerer de mulige bookingtyper i systemet:
    public enum BookingType
    {
        Aktivitet,
        Besøg
    }
    public class Booking
    {
        #region properties
        private static int _nextId = 0;
        public int BookingId { get; set; }
        public BookingType Type { get; set; }
        public DateTime StartTid {  get; set; }
        public DateTime SlutTid { get { return StartTid.AddHours(Varighed); } }
        public int Varighed { get; set; } // i timer
        public Kunde Booker { get;}
        public Dyr BookedDyr { get; set; } // Dyr der bookes til aktiviteten
        #endregion
        /// Konstruktør til oprettelse af en booking med angivne værdier.
        /// Initialiserer bookingens type, starttid, varighed og bookende

        public Booking(BookingType type, DateTime startTid, int varighed, Kunde booker)
        {
            BookingId = ++_nextId;
            Type = type;
            StartTid = startTid;
            Varighed = varighed;
            Booker = booker;
        }
        public Booking()
        {
            BookingId = _nextId++;
        }

        /// Returnerer en formateret tekst med detaljer om bookingen.
        public override string ToString()
        {
            return $"BookingId: {BookingId} | StartTid: {StartTid} | SlutTid: {SlutTid} | Varighed: {Varighed} timer " +
                $"| Booker: {Booker}";
        }
    }
}
