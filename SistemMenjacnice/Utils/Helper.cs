﻿using System;
using System.Collections.Generic;
using System.Text;

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

            while (Int32.TryParse(Console.ReadLine(),out number) == false)
            {
                Console.Write("Sorry,wrong input try again:");
            }

            return number;
        }
    }
}
