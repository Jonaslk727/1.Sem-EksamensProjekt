namespace ClassLibrary1.Models
{
    public class Kunde : Person
    {
      
        public int KundeId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsPremiumMember { get; set; }
        public string Mobil { get; set; } // Added this property to fix the issue

        public string VisInfo()
        {
            return "==================================================\n" +
        $" Id: {KundeId} | Navn: {Navn} | Email: {Email} | Mobil: {Mobil}\n" +
        $" Fødselsdag: {DateOfBirth} | Registreringsdato: {RegistrationDate}\n" +
        $" Premium medlem: {IsPremiumMember}\n" +
        "==================================================\n";

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
        public Kunde()
        {

        }
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