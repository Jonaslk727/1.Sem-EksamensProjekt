namespace _1.Sem_EksamensProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDataAktivitet(AktivitetRepo);
            #region Hovedmenu
            //Hovedmenu kører i loop indtil brugeren vælger at stoppe programmet
            bool kørProgram = true;
            while (kørProgram)
            {
                Console.Clear(); //Rydder konsollen for at gøre menuen mere overskuelig
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Hovedmenu - vælge en kategori:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Medarbejder menu");
                Console.WriteLine("2. Kunde menu");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Stop program");
                Console.ResetColor();

                //Læser brugerens valg
                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        //Kalder medarbejdermenuen hvis brugeren vælger 1
                        MedarbejderMenu();
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
        static void MedarbejderMenu()
        {
            #region MedarbejderMenu
            //Undermenu for medarbejderen med funktioner til håndtere dyr, kunder og aktiviteter
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear(); //Rydder konsollen hver gang menuen vises
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Medarbejder menu - vælge en kategori:");
                //Sektion: Dyr
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dyr");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Se oprettede dyr");
                Console.WriteLine("2. Opret, slet eller rediger");
                //Sektion: Kunde
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Kunde");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("3. Se oprettede kunder");
                Console.WriteLine("4. Se kommende besøg");
                Console.WriteLine("5. Opret, slet eller rediger");
                //Sektion: Aktivitet
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Aktivitet");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("6. Se oprettede aktiviteter og deltagere");
                Console.WriteLine("7. Opret, slet eller rediger");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Gå tilbage");
                Console.ResetColor();

                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        // Se oprettede dyr
                        break;
                    case "2":
                        // Opret, slet eller rediger dyr
                        break;
                    case "3":
                        // Se oprettede kunder
                        break;
                    case "4":
                        // Se kommende besøg
                        break;
                    case "5":
                        // Opret, slet eller rediger kunde
                        break;
                    case "6":
                        // Se oprettede aktiviteter
                        break;
                    case "7":
                        // Opret, slet eller rediger aktivitet
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
                    if (input.Length != 4 || input == null)
                    {
                        Console.WriteLine("Ugyldigt input, prøv igen.");
                    }
                    year = int.Parse(input);
                    fortsæt = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ugyldigt input, prøv igen.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Skriv et gyldigt årstal");
                }
            } while (fortsæt == true);
            Console.WriteLine("Indtast måned:");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast dag:");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast time:");
            DateOnly dateOnly = new(year, month, day);

            int time = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast minut:");
            int minute = int.Parse(Console.ReadLine());
            TimeOnly timeOnly = new TimeOnly(time, minute);
            DateTime dateTime = new DateTime(dateOnly, timeOnly);
            Console.WriteLine($"Dato: {dateTime.ToString("dd-MM-yyyy HH:mm")}");
            Console.WriteLine();
            Console.WriteLine("Skriv mere info");
            string info = Console.ReadLine();
            AkRepo.OpretAktivitet(title, dateTime, info);
            Console.WriteLine("Aktivitet oprettet");
            Console.ReadKey();
        }
        public static void VisAlleAktivitet(AktivitetRepo AkRepo)
        {
            Console.WriteLine("Liste over aktiviteter:");
            var Aktiviteter = AkRepo.AlleAktiviteter;
            if(Aktiviteter.Count == 0)
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
        }
        static void KundeMenu()
        {
            #region KundeMenu
            //Undermenu for kunden med funktioner til se ledige dyr, booke tid og se/tilmelde aktiviteter
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.Clear(); //Rydder konsollen hver gang menuen vises
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Kunde menu - vælge en kategori:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Se ledige dyr");
                Console.WriteLine("2. Book tid til besøg dyr");
                Console.WriteLine("3. Se og tilmeld kommende aktiviteter");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Gå tilbage");
                Console.ResetColor();

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
