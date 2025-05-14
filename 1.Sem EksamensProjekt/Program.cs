namespace _1.Sem_EksamensProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool kørProgram = true;
            while (kørProgram)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Hovedmenu - vælge en kategori:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Medarbejder menu");
                Console.WriteLine("2. Kunde menu");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Stop program");
                Console.ResetColor();

                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        MedarbejderMenu();
                        break;
                    case "2":
                        KundeMenu();
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
        static void MedarbejderMenu()
        {
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Medarbejder menu - vælge en kategori:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dyr");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Se oprettede dyr");
                Console.WriteLine("2. Opret, slet eller rediger");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Kunde");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("3. Se oprettede kunder");
                Console.WriteLine("4. Se kommende besøg");
                Console.WriteLine("5. Opret, slet eller rediger");

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
        }
        static void KundeMenu()
        {
            bool fortsæt = true;
            while (fortsæt)
            {
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
        }
    }
}
