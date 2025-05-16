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
        static private int _nextId = 1;
        public bool IsBooked { get; set; } = false;
        public string Navn { get; set; } = "None";
        public ArtType Art { get; set; }
        public string Race { get; set; } = "none";
        public DateTime FødselsDag { get; set; }
        public kønType Køn { get; set; }
        public int ChipNummer { get; set; }
        public double Vægt { get; set; }
        public string Info { get; set; } = "None";
        public DyreLog Log { get; set; } = new DyreLog();

        #endregion
        public Dyr (string navn, ArtType art, string race, double vægt, DateTime fødselsdag, kønType køn, string info)
        {
            ChipNummer = _nextId++;
            Navn = navn;
            Art = art;
            Race = race;
            FødselsDag = fødselsdag;
            Vægt = vægt;
            Køn = køn;
            Info = info;

        }
        /// <summary>
        /// Udprinter dyrets properties i en string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"===========================================================================" +
                $"\nId : {ChipNummer} | Dyr: {Art} | Navn: {Navn} | Køn: {Køn}" +
                $"\n Race: {Race} | Fødselsdag: {FødselsDag} | Vægt: {Vægt} kg" +
                $"\n Mere info: {Info}"+
                "\n============================================================================ "+
                "\n";
        }!Enum.TryParse(artInput, true, out artType)

        /// <summary>
        /// Printer dyrets log.
        /// skriv 1, hvis du vil have hele loggen
        /// skriv 2, hvis du vil have besøg loggen
        /// skriv 3, hvis du vil have medicinsk log
        /// </summary>
        /// <returns></returns>
        //public string PrintLogs(int i)
        //{
        //   switch(i)
        //    {
        //        case 1:
        //            return Log.ToString();
        //        case 2:
        //            return Log.BesøgssLog.ToString();
        //        case 3:
        //            return Log.MedicinskLog.ToString();
        //        default:
        //            return "!! Ugyldigt input til parameteret i Printlog methoden i dyre classen!!";
        //    }
        //}

    }
}
