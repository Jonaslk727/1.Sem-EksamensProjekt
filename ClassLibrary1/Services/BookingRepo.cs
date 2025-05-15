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

        #region OpretBooking
        //Opret ny booking
        public void OpenBooking(BookingType type, DateTime startTid, int varighed, Kunde booker, DyrRepo dyrRep)
        {
            var booking = new Booking(type, startTid, varighed, booker)
            {
                BookingId = _nextId++
            };
            // ændre logikken hhv. type: Besøg eller Aktivitet
            if (type == BookingType.Besøg)
            {
                Console.WriteLine("Skriv Id'et på dyret du vil besøge:");
                string inputId = Console.ReadLine();
                if (int.TryParse(inputId, out int id) && dyrRep.DyrList.ContainsKey(id))
                {   
                    booking.BookedDyr = dyrRep.DyrList[id];
                    dyrRep.DyrList[id].IsBooked = true;
                    Bookings.Add(booking.BookingId, booking);
                }
            }
            else if (type == BookingType.Aktivitet)
            {
                Console.WriteLine("Skriv Id'et på den Aktivitet du vil medles til:");
                int.TryParse(Console.ReadLine(), out int id);
            }
            else
            {
                Console.WriteLine("Ugyldig booking type.");
                return;
                //Tilføjer et ID, så hvis booking.BookingId er 5, så gemmes bookingen med nummeret. 
                //Det sikre hurtig adgang til bookinger via et unikt ID
                _bookings.Add(booking.BookingId, booking);
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
