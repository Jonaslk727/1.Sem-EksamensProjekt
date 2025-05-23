namespace ClassLibrary1.Models
{
    /// <summary>
    /// Klasse: Medarbejder  
    /// Arver fra `Person` og tilføjer specifikke egenskaber såsom ID, afdeling og stilling.  
    /// </summary>
    public class Medarbejder : Person //  Inherit from `Person`
    {
        public int MedarbejderId { get; set; }
        public string Afdeling { get; set; } = string.Empty;
        public string Stilling { get; set; } = string.Empty;
        public string Telefonnummer { get; set; } = string.Empty; // Mobil already exists in Person

        /// <summary>
        /// Standardkonstruktør til oprettelse af en tom medarbejderprofil.
        /// </summary>
        public Medarbejder() { }

        /// <summary>
        /// Konstruktør til oprettelse af en medarbejder med specifikke oplysninger.
        /// </summary>
        public Medarbejder(string navn, string email, int mobil, int medarbejderId,
                           string afdeling, string stilling, string telefonnummer)
            : base(navn, email, mobil) //  Call base class constructor
        {
            MedarbejderId = medarbejderId;
            Afdeling = afdeling;
            Stilling = stilling;
            Telefonnummer = telefonnummer;
        }

        /// <summary>
        /// Returnerer en formateret streng med medarbejderens oplysninger.
        /// </summary>
        public override string ToString()
        {
            return "----------------------------------\n" +
                   $"Navn      : {Navn}\n" +       //  Inherited from Person
                   $"ID        : {MedarbejderId}\n" +
                   $"Afdeling  : {Afdeling}\n" +
                   $"Stilling  : {Stilling}\n" +
                   $"Email     : {Email}\n" +     // Inherited from Person
                   $"Telefon   : {Telefonnummer}\n" +
                   "----------------------------------";
        }
    }
}