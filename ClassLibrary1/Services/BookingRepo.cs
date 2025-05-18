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

        public Dictionary<int, Booking> AlleBokinger = new Dictionary<int, Booking>();


        /// <summary>
        /// Opretter en relavant bookning, og tilføjer den til en liste.
        /// Kaldern skal selv vælge hvilken type booking der ønskes.
        /// </summary>
        /// <param name="type"></param>
        public void OpretBooking(BookingType type, DyrRepo dyrRep)
        {
            //// ændre logikken hhv. type: Besøg eller Aktivitet
            //switch (type)
            //{
            //    //case BookingType.Besøg:

            //    //    Booking booking = new Booking(type, DateTime.Now, 1, booker);

            //    //    Console.WriteLine("Skriv Id'et på dyret du vil besøge:");
            //    //    string inputId = Console.ReadLine();
            //    //    if (int.TryParse(inputId, out int id) && dyrRep.DyrList.ContainsKey(id) && dyrRep.DyrList[id].IsBooked == false)
            //    //    {

            //    //        booking.BookedDyr = dyrRep.DyrList[id];
            //    //        dyrRep.DyrList[id].IsBooked = true;
            //    //        dyrRep.DyrList[id].Log.CreateBesøgLog(startTid, booker);

            //    //        AlleBokinger.Add(booking.BookingId, booking);// skal fikses
            //    //    }
            //    //    break;

            //    //case BookingType.Aktivitet:
            //    //    // int id;
            //    //    // do
            //    //    // {
            //    //    //    Console.WriteLine("Skriv Id'et på den Aktivitet du vil medles til:");
            //    //    // } while (!int.TryParse(Console.ReadLine(), out id));

            //    //    //if (AktivitetsRep.AlleAktiviteter.ContainsKey(id))
            //    //    //{   // her tiljøjes bookeren til aktiviteten
            //    //    //    AktivitetsRep.AlleAktiviteter[id].Tilmeldte.Add(booker);
            //    //    //    Console.WriteLine($"du er hermed tilmeldt til:\n{AktivitetsRep.AlleAktiviteter[id]}");
            //    //    //}
            //    //    //else
            //    //    //{
            //    //    //    Console.WriteLine("Aktivitet med dette Id findes ikke.");
            //    //    //}
            //    //    break;
                
            //}
            
            //else if (type == BookingType.Aktivitet)
            //{
            //    int id;
            //    do
            //    {
            //        Console.WriteLine("Skriv Id'et på den Aktivitet du vil medles til:");
            //    } while (!int.TryParse(Console.ReadLine(), out id));

            //    if (AktivitetsRep.AlleAktiviteter.ContainsKey(id))
            //    {   // her tiljøjes bookeren til aktiviteten
            //        AktivitetsRep.AlleAktiviteter[id].Tilmeldte.Add(booker);
            //        Console.WriteLine($"du er hermed tilmeldt til:\n{AktivitetsRep.AlleAktiviteter[id]}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Aktivitet med dette Id findes ikke.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Ugyldig booking type.");

            //}
            //    //Tilføjer et ID, så hvis booking.BookingId er 5, så gemmes bookingen med nummeret. 
            //    //Det sikre hurtig adgang til bookinger via et unikt ID
            //    AlleBokinger.Add(booking.BookingId, booking);
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
        {
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
        {
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
        {
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
    }
}
