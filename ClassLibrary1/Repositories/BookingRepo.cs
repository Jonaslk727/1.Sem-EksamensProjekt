using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models; //Model klasserne kan tilgås

namespace ClassLibrary1.Services
{
    public class BookingRepo
    {

        public Dictionary<int, Booking> AlleBokinger = new Dictionary<int, Booking>();

        public void OpretBesøgBookingMedKunde(DyrRepo dyrRep, Kunde kunde)
        {
            Booking booking = new Booking();
            string inputId;
            int id;

            // Vælg et ledigt dyr
            do
            {
                Console.WriteLine("Skriv Id'et på dyret du vil besøge:");
                inputId = Console.ReadLine();
                if (!int.TryParse(inputId, out id))
                {
                    Console.WriteLine("Du skal skrive et tal");
                    continue;
                }

                if (dyrRep.DyrList.ContainsKey(id) && dyrRep.DyrList[id].IsBooked == false)
                    break;

                Console.WriteLine("Dyr med dette Id findes ikke eller er allerede booket.");
            } while (true);

            booking.BookedDyr = dyrRep.DyrList[id];
            dyrRep.DyrList[id].IsBooked = true;

            DateTime startTid = GetDateTimeInput("Indtast dato og tid for din booking (dd/MM/yyyy HH:mm):");
            dyrRep.DyrList[id].Log.CreateBesøgLog(startTid, kunde);

            Console.WriteLine($"Succes! Du har oprettet:\n{dyrRep.DyrList[id].Log.BesøgssLogs.Last()}");

            AlleBokinger.Add(booking.BookingId, booking);
            Console.ReadKey();
        }
        public void OpretAktivitetsBookingMedKunde(AktivitetRepo aktivitetRep, Kunde kunde)
        {
            Booking booking = new Booking();
            int id;

            do
            {
                Console.WriteLine("Skriv Id'et på den aktivitet du vil tilmeldes:");
            } while (!int.TryParse(Console.ReadLine(), out id));

            if (aktivitetRep.AlleAktiviteter.ContainsKey(id))
            {
                aktivitetRep.AlleAktiviteter[id].Tilmeldte.Add(kunde);
                Console.WriteLine($"Du er hermed tilmeldt til:\n{aktivitetRep.AlleAktiviteter[id]}");

                AlleBokinger.Add(booking.BookingId, booking);
            }
            else
            {
                Console.WriteLine("Aktivitet med dette Id findes ikke.");
            }
        }

        #region SletBooking  
        // Slet en booking  
        public bool DeleteBooking(int bookingID)
        {
            if (AlleBokinger.Remove(bookingID))
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
        {// Metode til redigering af en eksisterende booking med nye oplysninger
            if (!AlleBokinger.TryGetValue(bookingId, out var booking))
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
        {// Metode til at vise alle eksisterende bookinger
            if (AlleBokinger.Count == 0)
            {
                Console.WriteLine("Ingen bookinger at vise");
                return;
            }

            Console.WriteLine("\nALLE BOOKINGER:");
            Console.WriteLine("----------------------------------");
            foreach (var booking in AlleBokinger.Values)
            {
                Console.WriteLine(booking.ToString());
                Console.WriteLine("----------------------------------");
            }
        }

        public void VisBooking(int bookingId)
        {// Metode til visning af bookingdetaljer baseret på booking-ID
            if (AlleBokinger.TryGetValue(bookingId, out var booking))
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

        public DateTime GetDateTimeInput(string prompt)
        {// Metode til at validere og indhente en korrekt dato/tid fra brugerinput
            bool isValid = true;
            DateTime dateTime = default;
            while (isValid)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out dateTime)) isValid = false;
                else { Console.WriteLine("Ugyldigt format. Prøv igen."); }
            }
            return dateTime;
        }
    }
}
