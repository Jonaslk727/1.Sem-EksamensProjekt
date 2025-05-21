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


        /// <summary>
        /// Opretter en relavant bookning, og tilføjer den til en liste.
        /// Kaldern skal selv vælge hvilken type booking der ønskes.
        /// </summary>
        /// <param name="type"></param>
        //public void OpretBooking(BookingType type, DyrRepo dyrRep, KundeRepo kundeRep, AktivitetRepo AktivitetsRep, Kunde aktuelKunde)
        //{
        //    //// ændre logikken hhv. type: Besøg eller Aktivitet
        //    Booking booking = new Booking();
        //    Kunde booker = new Kunde(); 

        //    switch (type)
        //    {
        //        case BookingType.Besøg:

        //            string inputId;
        //            int id;
        //            // sikre gyldigt Dyr ID
        //            do
        //            {
        //                Console.WriteLine("Skriv Id'et på dyret du vil besøge:");
        //                inputId = Console.ReadLine();
        //                if (!int.TryParse(inputId, out id)) Console.WriteLine("du skal skrive et tal");// at input er et tal
        //                else if (dyrRep.DyrList.ContainsKey(id) && dyrRep.DyrList[id].IsBooked == false) break;

        //                Console.WriteLine("Dyr med dette Id findes ikke");

        //            } while (true);

        //            // sikre gyldigt Kunde ID
        //            int bookerId;
        //            do
        //            {
        //                Console.WriteLine("Skriv Id'et på kunden der vil booke:");
        //                inputId = Console.ReadLine();
        //                if (!int.TryParse(inputId, out bookerId)) Console.WriteLine("Ugyldigt ID. Prøv igen med et nummer.");                        
        //                else if (kundeRep.HentKunde(bookerId) != null) break;
        //                // fejlmeddelelser:
        //                //else if (!int.TryParse(Console.ReadLine(), out bookerId)) Console.WriteLine("Ugyldigt ID. Prøv igen.");
        //                //else if (kundeRep.HentKunde(bookerId) == null) Console.WriteLine("Kunde med dette ID findes ikke. Prøv igen.");

        //                Console.WriteLine("Dette Id findes ikke, Prøv igen");

        //            } while (true);

        //                booker = kundeRep.HentKunde(bookerId);// får kunden
        //                booking.BookedDyr = dyrRep.DyrList[id]; // tilføjer dyret til bookingen
        //                dyrRep.DyrList[id].IsBooked = true;

        //                DateTime startTid = GetDateTimeInput("Indtast dato og tid for din booking formate(dd/mm/yyyy HH:mm)");
        //                dyrRep.DyrList[id].Log.CreateBesøgLog(startTid, booker);
        //                Console.WriteLine($"Succes Du har oprettet:\n{dyrRep.DyrList[id].Log.BesøgssLogs.Last()}");// udskriver det sidste element i besøgsloggen

        //                AlleBokinger.Add(booking.BookingId, booking);// skal fikses
        //                Console.ReadKey();  

        //        break;

        //        case BookingType.Aktivitet:
        //            do
        //            {
        //                Console.WriteLine("Skriv Id'et på den Aktivitet du vil medles til:");
        //            } while (!int.TryParse(Console.ReadLine(), out id));

        //            if (AktivitetsRep.AlleAktiviteter.ContainsKey(id))
        //            {   // her tiljøjes bookeren til aktiviteten

        //                do
        //                {
        //                    id = 0;
        //                    Console.WriteLine("Skriv Id'et på kunden der vil tilmeldes til den givne Aktivitet:");
        //                    if (!int.TryParse(Console.ReadLine(), out id)) Console.WriteLine("Du skal skrive et tal");

        //                    if (kundeRep.HentKunde(id) != null)
        //                    {
        //                        booker = kundeRep.HentKunde(id);
        //                        break;
        //                    }
        //                    Console.WriteLine("Kunde med dette ID findes ikke. Prøv igen.");

        //                } while (true);

        //                AktivitetsRep.AlleAktiviteter[id].Tilmeldte.Add(booker);
        //                Console.WriteLine($"du er hermed tilmeldt til:\n{AktivitetsRep.AlleAktiviteter[id]}");
        //                //////Tilføjer et ID, så hvis booking.BookingId er 5, så gemmes bookingen med nummeret. 
        //                //////Det sikre hurtig adgang til bookinger via et unikt ID
        //                AlleBokinger.Add(booking.BookingId, booking);
        //            } 
        //            else
        //            {
        //                Console.WriteLine("Aktivitet med dette Id findes ikke.");
        //            }
        //            break;
        //    } 
        //}
        public void OpretBooking(BookingType type, DyrRepo dyrRep, AktivitetRepo aktivitetsRep, Kunde aktuelKunde)
        {
            Booking booking = new Booking();

            switch (type)
            {
                case BookingType.Besøg:
                    int dyrId;
                    do
                    {
                        Console.WriteLine("Skriv ID på dyret du vil besøge:");
                        if (!int.TryParse(Console.ReadLine(), out dyrId))
                        {
                            Console.WriteLine("Du skal skrive et tal");
                            continue;
                        }

                        if (dyrRep.DyrList.ContainsKey(dyrId) && !dyrRep.DyrList[dyrId].IsBooked)
                            break;

                        Console.WriteLine("Dyr med dette ID findes ikke eller er allerede booket.");
                    } while (true);

                    booking.BookedDyr = dyrRep.DyrList[dyrId];
                    dyrRep.DyrList[dyrId].IsBooked = true;

                    DateTime startTid = GetDateTimeInput("Indtast dato og tid for din booking (dd/MM/yyyy HH:mm):");
                    dyrRep.DyrList[dyrId].Log.CreateBesøgLog(startTid, aktuelKunde);

                    Console.WriteLine($"Succes! Du har oprettet:\n{dyrRep.DyrList[dyrId].Log.BesøgssLogs.Last()}");

                    AlleBokinger.Add(booking.BookingId, booking);
                    Console.ReadKey();
                    break;

                case BookingType.Aktivitet:
                    int aktivitetId;
                    do
                    {
                        Console.WriteLine("Skriv ID på den aktivitet du vil tilmeldes:");
                    } while (!int.TryParse(Console.ReadLine(), out aktivitetId));

                    if (aktivitetsRep.AlleAktiviteter.ContainsKey(aktivitetId))
                    {
                        aktivitetsRep.AlleAktiviteter[aktivitetId].Tilmeldte.Add(aktuelKunde);
                        Console.WriteLine($"Du er hermed tilmeldt til:\n{aktivitetsRep.AlleAktiviteter[aktivitetId]}");
                        AlleBokinger.Add(booking.BookingId, booking);
                    }
                    else
                    {
                        Console.WriteLine("Aktivitet med dette ID findes ikke.");
                    }
                    break;
            }
        }

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
