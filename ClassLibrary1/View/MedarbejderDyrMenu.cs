//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ClassLibrary1.Services;

//namespace ClassLibrary1.View
//{
//    public class MedarbejderDyrMenu
//    {
//        public void Show(DyrRepo dyrRep)
//        {

//            bool kørDyrMenu = true;
//            while (kørDyrMenu)
//            {
//                Console.Clear();
//                Console.ForegroundColor = ConsoleColor.Magenta;
//                Console.WriteLine("\n=====================================");
//                Console.WriteLine("       --- Dyr Menu ---      ");
//                Console.WriteLine("=====================================");
//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.WriteLine("1. Opret, slet eller redigr dyr");
//                Console.WriteLine("2. Vis alle dyr");
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("0. Tilbage");
//                Console.ForegroundColor = ConsoleColor.Magenta;
//                Console.WriteLine("=====================================");
//                Console.ResetColor();
//                string dyrValg = Console.ReadLine();
//                switch (dyrValg)
//                {
//                    case "1":
//                        SletRedigerOpretDyrMeny(dyrRep);
//                        break;
//                    case "2":
//                        dyrRep.PrintDyrList();
//                        break;
//                    case "0":
//                        kørDyrMenu = false; // Exit the animal menu
//                        break;
//                    default:
//                        Console.WriteLine("Ugyldigt valg, prøv igen.");
//                        break;
//                }
//            }
//        }
//    }
//}
