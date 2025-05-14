using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Services
{
    public class DyreLog: ICRUD
    {
        List< string> MedicinskLog = new List<string>();
        List<string> BesøgssLog = new List<string>();

        
        public void Read()
        {
            // Implementer logik til at læse loggen
        }
        public void Update()
        {
            // Implementer logik til at opdatere loggen
        }
        public void Delete()
        {
            // Implementer logik til at slette loggen
        }
    }
}
