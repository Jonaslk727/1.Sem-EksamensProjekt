using System.Text;
using ClassLibrary1.Models.Besøg_og_lægelog;

namespace ClassLibrary1.Services
{
    /// <summary>
    /// Klasse: DyreLog  
    /// Håndterer logføring af dyrebesøg og lægejournaler.  
    /// Indeholder metoder til oprettelse af logs samt visning af  
    /// besøgs- og lægejournaler.  
    /// </summary>
    public class DyreLog
    {
        /// Dictionary til lagring af lægejournaler, indeholdende ID og journal
        public Dictionary<int, Lægelog> LægeLogs = new Dictionary<int, Lægelog>();
        
        /// Liste til lagring af alle besøgslogs.
        public List<Besøg> BesøgssLogs = new List<Besøg>();

        //Opretter en ny besøgslog med dato og besøgnde
        public void CreateBesøgLog(DateTime Dato, Models.Kunde besøger)
        {
            Besøg besøg = new Besøg(Dato, besøger);
            BesøgssLogs.Add(besøg);
        }
       //Opretter en ny lægelog med dato og journal
        public void CreateLægeLog(DateTime dato, string journal)
        {
            Lægelog lægelog = new Lægelog(dato, journal);
            LægeLogs.Add(lægelog.Id, lægelog);
        }
        // Henter og returnerer alle besøgslogs som en formateret tekststreng
        public string GetBesøgsLog()
        {
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

        /// Henter og returnerer alle lægejournaler som en formateret tekststr
        public string GetLægeLog()
        {
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

        public bool DeleteBesøgLog(int id)
        {
            
           foreach (var besøg in BesøgssLogs)
           {
                if (besøg.BesøgsId == id)
                {
                    BesøgssLogs.Remove(besøg);
                    return true;
                }
           }
           return false;
        }
    }
}
