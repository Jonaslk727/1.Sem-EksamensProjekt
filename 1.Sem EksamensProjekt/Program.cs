namespace _1.Sem_EksamensProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool kørProgram = true;

            while(kørProgram)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hovedmenu: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Medarbejder");
                Console.WriteLine("2. Kunde");

                string valg = Console.ReadLine();

                switch(valg)
                {
                    case "1":
                        MedarbejderMenu();
                        break;
                    case "2":
                        KundeMenu();
                        break;
                }
            }
        }
        static void MedarbejderMenu()
        {
            bool fortsæt = true;
            while (fortsæt)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Medarbejder Menu");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dyr:")
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Se oprettede dyr");
                Console.WriteLine("2. Opret, slet eller rediger dyr");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Kunde:")
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("3. Se oprettede kunder");
                Console.WriteLine("4. Opret, slet eller rediger kunde");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Aktivitet:")
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("5. Se oprettede aktiviteter");
                Console.WriteLine("6. Opret, slet eller rediger aktivitet"):

                string valg = Console.ReadLine();
                switch (valg)
                {
                    case "1":
                        //Metode til 
                        break;
                    case "2":
                        HåndterDyrMenu();
                        break;
                    case "3":
                        //Metode
                }
            }
        }
        static void KundeMenu()
        {

      "4":
                        HåndterKundeMenu();
                        break;
                    case "5"  }
        static void HåndterDyrMenu()
        {

        }
    }
}
