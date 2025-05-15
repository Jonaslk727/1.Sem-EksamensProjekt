using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models.Besøg_og_lægelog
{
    public class Lægelog
    {
        static private int _next = 0;
        public int Id { get; init; }
        public DateTime Dato { get; set; }
        public string Journal { get; set; } = "none";

        public Lægelog(DateTime dato, string journal)
        {
            Id = _next++;
            Dato = dato;
            Journal = journal;
        }

        public override string ToString()
        {
            return $"--------------------------------------------------------" +
                $"Lægebesøg: {Dato} | Journal: {Journal}";
        }
    }
}
