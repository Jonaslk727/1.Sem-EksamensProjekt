using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models.Besøg_og_lægelog
{
    public class Besøg
    {//BesøgLog  BesøgId,BesøgTidspunkt,Besøger
        public DateTime BesøgsTidspunkt { get; set; }

        private static int _nextId = 1;
        public Kunde Besøger { get; set; }
        public int BesøgsId { get; init; }

        public Besøg(DateTime besøgsTidspunkt, Kunde besøger)
        {//Constructor to initilalize the properties
            BesøgsTidspunkt = besøgsTidspunkt;
            Besøger = besøger;
            BesøgsId = _nextId++;
        }

        public override string ToString()
        {//Overrride ToString metod to return a formatted string of the visit
            return $"------------------------------------------------------------------------------" +
                $"\n BesøgsId: {BesøgsId} |\n BesøgsTidspunkt: {BesøgsTidspunkt} |\n Besøger: {Besøger.Navn}";
        }

    }
}
