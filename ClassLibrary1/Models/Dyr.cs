using ClassLibrary1.Services;

namespace ClassLibrary1.Models
{
    public enum ArtType
    {
        Hund,
        Kat,
        Fugl,
    }
    public enum kønType
    {
        Hankøn,
        Hunkøn,
    }

    public class Dyr
    {
        #region Properties
        static private int _nextId = 1;
        public bool IsBooked { get; set; } = false;
        public string Navn { get; set; } = "None";
        public ArtType Art { get; set; }
        public string Race { get; set; } = "none";
        public DateTime FødselsDag { get; set; }
        public kønType Køn { get; set; }
        public int ChipNummer { get; set; }
        public double Vægt { get; set; }
        public string Info { get; set; } = "None";
        public DyreLog Log { get; set; } = new DyreLog();
        #endregion
        public Dyr(string navn, ArtType art, string race, double vægt, DateTime fødselsdag, kønType køn, string info)
        {
            ChipNummer = _nextId++;
            Navn = navn;
            Art = art;
            Race = race;
            FødselsDag = fødselsdag;
            Vægt = vægt;
            Køn = køn;
            Info = info;
        }
        /// <summary>
        /// Udprinter dyrets properties i en string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "---------------------------------------------------------------\n" +
       $"Id: {ChipNummer} | Dyr: {Art} | Navn: {Navn} | Køn: {Køn}\n" +
       $"Race: {Race} | Fødselsdag: {FødselsDag} | Vægt: {Vægt} kg\n" +
       $"Mere info: {Info}\n" +
       "---------------------------------------------------------------\n";
        }

        /// <summary>
        /// 1 Returnerer læge loggen, 2 returnerer besøgs loggen.
        /// </summary>
        /// <param name="i">int i, specifisere hvilken log der returneres <list type="bullet"> <item><description>1: Retrieves
        /// the "Læge" log.</description></item> <item><description>2: Retrieves the "Besøgs" log.</description></item>
        /// </list></param>
        /// <returns>A string containing the requested log data.</returns>
        /// <exception cref="AggregateException">Thrown if the provided <paramref name="i"/> does not match a valid log type.</exception>
        public string GetLogs(int i)
        {
            switch (i)
            {
                case 1:
                    return Log.GetLægeLog();
                    break;
                case 2:
                    return Log.GetBesøgsLog();
                    break;
                default:
                    throw new AggregateException();
                    break;
            }

        }

        public bool AddLægeLog(DateTime dato, string journal)
        {
            Log.CreateLægeLog(dato, journal);
            return true;
        }

    }
}