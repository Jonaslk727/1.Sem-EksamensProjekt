using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using System.Text;

namespace ClassLibrary1.Services
{
    /// <summary>
    /// Enum der definerer søgetyper for dyr.
    /// Bruges til at specificere om søgningen skal ske efter navn, ID eller art.
    /// </summary>
    public enum SøgDyrType
    {
        Navn,
        Id,
        Art,
    }

    /// <summary>
    /// Repository-klasse til håndtering af dyredata.
    /// Gemmer og administrerer en liste over dyr med unikt ID.
    /// </summary>
    public class DyrRepo
    {
        /// En dictionary der gemmer registrerede dyr med et integer ID som nøgle.
        public Dictionary<int, Dyr> DyrList { get; set; } = new Dictionary<int, Dyr>();

        /// <summary>
        /// Opretter et nyt dyr baseret på brugerinput.
        /// Validerer og konverterer brugerinput til de korrekte typer.
        /// Tilføjer det nye dyr til listen med et unikt ID.
        /// </summary>
        
        public void Create()
        {   // input til dyrets navn
            Console.WriteLine("Indtast dyrets navn:");
            string navn = ValidateUserInput.GetString(Console.ReadLine());

            // indput til dyrets Art
            Console.WriteLine("Indtast dyrets art (Hund, Kat, Fugl):");
            ArtType artType = ValidateUserInput.GetArtType(Console.ReadLine());

            // input til dyrets Køn
            Console.WriteLine("Indtast dyrets køn (Hankøn, Hunkøn):");
            kønType køn = ValidateUserInput.GetKønType(Console.ReadLine());

            // indput til dyrets race
            Console.WriteLine("indtast dyrets race: ");
            string race = ValidateUserInput.GetString(Console.ReadLine());

            // indput til dyrets vægt
            Console.WriteLine("Indtast dyrets Vægt i kg:");
            double vægt = ValidateUserInput.GetDouble(Console.ReadLine());

            // indput til dyrets fødselsdag
            Console.WriteLine("Indtast dyrets fødselsdag (dd/MM/yyyy):");
            DateTime fødselsdag = ValidateUserInput.GetDateTime(Console.ReadLine());

            // indput til dyrets info
            Console.WriteLine("Indtast mere info:");
            string info = ValidateUserInput.GetString(Console.ReadLine());

            Dyr nytDyr = new(navn, artType, race, vægt, fødselsdag, køn, info);
            DyrList.Add(nytDyr.ChipNummer, nytDyr);
            Console.WriteLine();
            Console.WriteLine($"Dyr med ID {nytDyr.ChipNummer} er blevet oprettet.");
            Console.ReadKey();
        }

        /// <summary>
        /// Sletter et dyr fra listen baseret på dets unikke ID.
        /// Informerer brugeren, hvis ID'et ikke findes.
        /// </summary>
    
        public bool Delete()
        {
            Console.WriteLine("Indtast ID'et på det dyr der skal slettes:");
            int id = ValidateUserInput.GetInt(Console.ReadLine());

            if (DyrList.ContainsKey(id))
            {
                DyrList.Remove(id);
                Console.WriteLine($"Dyr med ID {id} er blevet slettet.");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Dyr med dette ID findes ikke.");
                Console.ReadKey();
                return false;
            }
        }

        public Dyr GetDyrById(int id)
        {
            if (DyrList.TryGetValue(id, out Dyr dyr))
            {
                return dyr;
            }
            else
            {
                Console.WriteLine("Dyr med dette ID findes ikke.");
                return null;
            }
        }

        #region Søgning
        /// <summary>
        /// En søge method der tager en eneum SøgeDyrType [Navn, Id, Art] 
        /// og søger via den valgte type.
        /// Det er op til kalderen at sikre et gyldigt input/parameter.
        /// <param name="type"></param>
        /// Prints Listen af dyr der matcher søgningen.
        /// </summary>
        
         public void Søg(SøgDyrType type) {
            List<Dyr> dyrList = new List<Dyr>();
            switch (type) {
                case SøgDyrType.Navn:
                    Console.WriteLine("Indtast dyrets navn:");
                    string name = ValidateUserInput.GetString(Console.ReadLine());
                    foreach (var dyr in DyrList.Values)
                    {
                        string dyrNavn = dyr.Navn.ToLower();
                        // kikker efter om inputtet er en del af dyrets navn
                        if (dyrNavn.Contains(name.ToLower()))
                            dyrList.Add(dyr);
                    }
                    break;

                case SøgDyrType.Id:
                    Console.WriteLine("Indtast dyrets ID:");
                    int id = ValidateUserInput.GetInt(Console.ReadLine());
                    if (DyrList.ContainsKey(id))
                        dyrList.Add(DyrList[id]); // add dyr objektet med id til listen
                    else
                        Console.WriteLine("Dyr med dette ID findes ikke.");
                    break;
                case SøgDyrType.Art:
                    Console.WriteLine("Indtast dyrets art (Hund, Kat, Fugl):");
                    ArtType art = ValidateUserInput.GetArtType(Console.ReadLine());

                    foreach (var dyr in DyrList.Values)
                        if (dyr.Art == art) dyrList.Add(dyr);
                    break;
            }
            if (dyrList.Count == 0)
            {
                Console.WriteLine("Ingen dyr fundet.");
                Console.ReadKey();
                return;
            }
            foreach (var dyr in dyrList)
                Console.WriteLine(dyr);

            Console.ReadKey();
        }
        #endregion

