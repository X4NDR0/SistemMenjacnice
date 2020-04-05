using System;
using System.Collections.Generic;
using System.Text;
using SistemMenjacnice.Enums;
using SistemMenjacnice.Models;

namespace SistemMenjacnice.Services
{
    /// <summary>
    /// Class representing ExchangeService
    /// </summary>
    public class ExchangeService
    {
        private static List<Valuta> listaValuta = new List<Valuta>();
        private static List<KursnaLista> kursnaLista = new List<KursnaLista>();
        private static Enums.ExchangeMenu opcije;

        /// <summary>
        /// Method representing MenuText
        /// </summary>
        public static void MenuText()
        {
            Console.WriteLine("1.Ispis svih valuta");
            Console.WriteLine("2.Ispis odredjene kursne liste sa spiskom valuta");
            Console.WriteLine("3.Kreiranje kursne liste");
            Console.WriteLine("0.Izlaz");
            Console.Write("Opcija:");
        }

        /// <summary>
        /// Method representing ExchangeMenu
        /// </summary>
        public void ExchangeMenu()
        {
            do
            {
                MenuText();
                Enum.TryParse(Console.ReadLine(), out opcije);

                switch (opcije)
                {   
                    case Enums.ExchangeMenu.IspisSvihValuta:

                        break;

                    case Enums.ExchangeMenu.IspisOdredjeneKursneListe:

                        break;

                    case Enums.ExchangeMenu.KreiranjeKursneListe:

                        break;

                    case Enums.ExchangeMenu.Exit:

                        break;

                    default:
                        Console.WriteLine("That option does not exist!");
                        break;
                }

            } while (opcije != Enums.ExchangeMenu.Exit);
        }

    }
}
