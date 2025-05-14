using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    enum ArtType
    {
        Hund,
        Kat,
        Fugl,
    }
    enum kønType
    {
        Hankøn,
        Hunkøn,
    }

    public class Dyr
    {
        #region Properties
        public int Id { get; }
        public string Navn { get; set; } = "None";
        public ArtType Art { get; set; }
        public string Race { get; set; } = "none";
        public DateTime FødselsDag { get; set; }
        public kønType Køn { get; set; }
        public int ChipNummer { get; set; }
        public double Vægt { get; set; }

        #endregion
        public Dyr(string name, ArtType art, string race, DateTime fødselsdag)
        {

        }

        public override string ToString()
        {
            return $"{}{}{}{}{}{}"
        }

    }
}
