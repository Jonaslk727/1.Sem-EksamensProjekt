using System.Text;
using ClassLibrary1.Models.Besøg_og_lægelog;
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
    }
}
