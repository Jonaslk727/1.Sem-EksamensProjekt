using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Models
{
    /// <summary>
    /// Klasse: Kunde  
    /// Håndterer kundeoplysninger i systemet, inklusive ID, fødselsdato,  
    /// registreringsdato, medlemsstatus og kontaktoplysninger.  
    /// Tilbyder metoder til visning og opdatering af mobilnummer.  
    /// </summary>

    public class Kunde : Person
    {
      
        public int KundeId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsPremiumMember { get; set; }
        public string Mobil { get; set; } // Added this property to fix the issue

        /// Returnerer en formateret streng med kundens oplysninger.

        public string VisInfo()
        {
            return "==================================================\n" +
        $" Id: {KundeId} | Navn: {Navn} | Email: {Email} | Mobil: {Mobil}\n" +
        $" Fødselsdag: {DateOfBirth} | Registreringsdato: {RegistrationDate}\n" +
        $" Premium medlem: {IsPremiumMember}\n" +
        "==================================================\n";

        }
        
        /// Opdaterer kundens mobilnummer, hvis det nye nummer er gyldigt.
        /// <param name="nyMobil">Det nye mobilnummer.</param>
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
        public Kunde()
        {

        }
       
        /// Konstruktør til oprettelse af en kunde med specifikke oplysninger.
        public Kunde(int kundeId,string navn, string email, string mobil, DateTime dateOfBirth, DateTime registrationDate, bool isPremiumMember)
        {
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