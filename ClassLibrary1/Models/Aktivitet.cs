using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class Aktivitet
    {
        #region Properties
        public int AktivitetID { get; set; }
        private static int nextId = 0;
        public string Title { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public string Beskrivelse { get; set; }
        #endregion

        public List<Kunde> Tilmeldte { get; set; } = new List<Kunde>();

        public Aktivitet(string title, DateTime start, DateTime slut, string beskrivelse)
        {
            nextId++;
            AktivitetID = nextId;

            Title = title;
            StartTid = start;
            SlutTid = slut;
            Beskrivelse = beskrivelse;
        }
        public override string ToString()
        {
            return $"--- Aktivitet ---\n" +
                   $"ID: {AktivitetID}\n" +
                   $"Title: {Title}\n" +
                   $"Start tid: {StartTid:dd-MM-yyyy HH:mm}\n" +
                   $"Slut tid: {SlutTid:dd-MM-yyyy HH:mm}\n" +
                   $"Beskrivelse:\n{Beskrivelse}\n" +
                   $"-----------------";
        }
    }
}
