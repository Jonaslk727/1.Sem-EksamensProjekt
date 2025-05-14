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

        public override string ToString()
        {
            return $"===========================================================================" +
                $"Id : {ChipNummer} | Dyr: {Art} | Navn: {Navn} | Køn{kø}" +
                $"\n Race: {Race} Fødselsdag: {FødselsDag}" +
                $"\n Mere info: {Info}"+
                "\n============================================================================ ";
        }

        public string PrintLogs()
        {
            // Kald på funktionalitet i DyreLog klassen
            return ;
        }

    }
}
