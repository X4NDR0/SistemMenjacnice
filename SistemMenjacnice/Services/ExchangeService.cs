using SistemMenjacnice.Models;
using SistemMenjacnice.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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
            LoadData();

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
            Console.WriteLine("| ID   Zemlja                   Oznaka |");
            foreach (Valuta valuta in listaValuta)
            {
                Console.WriteLine("".PadRight(40, '-'));
                Console.WriteLine("| " + valuta.ID.ToString().PadRight(5) + valuta.Naziv.PadRight(25) + valuta.Oznaka.PadRight(7) + "|");
            }
            Console.WriteLine("".PadRight(40, '-'));
        }

        /// <summary>
        /// Representing method for writing selected exchange rate
        /// </summary>
        public static void WriteSelectedExchangeRate()
        {
            foreach (KursnaLista kursnaLista in kursnaLista)
            {
                Console.WriteLine(kursnaLista.ID.ToString() + " " + kursnaLista.DatumFormiranja.ToString("dd/MM/yyyy"));
            }

            Console.WriteLine("=================================");

            Console.Write("Unesite ID kursne liste:");
            int IDKursneListe = Helper.ProveraCelogBroja();

            foreach (KursnaLista kursnaLista in kursnaLista)
            {
                if (IDKursneListe == kursnaLista.ID)
                {
                    Console.WriteLine("=============KURSNA LISTA=============");
                    Console.WriteLine("ID:" + kursnaLista.ID + "\n" + "Datum:" + kursnaLista.DatumFormiranja.ToString("dd/MM/yyyy"));
                    Console.WriteLine("".PadRight(113, '-'));

                    Console.WriteLine("| Zemlja                        Oznaka              Prodajni            Srednji             Kupovni             |");

                    foreach (Valuta valuta in kursnaLista.ListaValuta)
                    {
                        Console.WriteLine("".PadRight(113, '-'));
                        Console.WriteLine("| " + valuta.Naziv.PadRight(30) + valuta.Oznaka.PadRight(20) + valuta.Prodajni.ToString("0.0000").PadRight(20) + valuta.Srednji.ToString("0.0000").PadRight(20) + valuta.Kupovni.ToString("0.0000").PadRight(20) + "|");
                    }
                    Console.WriteLine("".PadRight(113, '-'));
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
                Console.WriteLine("Valuta " + valuta.Oznaka);

                Console.Write("Unesite kupovnu cenu:");
                valuta.Kupovni = Helper.ProveraDecimalnogBroja();

                Console.Write("Unesite prodajnu cenu:");
                valuta.Prodajni = Helper.ProveraDecimalnogBroja();

                Valuta valutaAdd = new Valuta(valuta.Naziv, valuta.Oznaka, valuta.Kupovni, valuta.Prodajni);
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

            SaveData();

            Console.Clear();
            Console.WriteLine("Kursna lista je uspesno dodata!");
        }

        /// <summary>
        /// Representing method for load data
        /// </summary>
        public void LoadData()
        {
            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\\..\\..\\"));

            StreamReader readDataValuta = new StreamReader(lokacija + "\\" + "data" + "\\" + "valuta.csv");
            string dataValuta = readDataValuta.ReadToEnd();

            StreamReader readDataKursnaLista = new StreamReader(lokacija + "\\" + "data" + "\\" + "kursnaLista.csv");
            string dataKursnaLista = readDataKursnaLista.ReadToEnd();

            readDataValuta.Close();
            readDataKursnaLista.Close();

            string[] arrayOfDataValuta = dataValuta.Split("\n");
            string[] arrayOfDataKursnaLista = dataKursnaLista.Split("\n");


            if (dataValuta != "")
            {
                foreach (var valuta in arrayOfDataValuta)
                {
                    Valuta valutaLoad = new Valuta(valuta);
                    listaValuta.Add(valutaLoad);
                }
            }

            if(dataKursnaLista != "")
            {
                foreach (var kursnaListaData in arrayOfDataKursnaLista)
                {
                    KursnaLista kursnaListaLoad = new KursnaLista(kursnaListaData, listaValuta);
                    kursnaLista.Add(kursnaListaLoad);
                }
            }
        }

        /// <summary>
        /// Representing method for saving data
        /// </summary>
        public static void SaveData()
        {
            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\\..\\..\\"));
            StreamWriter saver = new StreamWriter(lokacija + "\\" + "data" + "\\" + "kursnaLista.csv");


            foreach (KursnaLista kursnaLista in kursnaLista)
            {
                saver.WriteLine(kursnaLista.Save(listaValuta));
            }
            saver.Close();
        }
    }

}
