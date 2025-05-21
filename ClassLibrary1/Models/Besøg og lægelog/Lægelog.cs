using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models.Besøg_og_lægelog
{
    public class Lægelog
    { // Log for dyrlæg besøg
        static private int _next = 0;
        //Unik ID for logon
        public int Id { get; init; }
        public DateTime Dato { get; set; }
        public string Journal { get; set; } = "none";

        public Lægelog(DateTime dato, string journal)
        { //Constructor to initilalize the properties
            Id = _next++;
            Dato = dato;
            Journal = journal;
        }

        public override string ToString()
        {//Overrride ToString metod til at return  formatted string af lægelog
            return $"--------------------------------------------------------" +
                $"\n Lægebesøg: {Dato.ToString("dd-mm-yyyy")} | \n Journal: {Journal}";
        }
    }
}
