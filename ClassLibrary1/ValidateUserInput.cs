using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    static public class ValidateUserInput
    {
        public static int GetInt(string input)
        {
            int result;
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst et heltal.");
                input = Console.ReadLine();
            }
            return result;
        }
        public static string GetString(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst en gyldig tekst.");
                input = Console.ReadLine();
            }
            return input.Trim();
        }
        public static DateTime GetDateTime(string input)
        {
            DateTime result;
            while (!DateTime.TryParse(input, out result))
            {
                Console.WriteLine("Ugyldigt datoformat. Indtast venligst en gyldig dato.");
                input = Console.ReadLine();
            }
            return result;
        }


    }
}
