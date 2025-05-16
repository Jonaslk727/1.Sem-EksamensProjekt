using System.Runtime.InteropServices;
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
            TestDataAktivitet(AkRepo);
            #region Hovedmenu
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
                Console.ResetColor();

                Console.WriteLine("\n=========================================");

                //Læser brugerens valg
                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        //Kalder medarbejdermenuen hvis brugeren vælger 1
                        MedarbejderMenu(AkRepo, DyrRep);
                        break;
                    case "2":
                        //Kalder kundemenuen hvis brugeren vælger 2
                        KundeMenu();
                        break;
                    case "0":
                        //Stopper programmet hvis brugeren vælger 0
                        kørProgram = false;
                        break;
                    default:
                        //Fejlhåndtering hvis input er ugyldigt
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        Console.ReadKey(); //Venter på brugerens input før den fortsætter
                        Console.ResetColor();
                        break;
                }
            }
            #endregion
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
                Console.ResetColor();

                // Section: Dyr
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n Dyr");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  1. Se oprettede dyr");
                Console.WriteLine("  2. Opret, slet eller rediger");

                // Section: Kunde
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n Kunde");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  3. Se oprettede kunder");
                Console.WriteLine("  4. Se kommende besøg");
                Console.WriteLine("  5. Opret, slet eller rediger");

                // Section: Aktivitet
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n Aktivitet");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  6. Se oprettede aktiviteter og deltagere");
                Console.WriteLine("  7. Opret, slet eller rediger");
                Console.WriteLine("  8. Medarbejder management");

                // Exit Option
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n 0. Gå tilbage");
                Console.ResetColor();

                Console.WriteLine("\n=========================================");

                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        // Se oprettede dyr
                        dyrRep.PrintDyrList();
                        break;
                    case "2":
                        // Opret, slet eller rediger dyr
                        SletRedigerOpretDyrMeny(dyrRep);
                        break;
                    case "3":
                        // Se oprettede kunder
                        bool kør = true;
                        while (kør)
                        {
                            Console.WriteLine("\n=====================================");
                            Console.WriteLine("       --- Kunde Menu ---      ");
                            Console.WriteLine("=====================================");
                            Console.WriteLine("1. Tilføj Kunder");
                            Console.WriteLine("2. Vis alle Kunder");
                            Console.WriteLine("3. Opdater Kunder");
                            Console.WriteLine("4. Slet Kunder");
                            Console.WriteLine("5. Tilbage");
                            Console.WriteLine("=====================================");
                            Console.Write("Vælg en mulighed: ");
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

                    case "4":
                        // Se kommende besøg
                        break;
                    case "5":
                        // Opret, slet eller rediger kunde
                        break;
                    case "6":
                        VisAlleAktivitet(AkRepo);
                        break;
                    case "7":
                        RedigerAktivitet(AkRepo);
                        break;
                    case "8":
                       
                        bool kør = true;
                        while (kør)
                        {
                            Console.WriteLine("\n=====================================");
                            Console.WriteLine("       --- Medarbejder Menu ---      ");
                            Console.WriteLine("=====================================");
                            Console.WriteLine("1. Tilføj medarbejder");
                            Console.WriteLine("2. Vis alle medarbejdere");
                            Console.WriteLine("3. Opdater medarbejder");
                            Console.WriteLine("4. Slet medarbejder");
                            Console.WriteLine("5. Tilbage");
                            Console.WriteLine("=====================================");
                            Console.Write("Vælg en mulighed: ");
                            string medarbejderValg = Console.ReadLine();

                            switch (medarbejderValg)
                            {
                                case "1":
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n=====================================");
                                    Console.WriteLine("        Opret Ny Medarbejder         ");
                                    Console.WriteLine("=====================================");
                                    Console.ResetColor();

                                    Medarbejder ny = new Medarbejder();

                                    Console.Write("ID            : "); ny.MedarbejderId = int.Parse(Console.ReadLine());
                                    Console.Write("Navn          : "); ny.Navn = Console.ReadLine();
                                    Console.Write("Afdeling      : "); ny.Afdeling = Console.ReadLine();
                                    Console.Write("Stilling      : "); ny.Stilling = Console.ReadLine();
                                    Console.Write("Email         : "); ny.Email = Console.ReadLine();
                                    Console.Write("Telefon       : "); ny.Telefonnummer = Console.ReadLine();

                                    repo.TilføjMedarbejder(ny);

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

                                case "5":
                                    kør = false; // Exit the employee menu
                                    break;

                                default:
                                    Console.WriteLine("Ugyldigt valg, prøv igen.");
                                    break;
                            }
                        }
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
        
        #region MetoderTilAktivitet
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
        public static void TestDataAktivitet(AktivitetRepo repo)
        {
            string Title = "Hundetræning";
            DateTime StartTid = new(2025, 10, 1, 10, 0, 0);
            DateTime SlutTid = new(2025, 10, 1, 12, 0, 0);
            string info = "Træning for hunde og ejere";
            repo.OpretAktivitet(Title, StartTid, SlutTid, info);
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
        #endregion

        #region MetoderTilDyr
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
            string artInput;
            string kønInput;
            kønType køn = default;
            ArtType artType;
            do
            {
                Console.WriteLine($"Nuværende art: {dyr.Art}");
                Console.WriteLine("Indtast dyrets nye art (Hund, Kat, Fugl):");
                artInput = Console.ReadLine();

                Console.WriteLine($"Nuværende Køn: {dyr.Køn}");
                Console.WriteLine("Indtast dyrets nye Køn (Hankøn / Hunkøn):");
                kønInput = Console.ReadLine();

            } while (!Enum.TryParse(artInput, true, out artType) && !Enum.TryParse(kønInput, true, out køn));
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

            Console.WriteLine($"Dyrets nuværende fødselsdag: {dyr.FødselsDag}");
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

        #endregion
        static void KundeMenu()
        {
            #region KundeMenu
            //Undermenu for kunden med funktioner til se ledige dyr, booke tid og se/tilmelde aktiviteter
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear();

                // Header Section
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=========================================");
                Console.WriteLine("        REDIGER AKTIVITET - VÆLG KATEGORI ");
                Console.WriteLine("=========================================");
                Console.ResetColor();

                // Menu Options
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n 1. Opret Aktivitet");
                Console.WriteLine(" 2. Slet Aktivitet");
                Console.WriteLine(" 3. Rediger Oprettet Aktivitet");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n 0. Gå Tilbage");
                Console.ResetColor();

                Console.WriteLine("\n=========================================");

                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        // Se ledige dyr
                        break;
                    case "2":
                        // Book tid til besøg dyr
                        break;
                    case "3":
                        // Se og tilmeld kommende aktiviteter
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
            #endregion
        }
    }
}
