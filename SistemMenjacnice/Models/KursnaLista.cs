using SistemMenjacnice.Utils;
using System;
using System.Collections.Generic;

namespace SistemMenjacnice.Models
{
    /// <summary>
    /// Representing class of the KursnaLista
    /// </summary>
    public class KursnaLista
    {
        /// <summary>
        /// Representing empty contructor of the class
        /// </summary>
        public KursnaLista()
        {

        }

        /// <summary>
        /// Representing empty contructor of the class
        /// </summary>
        public KursnaLista(string datumFormiranja, List<Valuta> listOfValues)
        {
            ID = Helper.IDKursneListe++;
            DatumFormiranja = datumFormiranja;
            listaValuta = listOfValues;
        }

        /// <summary>
        /// Cosntructor with paramethar of the class
        /// </summary>
        /// <param name="data"></param>
        public KursnaLista(string data)
        {
            string[] niz = data.Split(";");

            if (niz.Length != 2)
            {
                Console.WriteLine("Error while reading the file.");
            }
            else
            {
                Int32.TryParse(niz[0], out ID);
                DatumFormiranja = niz[1];
            }

        }

        /// <summary>
        /// Representing property of the ID
        /// </summary>
        public int ID;

        /// <summary>
        /// Representing property of the DatumKreiranja
        /// </summary>
        public string DatumFormiranja;

        /// <summary>
        /// Representing list of the valuta
        /// </summary>
        public List<Valuta> listaValuta = new List<Valuta>();
    }
}
