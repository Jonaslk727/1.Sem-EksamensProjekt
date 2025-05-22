namespace ClassLibrary1.Models
{
    public class Aktivitet
    {
        #region Properties
        public int AktivitetID { get; set; } //Unik identifikator for aktiviteten 
        private static int nextId = 0; //Statisk tæller til generer unik ID for ny aktivitet
        public string Title { get; set; } 
        public DateTime StartTid { get; set; } 
        public DateTime SlutTid { get; set; }
        public string Beskrivelse { get; set; }
        public bool IsBooked => Tilmeldte.Count > 0; //Returnerer true hvis der er tilmeldte kunder
        #endregion

        public List<Kunde> Tilmeldte { get; set; } = new List<Kunde>(); //Liste over kunder tilmeldt aktivitet

        public Aktivitet(string title, DateTime start, DateTime slut, string beskrivelse) //Constructor
        {
            //Her tildeles det nye ID
            nextId++;
            AktivitetID = nextId;
            //Initialiserer properties
            Title = title;
            StartTid = start;
            SlutTid = slut;
            Beskrivelse = beskrivelse;
        }
        //Returner en formateret tekst af aktiviteten
        public override string ToString()
        {
            return
                "---------------------------\n" +
                $"          {AktivitetID}: {Title}\n" +
                "-------------------------------\n" +
                $"Start tid  : {StartTid:dd-MM-yyyy HH:mm}\n" +
                $"Slut tid   : {SlutTid:dd-MM-yyyy HH:mm}\n" +
                $"Beskrivelse:\n{Beskrivelse}\n" +
                "-------------------------------";
        }
    }
}
