using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace ClassLibrary1.Models
{
    public class Kunde : Person
    {// Model for kunde og den avnede arvede klasse Person
      
        public int KundeId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsPremiumMember { get; set; }
        public string Mobil { get; set; } // Added this property to fix the issue

        public string VisInfo()
        {// Meode til at vise kundens oplysninger
            return "===========================================================================" +
                $"\nId : {KundeId} | Navn: {Navn} | Email: {Email} | Mobil: {Mobil}" +
                $"\n Fødselsdag: {DateOfBirth} | Registreringsdato: {RegistrationDate}" +
                $"\n Premium medlem: {IsPremiumMember}" +
                "\n============================================================================ " +
                "\n";
            
        }

        public void OpdaterMobil(string nyMobil)
        {// Metode til at ipdatere mobilnummer
            if (!string.IsNullOrEmpty(nyMobil))
            {//Validerer at det nye nummer er gyldigt
                Mobil = nyMobil;
                Console.WriteLine($"Telefon opdateret til: {Mobil}");
            }
            else
            {
                Console.WriteLine("Ugyldigt telefonnummer!");
            }
        }
        public Kunde()
        {

        }
        public Kunde(int kundeId,string navn, string email, string mobil, DateTime dateOfBirth, DateTime registrationDate, bool isPremiumMember)
        {//Constructor til oprettelese af ny kunde
            KundeId = kundeId;
            Navn = navn;
            Email = email;
            Mobil = mobil;
            DateOfBirth = dateOfBirth;
            RegistrationDate = registrationDate;
            IsPremiumMember = isPremiumMember;
            
        }
    }
}