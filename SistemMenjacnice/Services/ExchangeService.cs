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
            //string lokacijaFajlova = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            //LoadDataValuta(lokacijaFajlova + "data" + "\\" + "valuta.csv");
            //LoadDataKursnaListe(lokacijaFajlova + "data" + "\\" + "kursnaLista.csv");

            Valuta valutaEuro = new Valuta { ID = 1, Naziv = "Euro", Prodajni = 110.00, Srednji = 115.00, Kupovni = 120.00 };
            Valuta valutaUSD = new Valuta { ID = 2, Naziv = "USD", Prodajni = 99.00, Srednji = 103.00, Kupovni = 108.00 };
            listaValuta.Add(valutaEuro);
            listaValuta.Add(valutaUSD);

            KursnaLista kursnaLista1 = new KursnaLista { ID = 1, DatumFormiranja = "4/7/2020", listaValuta = listaValuta };
            KursnaLista kursnaLista2 = new KursnaLista { ID = 2, DatumFormiranja = "2/7/2020", listaValuta = listaValuta };

            kursnaLista.Add(kursnaLista1);
            kursnaLista.Add(kursnaLista2);

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
        /// Representing method for load data of Valuta
        /// </summary>
        //public void LoadDataValuta(string fileName)
        //{
        //    string line = string.Empty;
        //    if (File.Exists(fileName))
        //    {
        //        using (StreamReader citac = File.OpenText(fileName))
        //        {
        //            while ((line = citac.ReadLine()) != null)
        //            {
        //                listaValuta.Add(new Valuta(line));
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Greska,datoteka nije pronadjena!");
        //    }
        //}

        ///// <summary>
        ///// Representing method for load data
        ///// </summary>
        ///// <param name="fileName"></param>
        //public void LoadDataKursnaListe(string fileName)
        //{
        //    string line = string.Empty;
        //    if (File.Exists(fileName))
        //    {
        //        using (StreamReader citac = File.OpenText(fileName))
        //        {
        //            while ((line = citac.ReadLine()) != null)
        //            {
        //                kursnaLista.Add(new KursnaLista(line));
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Greska,datoteka nije pronadjena!");
        //    }
        //}

        /// <summary>
        /// Representing method for writing all currency
        /// </summary>
        public static void WriteAllCurrency()
        {
            foreach (Valuta valuta in listaValuta)
            {
                Console.WriteLine(valuta.ID + " " + valuta.Naziv + " " + "{0:0.00}" + " {1:0.00}" + " {2:0.00}", valuta.Prodajni, valuta.Srednji, valuta.Kupovni);
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
                    Console.WriteLine("Prodajna cena:{0:0.00}", kursnaLista.listaValuta[index].Prodajni);
                    Console.WriteLine("Srednja cena:{0:0.00}", kursnaLista.listaValuta[index].Srednji);
                    Console.WriteLine("Kupovna cena:{0:0.00}", kursnaLista.listaValuta[index].Kupovni);
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
