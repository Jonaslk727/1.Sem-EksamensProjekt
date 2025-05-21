using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class Person
    {// Baseklasse, der repræsenterer en generisk person med fælles egenskaber
        public string Navn { get; set; }
        public string Email { get; set; }
        public int Mobil { get; set; }



        public Person(string navn, string email, int mobil)
        {// Constructor
            Navn = navn;
            Email = email;
            Mobil = mobil;
        }

        public Person()
        {
        }
    }
}