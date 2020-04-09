using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
namespace BazyDanychProj
{
	public class Klient
	{
		protected int id_klient;
		private String login;
		private String haslo;
		private String email;

		public void SetLogin(String login)
		{
			this.login = login;
		}

		public bool Logowanie(DBHelper dbhelp)
		{
			if (dbhelp.SELECT_WHERE("login,haslo", "klienci", "login = '" + login + "' AND haslo = '" + haslo + "'").HasRows)
			{
				dbhelp.GetConn().Close();
				return true;
			}
			else
			{
				dbhelp.GetConn().Close();
				return false;
			}
		}

        //private Zamowienie[] zamowienies;
        //private KartaPlatnicza[] kartaPlatniczas;
        //private Adres[] adress;

        public void SetHaslo(String haslo)
        {
            this.haslo = haslo;
        }
    }    
}

