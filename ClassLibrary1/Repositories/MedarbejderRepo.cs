using ClassLibrary1.Models;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Repositories
{
    /// <summary>
    /// Repository-klasse til håndtering af medarbejdere.
    /// Implementerer IMedarbejder og administrerer en liste over medarbejdere.
    /// </summary>
    public class MedarbejderRepo : IMedarbejder
    {
        /// En liste der gemmer registrerede medarbejdere.
        /// Muliggør administration af medarbejderdata som tilføjelse, opdatering o
        private List<Medarbejder> medarbejdere = new List<Medarbejder>();
      
        //Tilføj medarbejder og tejk om den findes
        public void TilføjMedarbejder(Medarbejder medarbejder)
        {
            try
            { 
            for (int i = 0; i < medarbejdere.Count; i++)
            {
                if (medarbejdere[i].MedarbejderId == medarbejder.MedarbejderId)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n==========================================");
                    Console.WriteLine("Medarbejder findes allerede.");
                    Console.WriteLine("==========================================\n");
                    Console.ResetColor();
                    return;
                }
            }
            medarbejdere.Add(medarbejder);
            Console.WriteLine("Medarbejder tilføjet.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fejl ved tilføjelse af medarbejder: " + ex.Message);
                Console.ResetColor();
            }
        }
        // Hent medarbejder ved Id
        public void VisMedarbejder()
        {
            List<Medarbejder> medarbejdere = HentAlleMedarbejdere();

            if (medarbejdere.Count == 0)
            {
                Console.WriteLine("Ingen medarbejdere fundet.");
                return;
            }

            Console.WriteLine("\n=== Liste over medarbejdere ===");
            foreach (var medarbejder in medarbejdere)
            {
                Console.WriteLine(medarbejder);
            }
        }
        // Find medarbejder ved Id
        public bool FindMedarbejder(int medarbejderId)
        {
            foreach (Medarbejder medarbejder in medarbejdere)
            {
                if (medarbejder.MedarbejderId == medarbejderId)
                {
                    return true; // Found the employee with the given ID
                }
            }
            return false; // Employee not found
        }

        // Opdater medarbejder og tejk om den findes
        public void OpdaterMedarbejder(int medarbejderId, Medarbejder opdateretMedarbejder)
        {
            try
            {
                if (opdateretMedarbejder == null)
                {
                    Console.WriteLine("Opdateringsdata er ugyldige.");
                    return;
                }

                foreach (Medarbejder medarbejder in medarbejdere)
                {
                    if (medarbejder.MedarbejderId == medarbejderId)
                    {
                        medarbejder.Navn = opdateretMedarbejder.Navn;
                        medarbejder.Afdeling = opdateretMedarbejder.Afdeling;
                        medarbejder.Stilling = opdateretMedarbejder.Stilling;
                        medarbejder.Email = opdateretMedarbejder.Email;
                        medarbejder.Telefonnummer = opdateretMedarbejder.Telefonnummer;
                        Console.WriteLine("Medarbejder opdateret.");
                        return;
                    }
                }

                Console.WriteLine("Medarbejder ikke fundet.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fejl ved opdatering af medarbejder: " + ex.Message);
                Console.ResetColor();
            }
        }

        //slet medarbejder og tek om den findes
        public void SletMedarbejder(int medarbejderId)
        {
            try
            {
                for (int i = 0; i < medarbejdere.Count; i++)
                {
                    if (medarbejdere[i].MedarbejderId == medarbejderId)
                    {
                        medarbejdere.RemoveAt(i);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n==========================================");
                        Console.WriteLine("Medarbejder med ID " + medarbejderId + " er blevet slettet.");
                        Console.WriteLine("==========================================\n");
                        Console.ResetColor();
                        return;
                    }
                }

                Console.WriteLine("Medarbejder med ID " + medarbejderId + " blev ikke fundet.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fejl ved sletning af medarbejder: " + ex.Message);
                Console.ResetColor();
            }
        }
        // hent alle medarbejdere
        public List<Medarbejder> HentAlleMedarbejdere()
        {
            return medarbejdere;
        }
    }
}
