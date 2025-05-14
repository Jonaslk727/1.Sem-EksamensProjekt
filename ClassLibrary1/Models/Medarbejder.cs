using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class Medarbejder
    {
        public string Navn { get; set; } = string.Empty;
        public int MedarbejderId { get; set; } = 0;
        public string Afdeling { get; set; } = string.Empty;
        public string Stilling { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefonnummer { get; set; } = string.Empty;



        public Medarbejder(string navn, int medarbejderId, string afdeling, string stilling, string email, string telefonnummer)
        {
            Nnavn = navn;
            MedarbejderId = medarbejderId;
            Afdeling = afdeling;
            Stilling = stilling;
            Email = email;
            Telefonnummer = telefonnummer;

        }
    }
}
   
