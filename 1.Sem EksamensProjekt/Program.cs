using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;

namespace _1.Sem_EksamensProjekt
{ //TODO: Rykke menuer til interfaces mappe
    internal class Program
    {
        static void Main(string[] args)
        {
            var DyrRep = new DyrRepo();
            var BookingRep = new BookingRepo();
            var AkRepo = new AktivitetRepo();
            MogdataDyr(DyrRep);
            TestDataAktivitet(AkRepo);
            //Hovedmenu kører i loop indtil brugeren vælger at stoppe programmet
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
                        MedarbejderMenu(AkRepo, DyrRep);
                        break;
                    case "2":
                        KundeMenu(DyrRep, BookingRep, AkRepo);
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
        static void MedarbejderMenu(AktivitetRepo AkRepo, DyrRepo dyrRep)
        {
            MedarbejderRepo repo = new MedarbejderRepo();

            repo.TilføjMedarbejder(new Medarbejder { MedarbejderId = 1, Navn = "Tim", Afdeling = "IT", Stilling = "Udvikler", Email = "tim@example.com", Telefonnummer = "12345678" });
            repo.TilføjMedarbejder(new Medarbejder { MedarbejderId = 2, Navn = "Sara Jensen", Afdeling = "HR", Stilling = "HR Chef", Email = "sara@example.com", Telefonnummer = "87654321" });

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
                        MedarbejderKundeMenu();
                        break;
                    case "3":
                        MedarbejderAktivitetMenu(AkRepo);
                        break;
                    case "4":
                        MedarbejderMedarbejderMenu();
                        break;
                    case "0":
                        fortsæt = false;
                        break;
                }
            }
        }
        static void MedarbejderDyrMenu(DyrRepo dyrRep)
        {
            bool kørDyrMenu = true;
            while (kørDyrMenu)
            {   Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       --- Dyr Menu ---      ");
                Console.WriteLine("=====================================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Opret, slet eller redigr dyr");
                Console.WriteLine("2. Vis alle dyr");
                Console.WriteLine("3. Søg efter dyr");
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
        static void MedarbejderKundeMenu()
        {
            bool kør = true;
            while (kør)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       --- Kunde Menu ---      ");
                Console.WriteLine("=====================================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Tilføj Kunder");
                Console.WriteLine("2. Vis alle Kunder");
                Console.WriteLine("3. Opdater Kunder");
                Console.WriteLine("4. Slet Kunder");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Tilbage");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("=====================================");
                Console.ResetColor();

                string kundeValg = Console.ReadLine();
                switch (kundeValg)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.WriteLine("        Opret Ny Kunde         ");
                        Console.WriteLine("=====================================");
                        Console.ResetColor();

                        Kunde ny = new Kunde();

                        Console.Write("ID            : "); ny.KundeId = int.Parse(Console.ReadLine());
                        Console.Write("Navn          : "); ny.Navn = Console.ReadLine();
                        Console.Write("Email         : "); ny.Email = Console.ReadLine();
                        Console.Write("Telefon       : "); ny.Mobil = Console.ReadLine();
                        break;
                    case "2":
                        // Vis alle kunder
                        break;
                    case "3":
                        // Opdater kunde
                        break;
                    case "4":
                        // Slet kunde
                        break;
                    case "0":
                        kør = false;
                        break;
                }
            }
        }
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
                    case "0":
                        kørAktivitetMenu = false; // Exit the activity menu
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }
            }
        }
        static void MedarbejderMedarbejderMenu()
        {
            MedarbejderRepo repo = new MedarbejderRepo();

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
                string medarbejderMenueValg = Console.ReadLine();

                switch (medarbejderMenueValg)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.WriteLine("        Opret NyMedarbejder         ");
                        Console.WriteLine("=====================================");
                        Console.ResetColor();

                        Medarbejder nye = new Medarbejder();

                        Console.Write("ID            : "); nye.MedarbejderId = int.Parse(Console.ReadLine());
                        Console.Write("Navn          : "); nye.Navn = Console.ReadLine();
                        Console.Write("Afdeling      : "); nye.Afdeling = Console.ReadLine();
                        Console.Write("Stilling      : "); nye.Stilling = Console.ReadLine();
                        Console.Write("Email         : "); nye.Email = Console.ReadLine();
                        Console.Write("Telefon       : "); nye.Telefonnummer = Console.ReadLine();

                        repo.TilføjMedarbejder(nye);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Medarbejder tilføjet succesfuldt!");
                        Console.WriteLine("=====================================");
                        Console.ResetColor();
                        break;
                    case "2":
                        repo.VisMedarbejder();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.WriteLine("        Opdater Medarbejder           ");
                        Console.WriteLine("=====================================");
                        Console.ResetColor();

                        Console.Write("Indtast ID på medarbejder du vil opdatere: ");
                        int opdaterId = int.Parse(Console.ReadLine());

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
                        }
                        break;
                    case "4":
                        Console.Write("Indtast ID på medarbejder du vil slette: ");
                        int sletId = int.Parse(Console.ReadLine());
                        repo.SletMedarbejder(sletId);
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
        static void KundeMenu(DyrRepo DyrRep, BookingRepo BookingRep, AktivitetRepo AktivitetRep)
        {
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear();

                // Title Header
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=========================================");
                Console.WriteLine("       Kunde Menu - Vælg Kategori  ");
                Console.WriteLine("=========================================");
                Console.ResetColor();

                // Section: Dyr
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 1. Besøg Dyr");

                // Section: Aktivitet
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 2. Aktivitet");
                Console.ForegroundColor = ConsoleColor.Yellow;

                // Exit Option
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n 0. Gå tilbage");
                Console.ResetColor();

                Console.WriteLine("\n=========================================");
                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        // KundeDyrMenu();
                        KundeDyrMenu(DyrRep, BookingRep, AktivitetRep);
                        break;
                    case "2":
                        // KundeAktivitetMenu();
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
        //METODER TIL FUNKTIONALITET I MENUER:
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
        static public void SletAktivitet(AktivitetRepo AkRepo)
        {
            Console.WriteLine("Skriv ID på aktiviteten du vil slette:");
            int id = int.Parse(Console.ReadLine());
            bool slettet = AkRepo.SletAktivitet(id);
            if (slettet)
            {
                Console.WriteLine($"Aktivitet med ID {id} er slettet.");
            }
            else
            {
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

            if (!AkRepo.AlleAktiviteter.TryGetValue(id, out var aktivitet))
            {
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
            {
                Console.WriteLine("Aktivitet er blevet opdateret!");
            }
            else
            {
                Console.WriteLine("Noget gik galt under opdatering.");
            }

            Console.WriteLine("Tryk på en tast for at fortsætte...");
            Console.ReadKey();
        }

        #region Dyr
        static void SletRedigerOpretDyrMeny(DyrRepo dyrRep)
        {
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Rediger Dyr - vælge en kategori:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Opret et dyr");
                Console.WriteLine("2. Slet dyr");
                Console.WriteLine("3. Rediger et oprettet dyr");
                Console.WriteLine("4. LægeLog af et dyr.");
                Console.WriteLine("5. Søg efter dyr");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Gå tilbage");
                Console.ResetColor();

                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        dyrRep.Create();
                        break;
                    case "2":
                        dyrRep.Delete();
                        break;
                    case "3":
                        Updater(dyrRep);
                        break;
                    case "4":
                        // mangler 
                        break;
                    case "5":
                        SøgDyr(dyrRep);
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
                    dyrRep.Read(SøgDyrType.Navn);
                    break;
                case "2":
                    dyrRep.Read(SøgDyrType.Id);
                    break;
                case "3":
                    dyrRep.Read(SøgDyrType.Art);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ugyldigt valg, prøv igen.");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
            }
        }

        static void KundeDyrMenu(DyrRepo DyrRep, BookingRepo BookingRep, AktivitetRepo AktivitetRep)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("               Besøg et dyr");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. hvis alle ledige dyr:");
            Console.WriteLine("2. book et besøg:");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    // viser ledige dyr
                    DyrRep.PrintLedigeDyr();
                    break;
                case "2":
                // booking logik
                    //BookingRep.OpretBooking(BookingType.Besøg, DyrRep);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ugyldigt valg, prøv igen.");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
            }
        }

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

            if (!dyrRep.Update(id, navn, artType, race, vægt, fødselsdag, køn, info))
            {
                Console.WriteLine("noget gik galt");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Dyret er blevet opdateret!");
                Console.ReadKey();
            }
        }
        //TEST DATA:
        static void MogdataDyr(DyrRepo DyrRep)
        {
            Dyr dyr1 = new Dyr("Max", ArtType.Hund, "Labrador", 30, new DateTime(2020, 5, 1), kønType.Hankøn, "Venlig hund");
            Dyr dyr2 = new Dyr("Bella", ArtType.Kat, "Perser", 5, new DateTime(2021, 3, 15), kønType.Hunkøn, "Legesyg kat");
            Dyr dyr3 = new Dyr("Charlie", ArtType.Fugl, "Parakit", 0.5, new DateTime(2022, 8, 10), kønType.Hankøn, "Sangfugl");
            DyrRep.DyrList.Add(dyr1.ChipNummer, dyr1);
            DyrRep.DyrList.Add(dyr2.ChipNummer, dyr2);
            DyrRep.DyrList.Add(dyr3.ChipNummer, dyr3);
        }
        public static void TestDataAktivitet(AktivitetRepo repo)
        {
            string Title = "Hundetræning";
            DateTime StartTid = new(2025, 10, 1, 10, 0, 0);
            DateTime SlutTid = new(2025, 10, 1, 12, 0, 0);
            string info = "Træning for hunde og ejere";
            repo.OpretAktivitet(Title, StartTid, SlutTid, info);
        }
        #endregion
    }
}
