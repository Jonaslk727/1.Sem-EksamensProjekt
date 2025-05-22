using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models.Besøg_og_lægelog
{
    /// <summary>
    /// Klasse: Besøg  
    /// Håndterer registrering af besøg på Roskilde Dyreinternat.  
    /// Indeholder tidspunkt, besøgende og automatisk tildelt besøgs-ID.  
    /// Tilbyder en metode til visning af besøg.  
    /// </summary>


    public class Lægelog
    {
        static private int _next = 0;
        public int Id { get; init; }
        public DateTime Dato { get; set; }
        public string Journal { get; set; } = "none";

        /// Konstruktør til oprettelse af et besøg.
        /// Initialiserer tidspunkt, besøgende og tildeler et automatisk ID.
        public Lægelog(DateTime dato, string journal)
        {
            Id = _next++;
            Dato = dato;
            Journal = journal;
        }

        /// Returnerer en formateret streng med oplysninger om besøget.
        public override string ToString()
        {
            return $"--------------------------------------------------------" +
                $"\n Lægebesøg: {Dato.ToString("dd-mm-yyyy")} | \n Journal: {Journal}";
        }
    }
}
