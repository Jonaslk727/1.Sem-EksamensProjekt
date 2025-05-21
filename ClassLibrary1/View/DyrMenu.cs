using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.Services;

namespace ClassLibrary1.View
{
    public class DyrMenu
    {
        DyrRepo _dyrRep = new DyrRepo();
        BookingRepo _bookingRep = new BookingRepo();
        AktivitetRepo _aktivitetRep = new AktivitetRepo();
        KundeRepo _kundeRepo = new KundeRepo();

        public DyrMenu(DyrRepo dyrRep, BookingRepo bookingRep, AktivitetRepo aktivitetRep, KundeRepo kundeRepo)
        {
            _dyrRep = dyrRep;
            _bookingRep = bookingRep;
            _aktivitetRep = aktivitetRep;
            _kundeRepo = kundeRepo;
        }
        

        public void KundeDyrMenu(Kunde aktuelKunde)
        { 
            bool fortsæt = true;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("               Besøg et dyr");
                Console.WriteLine("==========================================");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. hvis alle ledige dyr:");
                Console.WriteLine("2. book et besøg:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. gå tilbage:");
                Console.ResetColor();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // viser ledige dyr
                        _dyrRep.PrintLedigeDyr();
                        break;
                    case "2":
                        // booking logik
                        _bookingRep.OpretBesøgBookingMedKunde(_dyrRep, aktuelKunde);
                        break;
                    case "0":
                        fortsæt = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            } while (fortsæt);
            
        }
    }
}