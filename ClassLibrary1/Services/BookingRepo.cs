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
        public void OpretBooking(BookingType type, DyrRepo dyrRep, KundeRepo kundeRep, AktivitetRepo AktivitetsRep)
        {
            //// ændre logikken hhv. type: Besøg eller Aktivitet
            Booking booking = new Booking();
            Kunde booker = new Kunde();

            switch (type)
            {
                case BookingType.Besøg:

                    string inputId;
                    int id;
                    do
                    {
                        Console.WriteLine("Skriv Id'et på dyret du vil besøge:");
                        inputId = Console.ReadLine();
                    } while (!int.TryParse(inputId, out id));

                    if (dyrRep.DyrList.ContainsKey(id) && dyrRep.DyrList[id].IsBooked == false)
                    {   // får Id på kunden
                        int bookerId;
                        
                        do
                        {
                            Console.WriteLine("Skriv Id'et på kunden der vil booke:");
                            inputId = Console.ReadLine();


                        } while (!int.TryParse(inputId, out bookerId) && kundeRep.OpenKunde(bookerId) != null);

                        booker = kundeRep.OpenKunde(bookerId);// får kunden
                        booking.BookedDyr = dyrRep.DyrList[id]; // tilføjer dyret til bookingen
                        dyrRep.DyrList[id].IsBooked = true;
                        DateTime startTid = GetDateTimeInput("Indtast dato og tid for din booking formate(dd/mm/yyyy HH:mm)");
                        dyrRep.DyrList[id].Log.CreateBesøgLog(startTid, booker);

                        AlleBokinger.Add(booking.BookingId, booking);// skal fikses
                    }
                    else
                    {
                        Console.WriteLine("Dyr med dette ID findes ikke eller er allerede booket.");
                    }
                    break;

                case BookingType.Aktivitet:

                    do
                    {
                        Console.WriteLine("Skriv Id'et på den Aktivitet du vil medles til:");
                    } while (!int.TryParse(Console.ReadLine(), out id));

                    if (AktivitetsRep.AlleAktiviteter.ContainsKey(id))
                    {   // her tiljøjes bookeren til aktiviteten
                        bool isValid = false;
                        do
                        {
                            Console.WriteLine("Skriv Id'et på kunden der vil tilmeldes til den givne Aktivitet:");
                            int.TryParse(Console.ReadLine(), out id);

                            if (kundeRep.OpenKunde(id) != null)
                            {
                                booker = kundeRep.OpenKunde(id);
                                isValid = true;
                            }
                        } while (!isValid);

                        AktivitetsRep.AlleAktiviteter[id].Tilmeldte.Add(booker);
                        Console.WriteLine($"du er hermed tilmeldt til:\n{AktivitetsRep.AlleAktiviteter[id]}");
                        //////Tilføjer et ID, så hvis booking.BookingId er 5, så gemmes bookingen med nummeret. 
                        //////Det sikre hurtig adgang til bookinger via et unikt ID
                        AlleBokinger.Add(booking.BookingId, booking);
                    }
                    else
                    {
                        Console.WriteLine("Aktivitet med dette Id findes ikke.");
                    }
                    break;

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

        public DateTime GetDateTimeInput(string prompt)
        {
            DateTime dateTime;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out dateTime))
                    break;

                Console.WriteLine("Ugyldigt format. Prøv igen.");
            }
            return dateTime;
        }
    }
}
