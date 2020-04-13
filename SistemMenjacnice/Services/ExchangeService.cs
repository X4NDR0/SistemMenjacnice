using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SistemMenjacnice.Enums;
using SistemMenjacnice.Models;
using SistemMenjacnice.Utils;

namespace SistemMenjacnice.Services
{
    /// <summary>
    /// Class representing ExchangeService
    /// </summary>
    public class ExchangeService
    {
        /// <summary>
        /// Representing List of the valuta
        /// </summary>
        private static List<Valuta> listaValuta = new List<Valuta>();
        private static List<KursnaLista> kursnaLista = new List<KursnaLista>();
        private static Enums.ExchangeMenu opcije;

        /// <summary>
        /// Method representing MenuText
        /// </summary>
        public void MenuText()
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
            Valuta valutaEuro = new Valuta("Euro", 117.0000, 118.5000);
            Valuta valutaUSD = new Valuta("USD", 102.2000, 109.3500);
            Valuta valutaCHF = new Valuta("CHF", 105.1100, 112.7000);
            Valuta valutaAUD = new Valuta("AUD", 64.8000, 69.2500);
            Valuta valutaCAD = new Valuta("CAD", 73.2000, 78.2500);
            Valuta valutaHRK = new Valuta("HRK", 14.1900, 15.8000);
            Valuta valutaDKK = new Valuta("DKK", 14.9700, 15.8000);
            Valuta valutaHUF = new Valuta("HUF", 0.3060, 0.3340);
            Valuta valutaNOK = new Valuta("NOK", 9.9600, 10.5000);
            Valuta valutaSEK = new Valuta("SEK", 10.2700, 10.8500);
            Valuta valutaGBP = new Valuta("GBP", 129.3500, 133.9897);
            Valuta valutaBAM = new Valuta("BAM", 56.5500, 61.5500);
            Valuta valutaRUB = new Valuta("RUB", 1.3100, 1.5600);
            Valuta valutaCNY = new Valuta("CNY", 14.4400, 16.1100);
            Valuta valutaJPY = new Valuta("JPY", 0.9423, 1.0414);
            Valuta valutaPLN = new Valuta("PLN", 24.7900, 26.4600);
            Valuta valutaCZK = new Valuta("CZK", 4.0100, 4.4500);

            listaValuta.Add(valutaEuro);
            listaValuta.Add(valutaUSD);
            listaValuta.Add(valutaCHF);
            listaValuta.Add(valutaAUD);
            listaValuta.Add(valutaCAD);
            listaValuta.Add(valutaHRK);
            listaValuta.Add(valutaDKK);
            listaValuta.Add(valutaHUF);
            listaValuta.Add(valutaNOK);
            listaValuta.Add(valutaSEK);
            listaValuta.Add(valutaGBP);
            listaValuta.Add(valutaBAM);
            listaValuta.Add(valutaRUB);
            listaValuta.Add(valutaCNY);
            listaValuta.Add(valutaJPY);
            listaValuta.Add(valutaPLN);
            listaValuta.Add(valutaCZK);

            KursnaLista kursnaLista1 = new KursnaLista { ID = 1, DatumFormiranja = "4/7/2020", listaValuta = listaValuta };
            KursnaLista kursnaLista2 = new KursnaLista { ID = 2, DatumFormiranja = "2/7/2020", listaValuta = listaValuta };

            kursnaLista.Add(kursnaLista1);
            kursnaLista.Add(kursnaLista2);

            Helper.IDKursneListe = kursnaLista.Max(x => x.ID);
            Helper.IDKursneListe++;

            Helper.IDValute = listaValuta.Count;
            Helper.IDValute++;

            do
            {
                MenuText();
                Enum.TryParse(Console.ReadLine(), out opcije);

                switch (opcije)
                {
                    case Enums.ExchangeMenu.IspisSvihValuta:
                        Console.Clear();
                        WriteAllCurrency();
                        Console.WriteLine("Press any key to back in menu...");
                        Console.ReadLine();
                        Console.Clear();
                        break;


                    case Enums.ExchangeMenu.IspisOdredjeneKursneListe:
                        Console.Clear();
                        WriteSelectedExchangeRate();
                        Console.WriteLine("Press any key to back in menu...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Enums.ExchangeMenu.KreiranjeKursneListe:
                        Console.Clear();
                        CreateExchangeRate();
                        Console.WriteLine("Press any key to back in menu...");
                        Console.ReadLine();
                        Console.Clear();
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
        /// Representing method for writing all currency
        /// </summary>
        public static void WriteAllCurrency()
        {
            foreach (Valuta valuta in listaValuta)
            {
                Console.WriteLine(valuta.ID + " " + valuta.Naziv + " " + "{0:0.0000}" + " {1:0.0000}" + " {2:0.0000}", valuta.Prodajni, valuta.Srednji, valuta.Kupovni);
            }
        }

        /// <summary>
        /// Representing method for writing selected exchange rate
        /// </summary>
        public static void WriteSelectedExchangeRate()
        {
            Console.WriteLine("=================================");

            Console.Write("Unesite ID kursne liste:");
            int IDKursneListe = Helper.ProveraCelogBroja();

            foreach (KursnaLista kursnaLista in kursnaLista)
            {
                if (IDKursneListe == kursnaLista.ID)
                {
                    Console.WriteLine("=============KURSNA LISTA=============");
                    Console.WriteLine("ID:" + kursnaLista.ID + "\n" + "Datum:" + kursnaLista.DatumFormiranja);

                    int index = kursnaLista.listaValuta.FindIndex(x => x.ID == IDKursneListe);

                    Console.WriteLine("=============VALUTE=============");
                    Console.WriteLine("ID:" + kursnaLista.listaValuta[index].ID);
                    Console.WriteLine("Naziv:" + kursnaLista.listaValuta[index].Naziv);
                    Console.WriteLine("Prodajna cena:{0:0.0000}", kursnaLista.listaValuta[index].Prodajni);
                    Console.WriteLine("Srednja cena:{0:0.0000}", kursnaLista.listaValuta[index].Srednji);
                    Console.WriteLine("Kupovna cena:{0:0.0000}", kursnaLista.listaValuta[index].Kupovni);

                    Console.WriteLine("======================================");
                }
            }
        }
        /// <summary>
        /// Representing method for creating exchange rate
        /// </summary>
        public static void CreateExchangeRate()
        {

        }
    }

}
