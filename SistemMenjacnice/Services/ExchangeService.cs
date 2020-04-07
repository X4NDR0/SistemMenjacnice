using System;
using System.Collections.Generic;
using System.IO;
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
            string lokacijaValutaFajla = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            LoadDataValuta(lokacijaValutaFajla + "data" + "\\" + "valuta.csv");
            do
            {
                MenuText();
                Enum.TryParse(Console.ReadLine(), out opcije);

                switch (opcije)
                {   
                    case Enums.ExchangeMenu.IspisSvihValuta:
                        Console.Clear();
                        foreach (Valuta valuta in listaValuta)
                        {
                            Console.WriteLine(valuta.ID + " " + valuta.Naziv + " " + "{0:0.00}" + " {1:0.00}" + " {2:0.00}",valuta.Prodajni,valuta.Srednji,valuta.Kupovni);
                        }
                        Console.WriteLine("Press any key to back in menu...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Enums.ExchangeMenu.IspisOdredjeneKursneListe:

                        break;

                    case Enums.ExchangeMenu.KreiranjeKursneListe:

                        break;

                    case Enums.ExchangeMenu.Exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("That option does not exist!");
                        break;
                }

            } while (opcije != Enums.ExchangeMenu.Exit);
        }

        /// <summary>
        /// Representing method for load data of Valuta
        /// </summary>
        public void LoadDataValuta(string fileName)
        {
            string line = string.Empty;
            if (File.Exists(fileName))
            {
                using (StreamReader citac = File.OpenText(fileName))
                {
                    while ((line = citac.ReadLine()) != null)
                    {
                        listaValuta.Add(new Valuta(line));
                    }
                }
            }
            else
            {
                Console.WriteLine("Greska,datoteka nije pronadjena!");
            }
        }

    }
}
