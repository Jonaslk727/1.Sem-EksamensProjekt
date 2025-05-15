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
        public void OpenBooking(BookingType type, DateTime startTid, int varighed, Kunde booker, 
            DyrRepo dyrRep, AktivitetRepo AktivitetsRep)
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
                    dyrRep.DyrList[id].Log.CreateBesøgLog(startTid, booker);
                    Bookings.Add(booking);
                }
            }
            else if (type == BookingType.Aktivitet)
            {
                int id;
                do
                {
                    Console.WriteLine("Skriv Id'et på den Aktivitet du vil medles til:");
                } while (!int.TryParse(Console.ReadLine(), out id));

                if (AktivitetsRep.AlleAktiviteter.ContainsKey(id))
                {   // her tiljøjes bookeren til aktiviteten
                    AktivitetsRep.AlleAktiviteter[id].Tilmeldte.Add(booker);
                    Console.WriteLine($"du er hermed tilmeldt til:\n{AktivitetsRep.AlleAktiviteter[id]}");
                }
            }
            else
            {
                Console.WriteLine("Ugyldig booking type.");
                return;
               
            }
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

