using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BazyDanychProj
{
	public class Aplikacja
	{
		private DBHelper dbHelp;

        public Aplikacja(DBHelper dbHelp)
        {
            this.dbHelp = dbHelp;
        }

        public List<String> PrzegladajProdukty()
        {
            List<String> result = dbHelp.FULL_QUESTION("SELECT id_produkt, produkty.nazwa, kategoria, producenci.nazwa AS nazwa_producenta, rozmiar, cena FROM produkty JOIN producenci USING (id_producent);");
            return result;
        }
   
        internal void WyswietlProdukty(System.Windows.Forms.ListBox listBox, List<string> wszystkieProdukty)
        {
            foreach (String item in wszystkieProdukty)
            {
                listBox.Items.Add(item);
            }
        }

        public void aktualizujProdukt(String nazwa_stara, String nazwa, String cena_stara, String cena, String rozmiar_stary, String rozmiar)
        {

            dbHelp.QUERY_NO_OUTPUT("UPDATE produkty SET " + "nazwa = '" + nazwa + "', rozmiar = '" + rozmiar + "', cena = " + cena + " WHERE nazwa='" + nazwa_stara + "' AND rozmiar='" + rozmiar_stary + "';");
        }

		public void DodajNowyProdukt(String id_producent, String kategoria, String nazwa, String rozmiar, String ilosc, String cena)
		{
            dbHelp.FULL_QUESTION("INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena) VALUES (" + id_producent + ", '" + kategoria + "', '" + nazwa + "', '" + rozmiar + "', " + ilosc + ", " + cena + ");");
		}
		
	}
}

