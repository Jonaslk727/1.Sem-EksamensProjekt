using ClassLibrary1.Models; //Så vi kan tilgå vores model klasser

namespace ClassLibrary1.Services
{
    /// <summary>
    /// Dele af denne klasse er lavet ved hjælp af vores egen udarbejdet 3. Obligatoriske opgave
    /// Klasse: AktivitetRepo  
    /// Håndterer administration af aktiviteter, herunder oprettelse, sletning,  
    /// redigering og visning af bookede aktiviteter.  
    /// Understøtter funktionalitet til afmelding og deltagerstyring.  
    /// </summary>
    public class AktivitetRepo
    {
        /// Dictionary til at lagre alle aktiviteter med deres unikke ID.
        public Dictionary<int, Aktivitet> AlleAktiviteter = new Dictionary<int, Aktivitet>();

        /// Opretter en ny aktivitet og tilføjer den til systemet.
        public bool OpretAktivitet(string Title, DateTime start, DateTime slut, string beskrivelse)
        {
            Aktivitet n = new(Title, start, slut, beskrivelse);
            AlleAktiviteter.Add(n.AktivitetID, n);
            return true;
        }
        /// Sletter en aktivitet baseret på ID.
        public bool SletAktivitet(int id)
        {
            foreach (var aktivitet in AlleAktiviteter)
            {
                if (aktivitet.Key == id)
                {
                    AlleAktiviteter.Remove(id);
                    Console.WriteLine("Aktiviteten blev slettet");
                    return true;
                }
            }
            Console.WriteLine("Ingen aktivitet med dette ID");
            return false;
        }
       /// Viser alle bookede aktiviteter i systemet.
        public void VisBookedeAktiviteter()
        {
            Console.WriteLine("=== Bookede Aktiviteter ===");
            bool found = false;

            foreach (var aktivitet in AlleAktiviteter.Values)
            {
                if (aktivitet.IsBooked)
                {
                    Console.WriteLine(aktivitet.ToString());
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Ingen aktiviteter er booket endnu.");
        }
        //Bruges i Program.cs til at afmelde en aktivitet
        public bool AfmeldAktivitet(int aktivitetId, int kundeId)
        {
            if (AlleAktiviteter.TryGetValue(aktivitetId, out var aktivitet))
            {
                Kunde kundeAtFjerne = null;

                foreach (var k in aktivitet.Tilmeldte)
                {
                    if (k.KundeId == kundeId)
                    {
                        kundeAtFjerne = k;
                        break;
                    }
                }
                if (kundeAtFjerne != null)
                {
                    aktivitet.Tilmeldte.Remove(kundeAtFjerne);
                    return true;
                }
            }
            return false;
        }
        /// Redigerer en aktivitet baseret på ID.
        public bool RedigerAktivitet(int id, string nyTitle, DateTime nyStart, DateTime nySlut, string nyBeskrivelse)
        {
            if (AlleAktiviteter.TryGetValue(id, out Aktivitet aktivitet))
            {
                aktivitet.Title = nyTitle;
                aktivitet.StartTid = nyStart;
                aktivitet.SlutTid = nySlut;
                aktivitet.Beskrivelse = nyBeskrivelse;
                return true;
            }
            return false;
        }
        /// Viser deltagerlisten for en aktivitet baseret på ID.
        public void VisDeltagerlisteForAktivitet()
        {
            Console.Write("Indtast ID på aktiviteten: ");
            if (!int.TryParse(Console.ReadLine(), out int aktivitetId))
            {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            if (!AlleAktiviteter.TryGetValue(aktivitetId, out var aktivitet))
            {
                Console.WriteLine("Aktivitet med det ID findes ikke.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nDeltagere for '{aktivitet.Title}':");

            if (aktivitet.Tilmeldte.Count == 0)
            {
                Console.WriteLine("Ingen tilmeldte deltagere.");
            }
            else
            {
                foreach (var kunde in aktivitet.Tilmeldte)
                    Console.WriteLine($"- {kunde.Navn} (ID: {kunde.KundeId}, Email: {kunde.Email})");
            }
            Console.ResetColor();
            Console.WriteLine("\nTryk på en tast for at vende tilbage...");
            Console.ReadKey();
        }
    }
}
