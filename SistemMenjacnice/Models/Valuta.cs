using SistemMenjacnice.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemMenjacnice.Models
{
    /// <summary>
    /// Class representing Valuta
    /// </summary>
    public class Valuta
    {
        /// <summary>
        /// Representing empty contructor of the class
        /// </summary>
        public Valuta()
        {

        }

        /// <summary>
        /// Representing constructor with 2 parameters.
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="kupovni"></param>
        /// <param name="prodajni"></param>
        public Valuta(string naziv,double kupovni,double prodajni)
        {
            ID = Helper.IDValute++;
            Naziv = naziv;
            Prodajni = prodajni;
            Srednji = (prodajni + kupovni) / 2;
            Kupovni = kupovni;
        }

        /// <summary>
        /// Constructor with parametar of the class
        /// </summary>
        /// <param name="data"></param>
        public Valuta(string data)
        {
            string[] niz = data.Split(";");

            if (niz.Length != 4)
            {
                Console.WriteLine("Error while reading the file.");
            }else
            {
                ID = Helper.IDValute++;
                Int32.TryParse(niz[0], out ID);
                Naziv = niz[1];
                Double.TryParse(niz[2], out Prodajni);
                Double.TryParse(niz[3], out Kupovni);
                Srednji = (Prodajni + Kupovni) / 2;
            }
        }

        /// <summary>
        /// Representing property of the id
        /// </summary>
        public int ID;

        /// <summary>
        /// Representing property of the name
        /// </summary>
        public string Naziv;

        /// <summary>
        /// Representing property of the prices
        /// </summary>
        public double Kupovni;

        /// <summary>
        /// Representing property of the price
        /// </summary>
        public double Prodajni;

        /// <summary>
        /// Representing property of the price
        /// </summary>
        public double Srednji;

    }
}
