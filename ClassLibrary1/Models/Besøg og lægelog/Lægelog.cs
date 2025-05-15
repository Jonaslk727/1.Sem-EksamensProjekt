using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models.Besøg_og_lægelog
{
    internal class Lægelog
    {
        public DateTime Dato { get; set; }
        public string Journal { get; set; } = "none";

        public Lægelog(DateTime dato, string journal)
        {
            Dato = dato;
            Journal = journal;
        }

        public override string ToString()
        {
            return $"-------------------------------------------------" +
                $"Lægebesøg: {Dato} | Journal: {Journal}";
        }
    }
}
