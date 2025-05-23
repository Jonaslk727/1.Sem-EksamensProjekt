using ClassLibrary1.Models; 

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
        /// Opretter en aktivitetsbooking for en kunde
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


        /// Henter og validerer en datoindgang fra brugeren.
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
