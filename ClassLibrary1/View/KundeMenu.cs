using ClassLibrary1.Models;

namespace ClassLibrary1.View
{
    /// <summary>
    /// Klasse der håndterer kundeadministration for medarbejdere.
    /// Tillader oprettelse, visning, opdatering og sletning af kunder.
    /// </summary>
    public class KundeMenu
    {
        private string Mobil;

        public void MedarbejderKundeMenu(KundeRepo kundeRep)
        {
            bool kørKundeMenu = true;
            while (kørKundeMenu)
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
                        try { 
                                Console.Write("ID        : "); ny.KundeId = int.Parse(Console.ReadLine());
                            Console.Write("Navn          : "); ny.Navn = Console.ReadLine();
                            Console.Write("Email         : "); ny.Email = Console.ReadLine();
                            Console.Write("Telefon       : "); ny.Mobil = int.Parse(Console.ReadLine());
                            kundeRep.TilføjKunde(ny, true);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Kunde tilføjet succesfuldt!");
                            Console.WriteLine("=====================================");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Noget gik galt i oprettelsen af Kunde");
                        }
                        break;
                    case "2":
                        kundeRep.VisKunder();// Vis alle kunder
                        break;
                    case "3":
                        // Opdater kunde
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n=====================================");
                        Console.WriteLine("        Opdater Kunde           ");
                        Console.WriteLine("=====================================");
                        Console.ResetColor();

                        Console.Write("Indtast ID på Kunde du vil opdatere: ");
                        int opdaterId = int.Parse(Console.ReadLine());

                        if (kundeRep.FindKunde(opdaterId))
                        {
                            Kunde opdateret = kundeRep.HentKunde(opdaterId); // Fix: Retrieve the 'opdateret' object from the repository

                            Console.WriteLine("\nIndtast de nye oplysninger:");
                            Console.WriteLine("------------------------------------------------");
                            Console.Write("Nyt navn         : "); opdateret.Navn = Console.ReadLine();
                            Console.Write("Ny Email         : "); opdateret.Email = Console.ReadLine();
                            Console.Write("Nyt Telefonnummer: ");
                            opdateret.Mobil = int.Parse(Console.ReadLine());
                            Console.WriteLine("------------------------------------------------");

                            // Fix for CS1503: Convert 'opdateret.Mobil' from int to string before passing it to the method
                            kundeRep.OpdaterKunde(opdateret.KundeId, opdateret.Navn, opdateret.Email, opdateret.Mobil.ToString());
                           
 
                            Console.Write("Nyt Telefonnummer: ");
                            opdateret.Mobil = ValidateUserInput.GetInt(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Kunde opdateret succesfuldt!");
                            Console.WriteLine("=====================================");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n=====================================");
                            Console.WriteLine($" Ingen Kunde fundet med ID {opdaterId}.");
                            Console.WriteLine("=====================================");
                            Console.ResetColor();
                        }
                        break;

                    case "4":
                        // Slet kunde
                        Console.Write("Indtast ID på Kunde du vil slette: ");
                        int sletId = int.Parse(Console.ReadLine());
                        kundeRep.SletKunde(sletId);
                        break;

                    case "0":
                        kørKundeMenu = false; //forlad kunde menuen
                        break;

                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }
            }
        }

        public void OpdaterMobil(string nyMobil)
        {
            if (!string.IsNullOrEmpty(nyMobil))
            {
                Mobil = nyMobil;
                Console.WriteLine($"Telefon opdateret til: {Mobil}");
            }
            else
            {
                Console.WriteLine("Ugyldigt telefonnummer!");
            }
        }

    }
}