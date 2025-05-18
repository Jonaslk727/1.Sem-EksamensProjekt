using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Services
{
    public enum SøgDyrType
    {
        Navn,
        Id,
        Art,
    }

    public class DyrRepo
    {
        public Dictionary<int, Dyr> DyrList { get; set; } = new Dictionary<int, Dyr>();


        public void Create()
        {   // input til dyrets navn
            Console.WriteLine("Indtast dyrets navn:");
            string navn = Console.ReadLine();
            // indput til dyrets Art
            string artInput;
            string kønInput;
            ArtType artType;
            kønType køn = default;
            do
            {
                Console.WriteLine("Indtast dyrets art (Hund, Kat, Fugl):");
                artInput = Console.ReadLine();
                Console.WriteLine("Indtast dyrets Køn (Hankøn / Hunkøn):");
                kønInput = Console.ReadLine();

            } while (!Enum.TryParse(artInput, true, out artType) && !Enum.TryParse(kønInput, true, out køn));
            // indput til dyrets race
            Console.WriteLine("indtast dyrets race: ");
            string race = Console.ReadLine();

            // indput til dyrets vægt
            Console.WriteLine("Indtast dyrets Vægt i kg:");
            double.TryParse(Console.ReadLine(), out double vægt);
            // indput til dyrets fødselsdag
            Console.WriteLine("Indtast dyrets fødselsdag (dd/MM/yyyy):");
            DateTime.TryParse(Console.ReadLine(), out DateTime fødselsdag);

            Console.WriteLine("Indtast mere info:");
            string info = Console.ReadLine();
            // hvorfor skal jeg gøre to forskellige til for at få enum til at virke?
            Dyr nytDyr = new(navn, artType, race, vægt, fødselsdag, køn, info);
            DyrList.Add(nytDyr.ChipNummer, nytDyr);

            Console.WriteLine($"Dyr med ID {nytDyr.ChipNummer} er blevet oprettet.");
            Console.ReadKey();
        }

        public bool Delete()
        {
            Console.WriteLine("Indtast dyrets ID, som du vil slette::");
            int id = int.Parse(Console.ReadLine());

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

        /// <summary>
        /// En søge method der tager en eneum SøgeDyrType [Navn, Id, Art] 
        /// og søger via den valgte type.
        /// Det er op til kalderen at sikre et gyldigt input/parameter.
        /// <param name="type"></param>
        /// Prints Listen af dyr der matcher søgningen.
        /// </summary>
        public void Read (SøgDyrType type)
        {
            List<Dyr> dyrList = new List<Dyr>();
            switch (type)
            {
                case SøgDyrType.Navn:
                    Console.WriteLine("Indtast dyrets navn:");
                    string name = Console.ReadLine();
                    foreach (var dyr in DyrList.Values)
                    {   
                        string dyrNavn = dyr.Navn.ToLower();
                        // kikker efter om inputtet er en del af dyrets navn
                        if (dyrNavn.Contains(name.ToLower()))
                        {
                            dyrList.Add(dyr);
                        }
                    }
                    break;
                case SøgDyrType.Id:
                    Console.WriteLine("Indtast dyrets ID:");
                    int id = int.Parse(Console.ReadLine());
                    if (DyrList.ContainsKey(id))
                    {   // add dyr objektet med id til listen
                        dyrList.Add(DyrList[id]);
                    }
                    else
                    {
                        Console.WriteLine("Dyr med dette ID findes ikke.");
                    }
                    break;

                case SøgDyrType.Art:
                    Console.WriteLine("Indtast dyrets art (Hund, Kat, Fugl):");
                    string artInput = Console.ReadLine();
                    // kikker efter om input er en gyldig enum værdi
                    if (Enum.TryParse(artInput, true, out ArtType art))
                    {
                        foreach (var dyr in DyrList.Values)
                        {
                            if (dyr.Art == art)
                            {
                                dyrList.Add(dyr);
                            }
                        }
                    }
                    break;

            }
            if (dyrList.Count == 0)
            {
                Console.WriteLine("Ingen dyr fundet.");
                Console.ReadKey();
                return;
            }
            foreach (var dyr in dyrList)
            {
                Console.WriteLine(dyr);
            }
            Console.ReadKey();
        }
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
        {   // TryGetValue er en metode der kikker om id findes i dictionaryen og outputter objektet
            if (DyrList.TryGetValue(id, out Dyr dyr))
            {
                if (nyNavn != null) dyr.Navn = nyNavn;
                if (!nyArt.HasValue) dyr.Art = nyArt.Value;
                if (nyRace != null) dyr.Race = nyRace;
                if (nyVægt.HasValue) dyr.Vægt = nyVægt.Value;
                if (nyFødselsdag.HasValue) dyr.FødselsDag = nyFødselsdag.Value;
                if (!nyKøn.HasValue) dyr.Køn = nyKøn.Value;
                if (nyInfo != null) dyr.Info = nyInfo;
                return true;
            }
            return false;
        }

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
        
            

    }
}
