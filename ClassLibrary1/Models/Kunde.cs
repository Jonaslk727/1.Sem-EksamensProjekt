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
       
        public Kunde()
        {

        }

        /// Konstruktør til oprettelse af en kunde med specifikke oplysninger.
        public Kunde(int kundeId, string navn, string email, int mobil, DateTime dateOfBirth, DateTime registrationDate, bool isPremiumMember)
        {
            KundeId = kundeId;
            Navn = navn;              // from base class Person
            Email = email;            // from base class Person
            Mobil = mobil;            // from base class Person

            DateOfBirth = dateOfBirth;
            RegistrationDate = registrationDate;
            IsPremiumMember = isPremiumMember;
        }



    }
}