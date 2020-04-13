using System;

namespace SistemMenjacnice.Utils
{
    /// <summary>
    /// Representing class 
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Representing method checking integer
        /// </summary>
        public static int ProveraCelogBroja()
        {
            int number;

            while (Int32.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Sorry,wrong input try again:");
            }

            return number;
        }

        /// <summary>
        /// Representing method for checking double
        /// </summary>
        public static double ProveraDecimalnogBroja()
        {
            double broj;

            while (Double.TryParse(Console.ReadLine(),out broj) == false)
            {
                Console.Write("Sorry,wrong input try again:");
            }

            return broj;
        }
        
        /// <summary>
        /// Representing method for checking Date
        /// </summary>
        public static DateTime ProveraDatuma()
        {
            DateTime date = new DateTime();

            while (DateTime.TryParse(Console.ReadLine(),out date) == false)
            {
                Console.Write("Sorry,wrong input try again:");
            }

            return date;
        }

        /// <summary>
        /// Representing property of the ID
        /// </summary>
        public static int IDKursneListe = 1;

        /// <summary>
        /// Representing property of the ID
        /// </summary>
        public static int IDValute = 1;
    }
}
