using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    internal class Person
    {
        public string Navn { get; set; }
        public string Email { get; set; }
        public int Mobil { get; set; }



        public Person(string navn, string email, int mobil)
        {
            Navn = navn;
            Email = email;
            Mobil = mobil;
        }
    }
}