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
    {  
        public Dictionary<int, Lægelog> LægeLogs = new Dictionary<int, Lægelog>();
        public List<Besøg> BesøgssLogs = new List<Besøg>();

        public void CreateBesøgLog(DateTime Dato, Models.Kunde besøger)
        {
            Besøg besøg = new Besøg(Dato, besøger);
            BesøgssLogs.Add(besøg);
        }
        public void CreateLægeLog(DateTime dato, string journal)
        {
            Lægelog lægelog = new Lægelog(dato, journal);
            LægeLogs.Add(lægelog.Id, lægelog);
        }

        public void Delete()
        {
            // Implementer logik til at slette loggen
        }
    }
}
