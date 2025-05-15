using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models.Besøg_og_lægelog;
using ClassLibrary1.Models;

namespace ClassLibrary1.Services
{
    public class DyreLog
    {   // der skal laves en en læge log og en besøg log class
        public List<string> LægeLogs = new List<string>();
        public List<Besøg> BesøgssLogs = new List<Besøg>();

        
        // skal kunne tage info fra booking og tilføje til bookingloggen
        
       

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
