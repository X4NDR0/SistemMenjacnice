using SistemMenjacnice.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public KursnaLista(DateTime datumFormiranja, List<Valuta> listOfValues)
        {
            ID = Helper.IDKursneListe++;
            DatumFormiranja = datumFormiranja;
            ListaValuta = listOfValues;
        }

        /// <summary>
        /// Cosntructor with paramethar of the class
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listaValuta"></param>
        public KursnaLista(string data, List<Valuta> listaValuta)
        {
            string[] niz = data.Split(";");

            if (niz.Length != 2)
            {
                Console.WriteLine("Error while reading the file.");
            }
            else
            {
                ID += Helper.IDKursneListe;
                DateTime.TryParse(niz[0], out DatumFormiranja);
                string numbers = niz[1];
                string[] ids = numbers.Split(",");

                foreach (var id in ids)
                {
                    Valuta valuta = listaValuta.Where(x => x.ID == Convert.ToInt32(id)).FirstOrDefault();
                    ListaValuta.Add(valuta);
                }

            }

        }

        /// <summary>
        /// Representing property of the ID
        /// </summary>
        public int ID;

        /// <summary>
        /// Representing property of the DatumKreiranja
        /// </summary>
        public DateTime DatumFormiranja;

        /// <summary>
        /// Representing list of the valuta
        /// </summary>
        public List<Valuta> ListaValuta = new List<Valuta>();
    }
}
