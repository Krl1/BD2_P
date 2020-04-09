using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BazyDanychProj
{
	public class Adres
	{
		protected int id_adres;
		private String adres;
		private String miasto;
		private String wojewodztwo;
		private String kraj;
		private List<Klient> listaKlientow = new List<Klient>();
	}

}
