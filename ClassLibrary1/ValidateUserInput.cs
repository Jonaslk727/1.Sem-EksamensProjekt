using ClassLibrary1.Models;

namespace ClassLibrary1
{   // er en klasse til at validere brugerens input
    static public class ValidateUserInput
    {
        /// <summary>
        /// en specialklass til at vliderer input fra brugeren og at sikker at det er gyldigt
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
                Console.WriteLine("Ugyldigt input. Feltet må ikke stå tomt!");
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
            while (!DateTime.TryParse(input, out result) && result > DateTime.Now)
            {
                Console.WriteLine("Ugyldigt datoformat. Indtast venligst (dd/mm/yyyy).");
                input = GetString(Console.ReadLine());
            }
            return result;
        }
        /// <summary>
        /// for at sikre at input er et gyldigt decimaltal.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Proof of concept: for at sikre at input er et gyldigt boolsk værdi.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
        /// <summary>
        /// for at sikre at input er et gyldigt enum værdi: kønType: Hankøn eller Hunkøn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
        /// <summary>
        /// for at sikre at input er et gyldigt enum værdi: ArtType: Hund, Kat eller Fugl.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ArtType GetArtType(string input)
        {
            ArtType result;
            while (!Enum.TryParse(input, true, out result))
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst 'Hund', 'Kat' eller 'Fugl'.");
                input = Console.ReadLine();
            }
            return result;
        }
    }
}
