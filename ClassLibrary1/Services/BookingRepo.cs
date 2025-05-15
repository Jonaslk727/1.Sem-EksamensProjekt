using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models; //Model klasserne kan tilgås

namespace ClassLibrary1.Services
{
    public class BookingRepo
    {
        private Dictionary<int, Booking> _bookings = new Dictionary<int, Booking>();
        private int _nextId = 1;

        #region BookingListe
        //property liste for alle bookinger.
        public List<Booking> Bookings => _bookings.Values.ToList();
        #endregion

        #region OpretBooking
        //Opret ny booking
        public void OpenBooking(BookingType type, DateTime startTid, int varighed, Kunde booker)
        {
            var booking = new Booking(type, startTid, varighed, booker)
            {
                BookingId = _nextId++
            };
            //Tilføjer et ID, så hvis booking.BookingId er 5, så gemmes bookingen med nummeret. 
            //Det sikre hurtig adgang til bookinger via et unikt ID
            _bookings.Add(booking.BookingId, booking);
        }
        #endregion

        #region SletBooking
        // Slet en booking
        public bool DeleteBooking(int bookingID)
        {
            return _bookings.Remove(bookingID);
        }
        #endregion

        #region RedigerBooking
        // Rediger en booking
        public bool EditBooking(int bookingId, BookingType newType, DateTime newStartTid,
            int newVarighed)
        {
            if (!_bookings.TryGetValue(bookingId, out var booking))
                return false;

            booking.Type = newType;
            booking.StartTid = newStartTid;
            booking.Varighed = newVarighed;

            return true;
        }
        #endregion
    }
}

