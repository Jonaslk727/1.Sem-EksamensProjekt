using ClassLibrary1.Services;
using ClassLibrary1.Models;

namespace ClassLibrary1.View
{
    public class DyrMenu
    {
        public void MedarbejderDyrMenu(DyrRepo dyrRep)
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
        public static void SletRedigerOpretDyrMeny(DyrRepo dyrRep)
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
                Console.WriteLine("4. Vis DyretLogs");
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
                    case "4":
                        dyrRep.PrintDyretsLog();
                        Console.ReadKey();
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
    }

}
