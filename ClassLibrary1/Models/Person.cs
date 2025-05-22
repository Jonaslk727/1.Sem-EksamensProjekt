namespace ClassLibrary1.Models
{

    /// <summary>
    /// Klasse: Person  
    /// Baseklasse for medarbejdere og kunder, der indeholder fælles egenskaber  
    /// såsom navn, email og telefonnummer.  
    /// Sikrer en struktureret tilgang til datahåndtering i systemet.  
    /// </summary>


    public class Person
    {
        public string Navn { get; set; }
        public string Email { get; set; }
        public int Mobil { get; set; }

        /// Konstruktør til initialisering af en person med specifikke oplysning

        public Person(string navn, string email, int mobil)
        {
            Navn = navn;
            Email = email;
            Mobil = mobil;
        }

        /// standard tom Konstruktør til initialisering af en person 

        public Person()
        {
        }
    }
}