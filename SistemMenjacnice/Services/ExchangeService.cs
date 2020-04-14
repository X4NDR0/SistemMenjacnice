using SistemMenjacnice.Models;
using SistemMenjacnice.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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

            DateTime add = new DateTime();

            KursnaLista kursnaLista1 = new KursnaLista(add = new DateTime(2020, 4, 13), listaValuta);
            KursnaLista kursnaLista2 = new KursnaLista(add = new DateTime(2020, 7, 2), listaValuta);

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
            foreach (KursnaLista kursnaLista in kursnaLista)
            {
                Console.WriteLine(kursnaLista.ID.ToString() + " " + kursnaLista.DatumFormiranja.ToString());
            }

            Console.WriteLine("=================================");

            Console.Write("Unesite ID kursne liste:");
            int IDKursneListe = Helper.ProveraCelogBroja();

            foreach (KursnaLista kursnaLista in kursnaLista)
            {
                if (IDKursneListe == kursnaLista.ID)
                {
                    Console.WriteLine("=============KURSNA LISTA=============");
                    Console.WriteLine("ID:" + kursnaLista.ID + "\n" + "Datum:" + kursnaLista.DatumFormiranja);

                    foreach (Valuta valuta in kursnaLista.ListaValuta)
                    {
                        Console.WriteLine("Naziv:" + valuta.Naziv + " Kupovna:{0:0.0000}" + " Srednja:{1:0.0000}" + " Prodajna:{2:0.0000}", valuta.Kupovni, valuta.Srednji, valuta.Prodajni);
                    }
                }
            }
        }
        /// <summary>
        /// Representing method for creating exchange rate
        /// </summary>
        public static void CreateExchangeRate()
        {
            List<Valuta> listaValutaAdd = new List<Valuta>();
            DateTime datum = new DateTime();

            foreach (Valuta valuta in listaValuta)
            {
                Console.Clear();
                Console.WriteLine("Naziv:" + valuta.Naziv);

                Console.Write("Unesite kupovnu cenu:");
                valuta.Kupovni = Helper.ProveraDecimalnogBroja();

                Console.Write("Unesite prodajnu cenu:");
                valuta.Prodajni = Helper.ProveraDecimalnogBroja();

                Valuta valutaAdd = new Valuta(valuta.Naziv, valuta.Kupovni, valuta.Prodajni);
                listaValutaAdd.Add(valutaAdd);
            }

            Console.Clear();

            Console.WriteLine("1.Rucno unosenje datuma");
            Console.WriteLine("2.Automatski");
            Console.Write("Opcija:");
            int opcija = Helper.ProveraCelogBroja();

            switch (opcija)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Unesite u formatu(4,13,2020)");
                    datum = Helper.ProveraDatuma();
                    break;

                case 2:
                    Console.Clear();
                    datum = DateTime.Now;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Ta opcija ne postoji!");
                    break;
            }
            KursnaLista kursnaListaAdd = new KursnaLista(datum, listaValutaAdd);
            kursnaLista.Add(kursnaListaAdd);

            Console.Clear();
            Console.WriteLine("Kursna lista je uspesno dodata!");
        }
    }

}
