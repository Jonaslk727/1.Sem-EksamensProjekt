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

        private static int _nextId = 1;
        public Kunde Besøger { get; set; }
        public int BesøgsId { get; init; }

        public Besøg(DateTime besøgsTidspunkt, Kunde besøger)
        {
            BesøgsTidspunkt = besøgsTidspunkt;
            Besøger = besøger;
            BesøgsId = _nextId++;
        }

        public override string ToString()
        {
            return $"------------------------------------------------------------------------------" +
                   $"\n BesøgsId: {BesøgsId} |\n BesøgsTidspunkt: {BesøgsTidspunkt} |\n Besøger: {(Besøger != null ? Besøger.Navn : "Ingen besøger")}";
        }

    }
}
