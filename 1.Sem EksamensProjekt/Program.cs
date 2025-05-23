using ClassLibrary1;
using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using ClassLibrary1.View;

namespace _1.Sem_EksamensProjekt
{
    /// <summary>
    /// Hovedklasse for programmet, håndterer opstart og hovedmenu.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Global variabel til den aktuelt loggede kunde.
        /// Bliver opdateret, når en kunde logger ind.
        /// </summary>
        public static Kunde AktuelKunde = null;
        
        /// <summary>
        /// Programmet starter her. Initialiserer repositories og kører hovedmenuen.
        /// </summary>
        /// <param name="args">Kommandolinjeargumenter (ikke i brug).</param>
        static void Main(string[] args)
        {
            var DyrRep = new DyrRepo();
            var BookingRep = new BookingRepo();
            var AkRepo = new AktivitetRepo();
            var KundeRep = new KundeRepo();
            var MedarbejderRep = new MedarbejderRepo();
            //var kundeRepo = new KundeRepo();

            // Initialiserer testdata til systemet
            MogdataDyr(DyrRep);
            TestDataAktivitet(AkRepo);

            // Tilføj testdata til KundeRepo
            bool status = false;
            KundeRep.TilføjKunde(new Kunde(1, "Oliver Thune", "anders@example.com", "12345678", new DateTime(1998, 5, 14), DateTime.Now, true),status);
            KundeRep.TilføjKunde(new Kunde(2, "Marcus Zola", "jonas@example.com", "87654321", new DateTime(2002, 4, 16), DateTime.Now, false),status);

            /// <summary>
            /// Hovedmenuen kører i en loop indtil brugeren vælger at stoppe programmet.
            /// Brugeren præsenteres for forskellige valgmuligheder.
            /// </summary>
            bool kørProgram = true;
            while (kørProgram)
            {
                Console.Clear(); // Rydder konsollen for at gøre menuen mere overskuelig

                // Header Section
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=========================================");
                Console.WriteLine("           HOVEDMENU - Vælg Kategori    ");
                Console.WriteLine("=========================================");
                Console.ResetColor();

                // Menu Options
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n 1. Medarbejder Menu");
                Console.WriteLine(" 2. Kunde Menu");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n 0. Stop Program");
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("\n=========================================");
                Console.ResetColor();
                //Læser brugerens valg
                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        MedarbejderMenu(AkRepo, DyrRep, KundeRep, MedarbejderRep);
                        break;
                    case "2":
                        Console.Write("Indtast dit kunde-ID:");
                        if (int.TryParse(Console.ReadLine(), out int kundeId))
                        {
                            var kunde = KundeRep.HentKunde(kundeId);
                            if (kunde != null)
                            {
                                KundeMenu(DyrRep, BookingRep, AkRepo, KundeRep, kunde);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ingen kunde fundet med dette ID.");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ugyldigt input. Indtast et tal.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        kørProgram = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }
        }
        /// <summary>
        /// Denne metode håndterer medarbejdermenuen, hvor medarbejdere kan administrere forskellige aspekter af systemet.
        /// Menuen giver valgmuligheder for at administrere dyr, kunder, aktiviteter og medarbejdere.
        /// Brugeren navigerer gennem menuen ved at indtaste et tal, og den tilsvarende funktion kaldes.
        /// Metoden kører , indtil brugeren vælger at gå tilbage.
        /// </summary>
        static void MedarbejderMenu(AktivitetRepo AkRepo, DyrRepo dyrRep, KundeRepo kundeRep, MedarbejderRepo medarbejderRepo)
        {
            KundeMenu kundeMenu = new KundeMenu();

            medarbejderRepo.TilføjMedarbejder(new Medarbejder { MedarbejderId = 1, Navn = "Tim", Afdeling = "IT", Stilling = "Udvikler", Email = "tim@example.com", Telefonnummer = "12345678" });
            medarbejderRepo.TilføjMedarbejder(new Medarbejder { MedarbejderId = 2, Navn = "Sara Jensen", Afdeling = "HR", Stilling = "HR Chef", Email = "sara@example.com", Telefonnummer = "87654321" });

            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear();

                // Title Header
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=========================================");
                Console.WriteLine("       Medarbejder Menu - Vælg Kategori  ");
                Console.WriteLine("=========================================");

                // Section: Dyr
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 1. Dyr");

                // Section: Kunde
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 2. Kunde");

                // Section: Aktivitet
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 3. Aktivitet");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 4. Medarbejder");

                // Exit Option
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n 0. Gå tilbage");
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("\n=========================================");
                Console.ResetColor();

                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        MedarbejderDyrMenu(dyrRep);
                        break;
                    case "2":
                        kundeMenu.MedarbejderKundeMenu(kundeRep);
                        break;
                    case "3":
                        MedarbejderAktivitetMenu(AkRepo);
                        break;
                    case "4":
                        MedarbejderMedarbejderMenu(medarbejderRepo);
                        break;
                    case "0":
                        fortsæt = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }
            }
        }
        /// <summary>
        /// Denne metode håndterer medarbejdermenuen for administration af dyre.
        /// Medarbejdere kan vælge mellem oprettelse, sletning, redigering af dyr, visning af dyrelog og kommende besøg,
        /// samt søgning efter dyr. Brugeren navigerer gennem menuen ved at indtaste et nummer,
        /// hvorefter den tilsvarende funktion kaldes. Menuen kører vider, indtil brugeren vælger at gå tilbage.
        /// </summary>
        static void MedarbejderDyrMenu(DyrRepo dyrRep)
        {
            bool kørDyrMenu = true;
            while (kørDyrMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       --- Dyr Menu ---      ");
                Console.WriteLine("=====================================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Opret, slet eller rediger dyr");
                Console.WriteLine("2. Vis alle dyr");
                Console.WriteLine("3. DyreLog Menu");
                Console.WriteLine("4. Vis alle kommende Besøg" );
                Console.WriteLine("5. Søg efter dyr");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Tilbage");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("=====================================");
                Console.ResetColor();
                string dyrValg = Console.ReadLine();
                switch (dyrValg)
                {
                    case "1":
                        // vider sender til en ny menu
                        SletRedigerOpretDyrMeny(dyrRep);
                        break;
                    case "2":
                        dyrRep.PrintDyrList();
                        break;
                    case "3":
                        // videre føres til Dyrelog menu
                        dyrRep.PrintDyretsLog();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        // Vis alle kommende besøg
                        dyrRep.PrintAlleDyrsBesøg();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        // Søg efter dyr
                        SøgDyr(dyrRep);
                        break;
                    case "0":
                        kørDyrMenu = false; // Exit the animal menu
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }
            }
        }
        /// <summary>
        /// Denne metode håndterer medarbejdermenuen for dyreadministration.
        /// Medarbejdere kan vælge mellem forskellige handlinger såsom oprettelse, sletning, redigering af dyr,
        /// visning af alle dyr, adgang til dyrets log, visning af kommende besøg og søgning efter dyr.
        /// Brugeren navigerer gennem menuen ved at indtaste et nummer, hvorefter den relevante funktion kaldes.
        /// Menuen kører , indtil brugeren vælger at gå tilbage.
        /// </summary>
        static void MedarbejderAktivitetMenu(AktivitetRepo AkRepo)
        {
            bool kørAktivitetMenu = true;
            while (kørAktivitetMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       --- Aktivitet Menu ---      ");
                Console.WriteLine("=====================================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Opret, Slet eller Rediger Aktivitet");
                Console.WriteLine("2. Vis alle Aktiviteter");
                Console.WriteLine("3. Vis deltagerliste for en aktivitet");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Tilbage");
                Console.WriteLine("=====================================");
                Console.ResetColor();
                string aktivitetValg = Console.ReadLine();
                switch (aktivitetValg)
                {
                    case "1":
                        RedigerAktivitet(AkRepo);
                        break;
                    case "2":
                        VisAlleAktivitet(AkRepo);
                        break;
                    case "3":
                        AkRepo.VisDeltagerlisteForAktivitet();
                        break;
                    case "0":
                        kørAktivitetMenu = false; // Exit the activity menu
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }
            }
        }
        /// <summary>
        /// Denne metode håndterer medarbejdermenuen, hvor medarbejdere kan administrere deres kolleger.
        /// Menuen giver mulighed for at tilføje, vise, opdatere og slette medarbejdere.
        /// Brugeren navigerer gennem menuen ved at indtaste et nummer, hvorefter den relevante funktion udføres.
        /// Menuen kører , indtil brugeren vælger at gå tilbage.
        /// </summary>
        static void MedarbejderMedarbejderMenu(MedarbejderRepo repo)
        {
            bool kørMedarbejderMenu = true;
            while (kørMedarbejderMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       --- Medarbejder Menu ---      ");
                Console.WriteLine("=====================================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Tilføj medarbejder");
                Console.WriteLine("2. Vis alle medarbejdere");
                Console.WriteLine("3. Opdater medarbejder");
                Console.WriteLine("4. Slet medarbejder");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Tilbage");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("=====================================");
                Console.ResetColor();
                Console.Write("Vælg en mulighed: ");
                string medarbejderMenueValg = ValidateUserInput.GetString(Console.ReadLine());

                switch (medarbejderMenueValg)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.WriteLine("        Opret NyMedarbejder         ");
                        Console.WriteLine("=====================================");
                        Console.ResetColor();

                        Medarbejder nye = new Medarbejder();
                        int medarbejderId;

                        // ID skal være tal
                        Console.Write("ID            : ");
                        string input = ValidateUserInput.GetString(Console.ReadLine());

                        // Skal have numeric input
                        if (int.TryParse(input, out medarbejderId) )
                        {
                            nye.MedarbejderId = medarbejderId;

                            Console.Write("Navn          : "); nye.Navn = Console.ReadLine();
                            Console.Write("Afdeling      : "); nye.Afdeling = Console.ReadLine();
                            Console.Write("Stilling      : "); nye.Stilling = Console.ReadLine();
                            Console.Write("Email         : "); nye.Email = Console.ReadLine();
                            Console.Write("Telefon       : "); nye.Telefonnummer = Console.ReadLine();

                            // Only add employee when ID input is valid
                            repo.TilføjMedarbejder(nye);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Medarbejder tilføjet succesfuldt!");
                            Console.WriteLine("=====================================");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Enter et tal Id");
                            Console.ReadKey();
                        }                  
                        break;
                    case "2":
                        repo.VisMedarbejder();
                        Console.WriteLine("\nTryk på en tast for at vende tilbage...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.WriteLine("        Opdater Medarbejder           ");
                        Console.WriteLine("=====================================");
                        Console.ResetColor();

                        Console.Write("Indtast ID på medarbejder du vil opdatere: ");
                        int opdaterId = ValidateUserInput.GetInt(Console.ReadLine());

                        if (repo.FindMedarbejder(opdaterId))
                        {
                            Medarbejder opdateret = new Medarbejder { MedarbejderId = opdaterId };

                            Console.WriteLine("\nIndtast de nye oplysninger:");
                            Console.WriteLine("------------------------------------------------");
                            Console.Write("Nyt navn         : "); opdateret.Navn = Console.ReadLine();
                            Console.Write("Ny Afdeling      : "); opdateret.Afdeling = Console.ReadLine();
                            Console.Write("Ny Stilling      : "); opdateret.Stilling = Console.ReadLine();
                            Console.Write("Ny Email         : "); opdateret.Email = Console.ReadLine();
                            Console.Write("Nyt Telefonnummer: "); opdateret.Telefonnummer = Console.ReadLine();
                            Console.WriteLine("------------------------------------------------");

                            repo.OpdaterMedarbejder(opdaterId, opdateret);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Medarbejder opdateret succesfuldt!");
                            Console.WriteLine("=====================================");
                            Console.ResetColor();
                           
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n=====================================");
                            Console.WriteLine($" Ingen medarbejder fundet med ID {opdaterId}.");
                            Console.WriteLine("=====================================");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        Console.Write("Indtast ID på medarbejder du vil slette: ");
                        int sletId = ValidateUserInput.GetInt(Console.ReadLine());

                        repo.SletMedarbejder(sletId);
                        Console.ReadKey();
                        break;
                    case "0":
                        kørMedarbejderMenu = false; // Exit the employee menu
                        break;

                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }
            }
        }
        /// <summary>
        /// Denne metode håndterer kundemenuen, hvor en kunde kan interagere med systemet.
        /// Menuen giver mulighed for at besøge dyr, deltage i aktiviteter og se kommende aktiviteter.
        /// Brugeren navigerer gennem menuen ved at indtaste et nummer, hvorefter den relevante funktion udføres.
        /// Menuen kører i en løkke, indtil kunden vælger at gå tilbage.
        /// </summary>
        static void KundeMenu(DyrRepo DyrRep, BookingRepo BookingRep, AktivitetRepo AktivitetRep, KundeRepo KundeRepo, Kunde aktuelKunde)
        {
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Logget ind som: {aktuelKunde.Navn} (ID: {aktuelKunde.KundeId})");
                Console.ResetColor();
                // Title Header
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=========================================");
                Console.WriteLine("       Kunde Menu - Vælg Kategori  ");
                Console.WriteLine("=========================================");

                // Section: Dyr
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 1. Besøg Dyr");

                // Section: Aktivitet
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 2. Aktivitet");

                // Exit Option
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n 0. Gå tilbage");

                // Vis kommende aktiviteter
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n============= Min Oversigt =============");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nDine kommende aktiviteter:");

                bool harAktiviteter = false;

                foreach (var aktivitet in AktivitetRep.AlleAktiviteter.Values)
                {
                    if (aktivitet.StartTid > DateTime.Now)
                    {
                        foreach (var kunde in aktivitet.Tilmeldte)
                        {
                            if (kunde.KundeId == aktuelKunde.KundeId)
                            {
                                Console.WriteLine($"- {aktivitet.Title} ({aktivitet.StartTid:g})");
                                harAktiviteter = true;
                                break; // Stop indre loop – vi har fundet kunden
                            }
                        }
                    }
                }

                if (!harAktiviteter)
                {
                    Console.WriteLine("Ingen tilmeldte aktiviteter.");
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=========================================");
                Console.ResetColor();
                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        KDyrMenu dyrMenu = new KDyrMenu(DyrRep, BookingRep, AktivitetRep, KundeRepo);
                        dyrMenu.KundeDyrMenu(aktuelKunde);
                        break;
                    case "2":
                        KundeAktivitetMenu(DyrRep, BookingRep, AktivitetRep, KundeRepo, aktuelKunde);
                        break;
                    case "0":
                        fortsæt = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }
        }
        /// <summary>
        /// Denne metode håndterer redigering af aktiviteter i systemet.
        /// Menuen giver medarbejdere mulighed for at oprette, slette og redigere eksisterende aktiviteter.
        /// Brugeren navigerer gennem menuen ved at indtaste et nummer, hvorefter den relevante funktion udføres.
        /// Menuen kører i en løkke, indtil brugeren vælger at gå tilbage.
        /// </summary>
        static void RedigerAktivitet(AktivitetRepo AkRepo)
        {
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear();
                // Header Section
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=========================================");
                Console.WriteLine("       Rediger Aktivitet - Vælg Kategori ");
                Console.WriteLine("=========================================");
                Console.ResetColor();

                // Menu Options
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n1. Opret Aktivitet");
                Console.WriteLine("2. Slet Aktivitet");
                Console.WriteLine("3. Rediger Oprettet Aktivitet");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n0. Gå Tilbage");
                Console.ResetColor();

                Console.WriteLine("\n=========================================");
                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        OpretAktivitet(AkRepo);
                        break;
                    case "2":
                        SletAktivitet(AkRepo);
                        break;
                    case "3":
                        RedigerOprettetAktivitet(AkRepo);
                        break;
                    case "0":
                        fortsæt = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }
        }
        /// <summary>
        /// Denne metode håndterer administrationen af aktiviteter i systemet.
        /// Brugeren kan vælge at vise alle aktiviteter, oprette en ny aktivitet eller slette en eksisterende aktivitet.
        /// Menuen sikrer, at brugeren angiver gyldige input ved oprettelse af en aktivitet.
        /// Funktionen kører, indtil brugeren vælger at gå tilbage.
        /// </summary>
        public static void VisAlleAktivitet(AktivitetRepo AkRepo)
        {
            Console.WriteLine("Liste over aktiviteter:");
            var Aktiviteter = AkRepo.AlleAktiviteter;
            if (Aktiviteter.Count == 0)
            {
                Console.WriteLine("Ingen aktiviteter oprettet endnu.");
            }
            else
            {
                foreach (var aktivitet in Aktiviteter)
                {
                    Console.WriteLine(aktivitet);
                }
            }
            Console.WriteLine("Tryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
        public static void OpretAktivitet(AktivitetRepo AkRepo)
        {
            Console.WriteLine("Skriv en tittel til Aktiviteten:");
            string title = Console.ReadLine();

            bool fortsæt = false;
            int year = 0;
            string input;
            do
            {
                try
                {
                    Console.WriteLine("Skriv årstal for start tid:");
                    input = Console.ReadLine();

                    if (input != null && input.Length == 4 && int.TryParse(input, out year))
                    {
                        fortsæt = true;
                    }
                    else
                    {
                        Console.WriteLine("Ugyldigt input, prøv igen.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Skriv et gyldigt årstal");
                }
            } while (!fortsæt);

            Console.WriteLine("Indtast måned:");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast dag:");
            int day = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast time:");
            int time = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast minut:");
            int minute = int.Parse(Console.ReadLine());

            DateTime startTid = new DateTime(year, month, day, time, minute, 0);

            Console.WriteLine("Indtast slut måned:");
            int endMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast slut dag:");
            int endDay = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast slut time:");
            int endTime = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast slut minut:");
            int endMinute = int.Parse(Console.ReadLine());

            DateTime slutTid = new DateTime(year, endMonth, endDay, endTime, endMinute, 0);

            Console.WriteLine($"Start Dato: {startTid:dd-MM-yyyy HH:mm}");
            Console.WriteLine($"Slut Dato: {slutTid:dd-MM-yyyy HH:mm}");
            Console.WriteLine();
            Console.WriteLine("Skriv mere info");
            string info = Console.ReadLine();

            AkRepo.OpretAktivitet(title, startTid, slutTid, info);
            Console.WriteLine("Aktivitet oprettet");
            Console.ReadKey();
        }
        static public void SletAktivitet(AktivitetRepo AkRepo)
        {
            Console.WriteLine("Skriv ID på aktiviteten du vil slette:");
            int id = int.Parse(Console.ReadLine());
            bool slettet = AkRepo.SletAktivitet(id);
            if (slettet) {
                Console.WriteLine($"Aktivitet med ID {id} er slettet.");
            }
            else {
                Console.WriteLine($"Ingen aktivitet med ID {id} fundet.");
            }
        }
        static void RedigerOprettetAktivitet(AktivitetRepo AkRepo)
        {
            Console.Clear();
            Console.WriteLine("Indtast ID på aktivitet du vil redigere:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ugyldigt ID, prøv igen.");
                return;
            }
            if (!AkRepo.AlleAktiviteter.TryGetValue(id, out var aktivitet)) {
                Console.WriteLine("Aktivitet med ID findes ikke.");
                return;
            }
            Console.WriteLine($"Nuværende titel: {aktivitet.Title}");
            Console.Write("Ny titel: ");
            string nyTitle = Console.ReadLine();

            DateTime nyStart;
            while (true)
            {
                Console.Write("Ny startdato og tid (dd-MM-yyyy HH:mm): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out nyStart))
                    break;
                Console.WriteLine("Ugyldigt format. Prøv igen.");
            }

            DateTime nySlut;
            while (true)
            {
                Console.Write("Ny slutdato og tid (dd-MM-yyyy HH:mm): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out nySlut))
                    break;
                Console.WriteLine("Ugyldigt format. Prøv igen.");
            }

            Console.WriteLine("Nuværende beskrivelse: " + aktivitet.Beskrivelse);
            Console.Write("Ny beskrivelse: ");
            string nyBeskrivelse = Console.ReadLine();

            bool succes = AkRepo.RedigerAktivitet(id, nyTitle, nyStart, nySlut, nyBeskrivelse);

            if (succes)
                Console.WriteLine("Aktivitet er blevet opdateret!");
            else
                Console.WriteLine("Noget gik galt under opdatering.");
                Console.WriteLine("Tryk på en tast for at fortsætte...");
                Console.ReadKey();
        }
        #region Dyr
        /// <summary>
        /// Denne metode håndterer forskellige dyreadministrationsfunktioner,
        /// såsom oprettelse, sletning, redigering og søgning efter dyr.
        /// Brugeren navigerer gennem menuen ved at indtaste et nummer, hvorefter den relevante funktion udføres.
        /// Menuen kører i en løkke, indtil brugeren vælger at gå tilbage.
        /// </summary>
            static void SletRedigerOpretDyrMeny(DyrRepo dyrRep)
        {
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("==========================================");
                Console.WriteLine("Rediger Dyr - vælge en kategori:");
                Console.WriteLine("==========================================");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Opret et dyr");
                Console.WriteLine("2. Slet dyr");
                Console.WriteLine("3. Rediger et oprettet dyr");
                Console.WriteLine("5. Søg efter dyr");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Gå tilbage");
                Console.ResetColor();

                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        dyrRep.Create();
                        Console.Clear();
                        break;
                    case "2":
                        dyrRep.Delete();
                        Console.Clear();
                        break;
                    case "3":
                        Updater(dyrRep);
                        Console.Clear();
                        break;
               
                    case "5":
                        SøgDyr(dyrRep);
                        Console.Clear();
                        break;
                    case "0":
                        fortsæt = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }
        }
        /// <summary>
        /// Denne metode håndterer søgning efter dyr baseret på navn, ID eller art.
        /// Brugeren vælger en søgemetode, hvorefter systemet udfører den relevante søgefunktion.
        /// </summary>
        static void SøgDyr(DyrRepo dyrRep)
        {   
            Console.WriteLine("Søg efter dyr:");
            Console.WriteLine("1. Søg efter navn");
            Console.WriteLine("2. Søg efter ID");
            Console.WriteLine("3. Søg efter art");
            
            string valg = Console.ReadLine();
            Console.WriteLine();

            switch (valg)
            {
                case "1":
                    dyrRep.Søg(SøgDyrType.Navn);
                    break;
                case "2":
                    dyrRep.Søg(SøgDyrType.Id);
                    break;
                case "3":
                    dyrRep.Søg(SøgDyrType.Art);
                    break;
                
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ugyldigt valg, prøv igen.");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
            }
        }
        /// <summary>
        /// Kundeaktivitetsmenuen giver kunden mulighed for at se kommende aktiviteter,
        /// tilmelde sig, se tilmeldte aktiviteter og afmelde sig fra en aktivitet.
        /// Menuen kører i en løkke, indtil kunden vælger at gå tilbage.
        /// </summary>
        static void KundeAktivitetMenu(DyrRepo DyrRep, BookingRepo BookingRep, AktivitetRepo AktivitetRep, KundeRepo KundeRepo, Kunde aktuelKunde)
        {
            bool fortsæt = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("==========================================");
                Console.WriteLine("               Besøg en aktivitet");
                Console.WriteLine("==========================================");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. hvis alle kommende aktiviteter:");
                Console.WriteLine("2. tilmeld en aktivitet:");
                Console.WriteLine("3. Se tilmeldte aktiviteter");
                Console.WriteLine("4. Afmeld aktivitet");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Gå Tilbage");
                Console.ResetColor();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        VisAlleAktivitet(AktivitetRep);
                        break;
                    case "2":
                        BookingRep.OpretAktivitetsBookingMedKunde(AktivitetRep, aktuelKunde);
                        break;
                    case "3":
                        AktivitetRep.VisBookedeAktiviteter();
                        Console.WriteLine("\nTryk en tast for at gå tilbage...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Write("Indtast ID på aktivitet du vil afmelde: ");
                        if (!int.TryParse(Console.ReadLine(), out int aktivitetId))
                        {
                            Console.WriteLine("Ugyldigt ID.");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Indtast dit kunde-ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int kundeId))
                        {
                            Console.WriteLine("Ugyldigt kunde-ID.");
                            Console.ReadKey();
                            break;
                        }
                        bool afmeldt = AktivitetRep.AfmeldAktivitet(aktivitetId, aktuelKunde.KundeId);

                        if (afmeldt)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Du er nu afmeldt fra aktiviteten.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Kunne ikke finde aktivitet eller kunde.");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Tryk på en tast for at fortsætte...");
                        Console.ReadKey();
                        break;
                    case "0":
                        fortsæt = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            } while (fortsæt);
        }
        /// <summary>
        /// Denne metode håndterer opdatering af information for et eksisterende dyr.
        /// Brugeren indtaster dyrets ID, hvorefter systemet søger efter Id.
        /// Hvis dyret findes, kan brugeren ændre dets navn, art, køn, race, vægt, fødselsdato og info.
        /// Systemet sikrer, at gyldige værdier indtastes, og opdateringen gennemføres kun, hvis input er korrekte.
        /// </summary>
        static void Updater(DyrRepo dyrRep)
        {
            Console.WriteLine("Indtast ID på dyret du vil redigere:");
            if (!int.TryParse(Console.ReadLine(), out int id)) // prøver at parse id'et til int
            {
                Console.WriteLine("Ugyldigt ID, prøv igen.");
                Console.ReadKey();
                return;
            }
            if (!dyrRep.DyrList.TryGetValue(id, out var dyr)) // prøver at finde dyret i listen
            {
                Console.WriteLine("Dyr med ID findes ikke.");
                Console.ReadKey();
                return;
            }
            // input til dyrets navn
            Console.WriteLine("kun indtast noget hvis du vil ændre det ellers tryk enter");
            Console.WriteLine($"Nuværende navn: {dyr.Navn}");
            Console.WriteLine("Indtast det nye navn:");
            string navn = Console.ReadLine();
            // indput til dyrets Art
            // baggrund for at tillade null er at update kikker efter om et parameter er null 
            // og hvis det er så ændres det ikke
            string artInput;
            string kønInput;
            kønType køn = default;
            ArtType artType;
            do
            {
                Console.WriteLine($"Nuværende art: {dyr.Art}");
                Console.WriteLine("Indtast dyrets nye art (Hund, Kat, Fugl):");
                artInput = Console.ReadLine();

            } while (!Enum.TryParse(artInput, true, out artType));
            // input til dyrets køn
            do
            {
                Console.WriteLine($"Nuværende Køn: {dyr.Køn}");
                Console.WriteLine("Indtast dyrets nye Køn (Hankøn / Hunkøn):");
                kønInput = Console.ReadLine();

            } while (!Enum.TryParse(kønInput, true, out køn));

            // indput til dyrets race
            Console.WriteLine($"Dyrets nuværende race: {dyr.Race}");
            Console.WriteLine("indtast dyrets nye race: ");
            string race = Console.ReadLine();

            // indput til dyrets vægt
            Console.WriteLine($"Dyrets nuværende vægt: {dyr.Vægt} kg");
            Console.WriteLine("Indtast dyrets nye Vægt i kg:");
            double.TryParse(Console.ReadLine(), out double vægt);
            // indput til dyrets fødselsdag
            Console.WriteLine($"Dyrets nuværende fødselsdag: {dyr.FødselsDag:dd-MM-yyyy}");
            Console.WriteLine("Indtast dyrets nye fødselsdag (dd/MM/yyyy):");
            DateTime.TryParse(Console.ReadLine(), out DateTime fødselsdag);

            Console.WriteLine($"Dyrets nuværende ínfo: {dyr.Info}");
            Console.WriteLine("Indtast ny info:");
            string info = Console.ReadLine();

            if (!dyrRep.Update(id, navn, artType, race, vægt, fødselsdag, køn, info)) {
                Console.WriteLine("noget gik galt");
                Console.ReadKey();
            }
            else {
                Console.WriteLine("Dyret er blevet opdateret!");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Initialiserer testdata for dyr, aktiviteter og kunder i systemet.
        ///  `MogdataDyr(DyrRepo DyrRep)`: Tilføjer en liste over testdyr til dyrelisten.
        ///  `TestDataAktivitet(AktivitetRepo repo)`: Opretter testaktiviteter med titler, start- og sluttidspunkter.
        ///  `TestDataKunder(KundeRepo kundeRepo)`: Registrerer eksemplariske kunder med ID, navn, email og registreringsdato.
        /// Disse metoder bruges til at fylde systemet med eksempler, så funktionaliteter kan testes korrekt.
        /// </summary>
        static void MogdataDyr(DyrRepo DyrRep)
        {
            List<Dyr> dyrList = new List<Dyr>()
            {
                new Dyr("Max", ArtType.Hund, "Labrador", 30, new DateTime(2020, 5, 1), kønType.Hankøn, "Venlig hund"),
                new Dyr("Bella", ArtType.Kat, "Perser", 5, new DateTime(2021, 3, 15), kønType.Hunkøn, "Legesyg kat"),
                new Dyr("Charlie", ArtType.Fugl, "Parakit", 0.5, new DateTime(2022, 8, 10), kønType.Hankøn, "Sangfugl"),
                new Dyr("Luna", ArtType.Hund, "Schæfer", 35, new DateTime(2019, 11, 20), kønType.Hunkøn, "Intelligent hund"),
                new Dyr("Oliver", ArtType.Kat, "Maine", 7, new DateTime(2020, 1, 5), kønType.Hankøn, "Nysgerrig kat"),
                new Dyr("Coco", ArtType.Hund, "Chihuahua", 3, new DateTime(2022, 6, 30), kønType.Hunkøn, "Lille og sød"),
                new Dyr("Rocky", ArtType.Hund, "Bulldog", 25, new DateTime(2018, 4, 12), kønType.Hankøn, "Stærk og venlig"),
            };
            for (int i = 0; i < dyrList.Count(); i++)
            {
                DyrRep.DyrList.Add(dyrList[i].ChipNummer, dyrList[i]);
            }
        }
        public static void TestDataAktivitet(AktivitetRepo repo)
        {
            string Title1 = "Hundetræning";
            DateTime StartTid1 = new(2025, 10, 1, 10, 0, 0);
            DateTime SlutTid1 = new(2025, 10, 1, 12, 0, 0);
            string info1 = "Træning for hunde og ejere";
            repo.OpretAktivitet(Title1, StartTid1, SlutTid1, info1);

            string Title2 = "Katteyoga";
            DateTime StartTid2 = new(2025, 11, 5, 14, 30, 0);
            DateTime SlutTid2 = new(2025, 11, 5, 15, 30, 0);
            string info2 = "Afslapning og leg med katte";
            repo.OpretAktivitet(Title2, StartTid2, SlutTid2, info2);
        }
        #endregion
        #region Nyttige metoder
        /// <summary>
        /// Denne metode håndterer brugerinput til dato og tid.
        /// Brugeren bliver bedt om at indtaste en dato med et angivet prompt.
        /// Systemet validerer inputformatet og gentager anmodningen, hvis input er ugyldigt.
        /// Metoden fortsætter, indtil et gyldigt datoformat er indtastet, hvorefter værdien returneres.
        /// </summary>
        public static DateTime GetDateTimeInput(string prompt)
        {
            DateTime dateTime;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out dateTime)) 
                    break;

                Console.WriteLine("Ugyldigt format. Prøv igen.");
            }
            return dateTime;
        }
    }
}
            #endregion