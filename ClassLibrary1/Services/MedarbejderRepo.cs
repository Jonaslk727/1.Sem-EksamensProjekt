using System;
using System.Collections.Generic;
using ClassLibrary1.Models;
using ClassLibrary1.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary1.Repositories
{
    public class MedarbejderRepo : IMedarbejder
    {
        private List<Medarbejder> medarbejdere = new List<Medarbejder>();

        public void TilføjMedarbejder(Medarbejder medarbejder)
        {
            medarbejdere.Add(medarbejder);
        }

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

        public bool FindMedarbejder(int medarbejderId)
        {
            foreach (Medarbejder medarbejder in medarbejdere)
            {
                if (medarbejder.MedarbejderId == medarbejderId)
                {
                    return true;
                }
            }
            return false;
        }

        public void OpdaterMedarbejder(int medarbejderId, Medarbejder opdateretMedarbejder)
        {
            foreach (Medarbejder medarbejder in medarbejdere)
            {
                if (medarbejder.MedarbejderId == medarbejderId)
                {
                    medarbejder.Navn = opdateretMedarbejder.Navn;
                    medarbejder.Afdeling = opdateretMedarbejder.Afdeling;
                    medarbejder.Stilling = opdateretMedarbejder.Stilling;
                    medarbejder.Email = opdateretMedarbejder.Email;
                    medarbejder.Telefonnummer = opdateretMedarbejder.Telefonnummer;
                    break;
                }
            }

        }
        public void SletMedarbejder(int medarbejderId)
        {
            for (int i = 0; i < medarbejdere.Count; i++)
            {
                if (medarbejdere[i].MedarbejderId == medarbejderId)
                {
                    medarbejdere.RemoveAt(i);
                    break;
                }
            }
        }

        public List<Medarbejder> HentAlleMedarbejdere()
        {
            return medarbejdere;
        }
    }
}
