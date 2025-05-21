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
    {// Klasse til administration af dyrelægelog og besøgsregistrering  
        public Dictionary<int, Lægelog> LægeLogs = new Dictionary<int, Lægelog>();
        public List<Besøg> BesøgssLogs = new List<Besøg>();

        public void CreateBesøgLog(DateTime Dato, Models.Kunde besøger)
        {// Metode til at registrere et nyt besøg i systemet
            Besøg besøg = new Besøg(Dato, besøger);
            BesøgssLogs.Add(besøg);
        }
        public void CreateLægeLog(DateTime dato, string journal)
        {// Metode til oprettelse af en ny lægelog og tilføjelse til loglisten
            Lægelog lægelog = new Lægelog(dato, journal);
            LægeLogs.Add(lægelog.Id, lægelog);
        }

        public void Delete()
        {
            // Implementer logik til at slette loggen
        }

        public string GetBesøgsLog()
        {// Metode til hentning af alle besøgslogs 
            StringBuilder sb = new StringBuilder();
            if (BesøgssLogs.Count == 0)
            {
                sb.AppendLine("´Der er ingen besøgsLogs");
                return sb.ToString();
            }
            else
            {
                foreach (var log in BesøgssLogs)
                {
                    sb.AppendLine(log.ToString());
                }
                return sb.ToString();
            }
        }

        public string GetLægeLog()
        {// Metode til hentning af alle lægelogs 
            StringBuilder sb = new StringBuilder();
            if (LægeLogs.Count == 0)
            {
                sb.AppendLine("´Der er ingen lægeLogs");
                return sb.ToString();
            }
            else
            {
                foreach (var log in LægeLogs.Values)
                {
                    sb.AppendLine(log.ToString());
                }
                return sb.ToString();
            }
        }


    }
}
