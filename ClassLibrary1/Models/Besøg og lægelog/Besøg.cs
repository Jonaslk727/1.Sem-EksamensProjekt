using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models.Besøg_og_lægelog
{
    public class Besøg
    {
        public DateTime BesøgsTidspunkt { get; set; }
        public Kunde Besøger { get; set; }
        public int BesøgsId { get; set; }

        public Besøg(DateTime besøgsTidspunkt, Kunde besøger)
        {
            BesøgsTidspunkt = besøgsTidspunkt;
            Besøger = besøger;

        }

        public override string ToString()
        {
            return $"------------------------------------------------------------------------------" +
                $"BesøgsId: {BesøgsId} | BesøgsTidspunkt: {BesøgsTidspunkt} | Besøger: {Besøger}";
        }

    }
}
