using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Services;

namespace ClassLibrary1.Models
{
    public enum ArtType
    {
        Hund,
        Kat,
        Fugl,
    }
    public enum kønType
    {
        Hankøn,
        Hunkøn,
    }

    public class Dyr
    {
        #region Properties
        static private int _nextId = 0;
        public string Navn { get; set; } = "None";
        public ArtType Art { get; set; }
        public string Race { get; set; } = "none";
        public DateTime FødselsDag { get; set; }
        public kønType Køn { get; set; }
        public int ChipNummer { get; set; }
        public double Vægt { get; set; }
        public string Info { get; set; }
        public DyreLog Log { get; set; } = new DyreLog();

        #endregion
        public Dyr (string name, ArtType art, string race, double vægt, DateTime fødselsdag)
        {
            ChipNummer = _nextId++;
            name = Navn;
            Art = art;
            Race = race;
            FødselsDag = fødselsdag;
            Vægt = vægt;
        }
        /// <summary>
        /// Udprinter dyrets properties i en string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"===========================================================================" +
                $"Id : {ChipNummer} | Dyr: {Art} | Navn: {Navn} | Køn{Køn}" +
                $"\n Race: {Race} Fødselsdag: {FødselsDag}" +
                $"\n Mere info: {Info}"+
                "\n============================================================================ ";
        }

        /// <summary>
        /// Printer dyrets log.
        /// skriv 1, hvis du vil have hele loggen
        /// skriv 2, hvis du vil have besøg loggen
        /// skriv 3, hvis du vil have medicinsk log
        /// </summary>
        /// <returns></returns>
        public string PrintLogs(int i)
        {
           switch(i)
            {
                case 1:
                    return Log.ToString();
                case 2:
                    return Log.BesøgssLog.ToString();
                case 3:
                    return Log.MedicinskLog.ToString();
                default:
                    return "!! Ugyldigt input til parameteret i Printlog methoden i dyre classen!!";
            }
        }

    }
}