        #region update
        /// <summary>
        /// man skal indsætte id'et på det dyr der skal ændres og de værdier der skal ændres.
        /// Du insætter derefter de værdier du vil ændre og de vil blive opdateret i objektet.
        /// Hermed behøver man ikke at indsætte alle parametre, kun dem der skal ændres.
        /// Returns true hvis det lykkedes at ændre dyret og false hvis dyret ikke findes.
        /// </summary>
        /// <param name="nyNavn"></param>
        /// <param name="nyArt"></param>
        /// <param name="nyRace"></param>
        /// <param name="nyVægt"></param>
        /// <param name="nyFødselsdag"></param>
        /// <param name="nyKøn"></param>
        /// <param name="nyInfo"></param>
        /// <returns></returns>
        public bool Update(
            int id,
            string? nyNavn = null,
            ArtType? nyArt = null,
            string? nyRace = null,
            double? nyVægt = null,
            DateTime? nyFødselsdag = null,
            kønType? nyKøn = null,
            string? nyInfo = null
            )
        {   // TryGetValue er en metode der kikker om id findes i dictionaryen og outputter objektet, hvis det er der
            if (DyrList.TryGetValue(id, out Dyr dyr))
            {
                if (nyNavn != null) dyr.Navn = nyNavn;
                // Denne update fungere ikke, kan løses men kræver at alle ArtType enum bliver sat til nullyble, som kan give en null reference exception.
                if (nyArt.HasValue) dyr.Art = nyArt.Value;
                if (nyRace != null) dyr.Race = nyRace;
                // Denne update fungere ikke, kan løses men kræver at alle ArtType enum bliver sat til nullyble, som kan give en null reference exception.
                if (nyVægt.HasValue) dyr.Vægt = nyVægt.Value;
                if (nyFødselsdag.HasValue) dyr.FødselsDag = nyFødselsdag.Value;
                if (nyKøn.HasValue) dyr.Køn = nyKøn.Value;//retet
                if (nyInfo != null) dyr.Info = nyInfo;
                return true;
            }
            return false;
        }
        #endregion

        #region Print Methods
        public void PrintDyrList()
        {

            if (DyrList.Count() == 0)
            {
                Console.WriteLine("Ingen dyr i systemet.");
            }
            else
            {
                Console.WriteLine("Dyr i systemet:");
                foreach (var dyr in DyrList.Values)
                {
                    Console.WriteLine(dyr);
                }
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Udpringter alle dyr der ikke er booket.
        /// </summary>
        public void PrintLedigeDyr()
        {
            List<Dyr> ledigeDyr = new List<Dyr>();

            foreach (var dyr in DyrList.Values)
            {
                if (dyr.IsBooked == false)
                {
                    Console.WriteLine(dyr); ;
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Spøger user om hvilken log der skal udskrives. og udskriver den valgte log.
        /// </summary>
        /// <param name="id"></param>
        public void PrintDyretsLog()
        {
            Console.WriteLine("Indtast dyrets ID:");
            int id = ValidateUserInput.GetInt(Console.ReadLine());

            if (DyrList.ContainsKey(id))
            {
                bool fortsæt = true;
                while (fortsæt)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1. Vis Dyrets LægeLog");
                    Console.WriteLine("2. Vis Dyrets BesøgsLog");
                    Console.WriteLine("3. Opret en lægeLog");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("0. Gå tilbage");
                    Console.ResetColor();
                    string valg = Console.ReadLine();
                    switch (valg)
                    {
                        case "1":
                            Console.WriteLine(DyrList[id].GetLogs(1));
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine(DyrList[id].GetLogs(2));
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.WriteLine("Indtast dato for visitationen (dd/MM/yyyy):");
                            DateTime dato = ValidateUserInput.GetDateTime(Console.ReadLine());
                            Console.WriteLine("Indtast journal:");
                            string journal = ValidateUserInput.GetString(Console.ReadLine());
                            DyrList[id].AddLægeLog(dato, journal);
                            Console.WriteLine("Læge log oprettet.");
                            Console.ReadKey();
                            break;
                        case "0":
                            fortsæt = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ugyldigt valg, prøv igen.");
                            Console.ResetColor();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Dyr med dette ID findes ikke.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Udskriver alle dyr og alle deres besøg.
        /// </summary>
        public void PrintAlleDyrsBesøg()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var dyr in DyrList.Values)
            {
                if (dyr.Log.BesøgssLogs.Count != 0)
                {
                    sb.AppendLine($"Dyr med ID {dyr.ChipNummer} har følgende besøg:");
                    sb.AppendLine(dyr.Log.GetBesøgsLog());
                }
                else
                {
                    sb.AppendLine($"Dyr med ID {dyr.ChipNummer} har ingen besøg.");
                }

            }
            Console.WriteLine(sb);
            
        }
        #endregion
    }
}
