namespace ClassLibrary1.Models
{
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

        public override string ToString()
        {
            return $"BookingId: {BookingId} | StartTid: {StartTid} | SlutTid: {SlutTid} | Varighed: {Varighed} timer " +
                $"| Booker: {Booker}";
        }
    }
}
