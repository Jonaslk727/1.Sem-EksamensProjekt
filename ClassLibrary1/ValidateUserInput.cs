using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    static public class ValidateUserInput
    {
        /// <summary>
        /// Validerer input og sikrer at det er et heltal.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetInt(string input)
        {
            int result;
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst et heltal.");
                input = GetString(Console.ReadLine());
            }
            return result;
        }
        /// <summary>
        /// Validerer input og sikrer at det ikke er null eller tomt.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetString(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst en gyldig tekst.");
                input = Console.ReadLine();
            }
            return input.Trim();
        }
        /// <summary>
        /// Validerer input og sikrer at det er et gyldigt datoformat.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string input)
        {
            DateTime result;
            while (!DateTime.TryParse(input, out result))
            {
                Console.WriteLine("Ugyldigt datoformat. Indtast venligst (dd/mm/yyyy HH:mm).");
                input = GetString(Console.ReadLine());
            }
            return result;
        }

        public static double GetDouble(string input)
        {
            double result;
            while (!double.TryParse(input, out result))
            {
                Console.WriteLine("Ugyldigt input. indtast et decimaltal!");
                input = GetString(Console.ReadLine());
            }
            return result;
        }

        public static bool GetBool(string input)
        {
            bool result;
            while (!bool.TryParse(input, out result))
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst 'true' eller 'false'.");
                input = GetString(Console.ReadLine());
            }
            return result;
        }

        public static kønType GetKønType(string input)
        {
            kønType result;
            while (!Enum.TryParse(input, true, out result))
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst 'Hankøn' eller 'Hunkøn'.");
                input = GetString(Console.ReadLine());
            }
            return result;
        }

        public static ArtType GetArtType(string input)
        {
            ArtType result;
            while (!Enum.TryParse(input, true, out result))
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst 'Hund', 'Kat' eller 'Fugl'.");
                input = GetString(Console.ReadLine());
            }
            return result;
        }


    }
}
