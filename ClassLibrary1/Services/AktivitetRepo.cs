using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models; //Så vi kan tilgå vores model klasser

namespace ClassLibrary1.Services
{
    //Dele af denne klasse er lavet ved hjælp af vores egen udarbejdet 3. Obligatoriske opgave
    public class AktivitetRepo
    {
        public Dictionary<int, Aktivitet> AlleAktiviteter = new Dictionary<int, Aktivitet>();
    
    public bool OpretAktivitet(string Title, DateTime start, DateTime slut, string beskrivelse)
        {
            Aktivitet n = new(Title, start, slut, beskrivelse);
            AlleAktiviteter.Add(n.AktivitetID, n);
            return true;
        }
        public bool SletAktivitet(int id)
        {
            foreach (var aktivitet in AlleAktiviteter)
            {
                if (aktivitet.Key == id)
                {
                    AlleAktiviteter.Remove(id);
                    Console.WriteLine("Aktiviteten blev slettet");
                    return true;
                }
            }
            Console.WriteLine("Ingen aktivitet med dette ID");
            return false;
        }
        public void VisAlleAktivitet()
        {
            foreach (var n in AlleAktiviteter)
            {
                Console.WriteLine();
                Console.WriteLine(n.ToString());
                Console.WriteLine();
                Console.WriteLine("---------------------------");
            }
        }
        public bool TilmeldAktivitet(int id, List<Kunde> Kunder)
        {
            foreach (Aktivitet b in AlleAktiviteter.Values)
            {
                if (b.AktivitetID == id)
                {
                    foreach (Kunde k in Kunder)
                    {
                        b.Tilmeldte.Add(k);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
