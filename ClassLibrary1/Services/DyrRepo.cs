using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibrary1.Models;

namespace ClassLibrary1.Services
{
    public enum SøgDyrType
    {
        Name,
        Id,
        Art,
    }

    public class DyrRepo
    {
        public Dictionary<int, Dyr> DyrList { get; set; } = new Dictionary<int, Dyr>();

        public void Create(string name, ArtType art, string race, double vægt, DateTime fødselsdag)
        {
            Dyr nytDyr = new (name, art, race, vægt, fødselsdag);
            DyrList.Add(nytDyr.ChipNummer, nytDyr);
        }

        public void Delete(int id)
        {
            if (DyrList.ContainsKey(id))
            {
                DyrList.Remove(id);
            }
            else
            {
                Console.WriteLine("Dyr med dette ID findes ikke.");
            }
        }

        /// <summary>
        /// En søge method der tager en eneum SøgeDyrType [Navn, Id, Art] 
        /// og søger via den valgte type.
        /// Det er op til kalderen at sikre et gyldigt input/parameter
        /// <param name="type"></param>
        /// <returns>List<Dyr></Dyr></returns>
        /// </summary>
        public List<Dyr> Read (SøgDyrType type)
        {
            List<Dyr> dyrList = new List<Dyr>();
            switch (type)
            {
                case SøgDyrType.Name:
                    Console.WriteLine("Indtast dyrets navn:");
                    string name = Console.ReadLine();
                    foreach (var dyr in DyrList.Values)
                    {   // kikker efter om inputtet er en del af dyrets navn
                        if (dyr.Navn.Contains(name))
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
                    else
                    {
                        Console.WriteLine("Ugyldig art indtastet.");
                    }
                    break;

                default:
                    Console.WriteLine("Ugyldig søgetype.");
                    break;

            }
            return dyrList;
        }
        /// <summary>
        /// man skal indsætte id'et på det dyr der skal ændres og de værdier der skal ændres.
        /// Du insætter derefter de værdier du vil ændre og de vil blive opdateret i objektet.
        /// Hermed behøver man ikke at indsætte alle parametre, kun dem der skal ændres.
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
                if (nyArt.HasValue) dyr.Art = nyArt.Value;
                if (nyRace != null) dyr.Race = nyRace;
                if (nyVægt.HasValue) dyr.Vægt = nyVægt.Value;
                if (nyFødselsdag.HasValue) dyr.FødselsDag = nyFødselsdag.Value;
                if (nyKøn.HasValue) dyr.Køn = nyKøn.Value;
                if (nyInfo != null) dyr.Info = nyInfo;
                return true;
            }
            return false;
        }


    }
}
