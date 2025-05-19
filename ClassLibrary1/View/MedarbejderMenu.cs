//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ClassLibrary1.Models;
//using ClassLibrary1.Repositories;
//using ClassLibrary1.Services;

//namespace ClassLibrary1.View
//{
//    public class MedarbejderMenu
//    {
//        public void show(AktivitetRepo AkRepo, DyrRepo dyrRep)
//            {
//                MedarbejderRepo repo = new MedarbejderRepo();

//                repo.TilføjMedarbejder(new Medarbejder { MedarbejderId = 1, Navn = "Tim", Afdeling = "IT", Stilling = "Udvikler", Email = "tim@example.com", Telefonnummer = "12345678" });
//                repo.TilføjMedarbejder(new Medarbejder { MedarbejderId = 2, Navn = "Sara Jensen", Afdeling = "HR", Stilling = "HR Chef", Email = "sara@example.com", Telefonnummer = "87654321" });

//                bool fortsæt = true;
//                while (fortsæt)
//                {
//                    Console.Clear();

//                    // Title Header
//                    Console.ForegroundColor = ConsoleColor.Magenta;
//                    Console.WriteLine("\n=========================================");
//                    Console.WriteLine("       Medarbejder Menu - Vælg Kategori  ");
//                    Console.WriteLine("=========================================");

//                    // Section: Dyr
//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    Console.WriteLine("\n 1. Dyr");

//                    // Section: Kunde
//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    Console.WriteLine("\n 2. Kunde");

//                    // Section: Aktivitet
//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    Console.WriteLine("\n 3. Aktivitet");

//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    Console.WriteLine("\n 4. Medarbejder");

//                    // Exit Option
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("\n 0. Gå tilbage");
//                    Console.ForegroundColor = ConsoleColor.Magenta;

//                    Console.WriteLine("\n=========================================");
//                    Console.ResetColor();

//                    string valg = Console.ReadLine();
//                    switch (valg)
//                    {
//                        case "1":
//                            MedarbejderDyrMenu(dyrRep);
//                            break;
//                        case "2":
//                            MedarbejderKundeMenu();
//                            break;
//                        case "3":
//                            MedarbejderAktivitetMenu(AkRepo);
//                            break;
//                        case "4":
//                            MedarbejderMedarbejderMenu();
//                            break;
//                        case "0":
//                            fortsæt = false;
//                            break;
//                    }
//                }
//            }
//        }

//    }