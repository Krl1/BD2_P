using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BazyDanychProj
{
	public class Zamowienie
	{
		protected int id_zamowienie;
		private int id_klient;
		private DateTime data_zamowienia;
		private DateTime data_wysylki;
		private String status_wysylki;
		private DateTime data_platnosci;
		private float kwota;
		private String status_platnosci;
	}
}

