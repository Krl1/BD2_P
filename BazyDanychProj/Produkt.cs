using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BazyDanychProj
{
	public class Produkt
	{
		protected int id_produkt;
		private String kategoria;
		private String nazwa;
		private String nazwaProduc;
		private int ilosc_na_stanie;

		public Produkt(String kategoria, String nazwa, int ilosc, String nazwaProduc)
		{
			this.nazwa = nazwa;
			this.kategoria = kategoria;
			this.ilosc_na_stanie = ilosc;
			this.nazwaProduc = nazwaProduc;
		}

		public String GetKategoria()
		{
			return this.kategoria;
		}

        public String GetNazwa()
        {
            return this.nazwa;
        }


    }

}
