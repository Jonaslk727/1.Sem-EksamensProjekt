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

        #region Properties  
        public Dictionary<int, Booking> AlleBokinger => _bookings;
        #endregion

        #region Opret Booking  
        //property liste for alle bookinger  
        public bool OpenBooking(BookingType type, DateTime startTid, int varighed, Kunde booker)
        {
            try
            {
                var booking = new Booking(type, startTid, varighed, booker)
                {
                    BookingId = _nextId++
                };
                _bookings.TryAdd(booking.BookingId, booking);
                Console.WriteLine($"Booking opretttet med iD: {booking.BookingId}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved oprettelse af booking: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region SletBooking  
        // Slet en booking  
        public bool DeleteBooking(int bookingID)
        {
            if (_bookings.Remove(bookingID))
            {
                Console.WriteLine($"Booking {bookingID} slettet"); // Fixed variable name  
                return true;
            }
            Console.WriteLine($"Booking {bookingID} ikke fundet"); // Fixed variable name  
            return false;
        }
        #endregion

        #region RedigerBooking  
        // Rediger en booking  
        public bool EditBooking(int bookingId, BookingType newType, DateTime newStartTid,
            int newVarighed)
        {
            if (!_bookings.TryGetValue(bookingId, out var booking))
            {
                Console.WriteLine($"Booking {bookingId} ikke fundet");
                return false;
            }

            booking.Type = newType;
            booking.StartTid = newStartTid;
            booking.Varighed = newVarighed;

            Console.WriteLine($"Booking {bookingId} opdateret");
            return true;
        }
        #endregion
        
        #region Vis Bookinger
        public void VisAlleBookinger()
        {
            if (_bookings.Count == 0)
            {
                Console.WriteLine("Ingen bookinger at vise");
                return;
            }

            Console.WriteLine("\nALLE BOOKINGER:");
            Console.WriteLine("----------------------------------");
            foreach (var booking in _bookings.Values)
            {
                Console.WriteLine(booking.ToString());
                Console.WriteLine("----------------------------------");
            }
        }

        public void VisBooking(int bookingId)
        {
            if (_bookings.TryGetValue(bookingId, out var booking))
            {
                Console.WriteLine("\nBOOKING DETALJER:");
                Console.WriteLine("----------------------------------");
                Console.WriteLine(booking.ToString());
                Console.WriteLine("----------------------------------");
            }
            else
            {
                Console.WriteLine($"Booking {bookingId} ikke fundet");
            }
        }
        #endregion
    }
}
