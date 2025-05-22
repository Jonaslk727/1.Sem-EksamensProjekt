namespace ClassLibrary1.Models
{
    /// <summary>
    /// Klasse: Medarbejder  
    /// Håndterer oplysninger om medarbejdere, herunder ID, navn,  
    /// afdeling, stilling, kontaktoplysninger og email.  
    /// Indeholder en metode til formateret visning af medarbejderdata.  
    /// </summary>
        public class Medarbejder
    {
        public string Navn { get; set; } = string.Empty;
        public int MedarbejderId { get; set; } = 0;
        public string Afdeling { get; set; } = string.Empty;
        public string Stilling { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefonnummer { get; set; } = string.Empty;

        /// <summary>
        /// Standardkonstruktør til oprettelse af en tom medarbejderprofil.
        /// </summary>

        public Medarbejder()
        {
        }
        /// Konstruktør til oprettelse af en medarbejder med specifikke oplysninger.
        public Medarbejder(string navn, int medarbejderId, string afdeling, string stilling, string email, string telefonnummer)
        {
            Navn = navn;
            MedarbejderId = medarbejderId;
            Afdeling = afdeling;
            Stilling = stilling;
            Email = email;
            Telefonnummer = telefonnummer;

        }
        /// Returnerer en formateret streng med medarbejderens oplysninger.
        public override string ToString()
        {
            return "----------------------------------\n" + // Separator line
                   "Navn      : " + Navn + "\n" +
                   "ID        : " + MedarbejderId + "\n" +
                   "Afdeling  : " + Afdeling + "\n" +
                   "Stilling  : " + Stilling + "\n" +
                   "Email     : " + Email + "\n" +
                   "Telefon   : " + Telefonnummer + "\n" +
                   "----------------------------------"; // Separator line
        }
    }
}

