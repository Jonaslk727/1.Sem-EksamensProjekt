using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace ClassLibrary1.Models
{
    public class Kunde : Person
    {
        internal int Id;

        public int KundeId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsPremiumMember { get; set; }
        public string Mobil { get; set; } // Added this property to fix the issue

        public void VisInfo()
        {
            Console.WriteLine($"Kunde ID: {KundeId}");
            Console.WriteLine($"Navn: {Navn}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Telefon: {Mobil ?? "N/A"}");
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

        public Kunde(int kundeId, DateTime dateOfBirth, DateTime registrationDate, bool isPremiumMember)
        {
            KundeId = kundeId;
            DateOfBirth = dateOfBirth;
            RegistrationDate = registrationDate;
            IsPremiumMember = isPremiumMember;
        }
    }
}