using ClassLibrary1.Models;
using ClassLibrary1.Models.Besøg_og_lægelog;
using System.Text;

namespace ClassLibrary1.Services
{
    /// <summary>
    /// Model klasserne kan tilgås <br></br>
    /// Klasse: BookingRepo  <br></br>
    /// Håndterer bookingadministration, herunder oprettelse, sletning,<br></br>
    /// redigering og visning af bookinger.  <br></br>
    /// Understøtter både aktivitets- og besøgsspecifikke bookinger.  <br></br>
    /// </summary>
    public class BookingRepo
    {

        /// Dictionary til lagring af alle bookinger baseret på deres unikke

        public Dictionary<int, Booking> AlleBokinger = new Dictionary<int, Booking>();

        /// Opretter en besøg-booking for en kunde, der ønsker at besøge et dyr.
        public void OpretBesøgBookingMedKunde(DyrRepo dyrRep, Kunde kunde)
        {
            Booking booking = new Booking(BookingType.Besøg);
            int id;

            // Væliderer at brugeren indtaster et gyldigt heltal for dyrets Id
            Console.WriteLine("Skriv Id'et på dyret du vil besøge:");
            id = ValidateUserInput.GetInt(Console.ReadLine());
            
            // Validerer at dyret findes og ikke allerede er booket
            if (!dyrRep.DyrList.ContainsKey(id) && dyrRep.DyrList[id].IsBooked == true)
            {
                Console.WriteLine("Dyr med dette Id findes ikke eller er allerede booket.");
                Console.ReadKey();
                return;
            }   

            booking.BookedDyr = dyrRep.DyrList[id];
            dyrRep.DyrList[id].IsBooked = true;
            booking.Booker = kunde;

            Console.WriteLine("Indtast starttidspunkt for besøget (dd/mm/yyyy hh:mm):");
            DateTime startTid = ValidateUserInput.GetDateTime(Console.ReadLine());
            dyrRep.DyrList[id].Log.CreateBesøgLog(startTid, kunde);

            Console.WriteLine($"Succes! Du har oprettet:\n{dyrRep.DyrList[id].Log.BesøgssLogs.Last()}");

            AlleBokinger.Add(booking.BookingId, booking);
            Console.ReadKey();
        }
        /// Opretter en aktivitetsbooking for en kunde
        public void OpretAktivitetsBookingMedKunde(AktivitetRepo aktivitetRep, Kunde kunde)
        {
            Booking booking = new Booking(BookingType.Aktivitet);
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

        public void AfmeldBookingBesøg(DyrRepo DyrRep, Kunde aktuelKunde)
        {
            Console.WriteLine("");
            Console.WriteLine("Dine kommende DyreBesøg:");

            bool harBesøg = false; // genbruges fra ovenstående logik

            foreach (var dyr in DyrRep.DyrList.Values)
            {
                foreach (var besøg in dyr.Log.BesøgssLogs)
                {
                    if (besøg.BesøgsTidspunkt > DateTime.Now && besøg.Besøger.KundeId == aktuelKunde.KundeId)
                    {
                        Console.WriteLine($"{besøg})");
                        harBesøg = true;
                        break; // Stop indre loop – vi har fundet et kommende besøg
                    }
                }
            }
            if (!harBesøg)
            {
                Console.WriteLine("Ingen Besøg Booket.");
                Console.ReadLine();
                return;
            }
            
            Console.WriteLine("");
            Console.WriteLine("Indtast ID'et på det besøg, du vil afmelde:");
            int besøgId = ValidateUserInput.GetInt(Console.ReadLine());

            foreach (var booking in AlleBokinger.Values)
            {
                if (booking.Booker == aktuelKunde && booking.Type == BookingType.Besøg)
                {
                    foreach (var log in booking.BookedDyr.Log.BesøgssLogs)
                    {
                        if (log.BesøgsId == besøgId)
                        {
                            // Fjern besøget fra dyrets log
                            booking.BookedDyr.Log.BesøgssLogs.Remove(log);
                            booking.BookedDyr.IsBooked = false; // Opdaterer dyrets status
                            
                            // Fjern bookingen fra vores dictionary
                            AlleBokinger.Remove(booking.BookingId);
                            
                            Console.WriteLine($"Besøget med ID {besøgId} er nu afmeldt.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
            }


        }

    }
}
