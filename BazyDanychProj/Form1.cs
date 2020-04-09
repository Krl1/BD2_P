using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyDanychProj
{
    public partial class FormLogowanie : Form
    {
        //private DBHelper dbHelp = new DBHelper(String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};","127.0.0.1", "5432", "postgres", "Syncmaster172", "BD_Proj"));
        private DBHelper dbHelp = new DBHelper(String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "admin", "projekt"));
        Klient klient = new Klient();
        public FormLogowanie()
        {
            InitializeComponent();
        }

        private void buttonZmianaLogowania_Click(object sender, EventArgs e)
        {
            if (buttonZmianaLogowania.Text == "Zaloguj jako Administrator")
            {
                buttonZmianaLogowania.Text = "Zaloguj jako klient";
                labelLogowanie.Text = "Logowanie administratora";
            }
            else
            {
                buttonZmianaLogowania.Text = "Zaloguj jako Administrator";
                labelLogowanie.Text = "Logowanie klienta";
            }
        }
        private void FormAd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            textBoxHaslo.Clear();
            textBoxLogin.Clear();
        }
        private void buttonLogowanie_Click(object sender, EventArgs e)
        {
            if (labelLogowanie.Text == "Logowanie administratora")
            {
                if (Logging(textBoxLogin.Text, textBoxHaslo.Text, true))
                {
                    FormAdmin FormAd = new FormAdmin(dbHelp);
                    FormAd.FormClosed += new FormClosedEventHandler(FormAd_FormClosed);
                    this.Hide();
                    FormAd.Show();
                }
                else
                {
                    MessageBox.Show("Podany login, lub hasło jest nieprawidłowe");
                }
            }
            else
            {
                if (Logging(textBoxLogin.Text, textBoxHaslo.Text, false))
                {
                    FormKlient FormAd = new FormKlient(klient,dbHelp);
                    FormAd.FormClosed += new FormClosedEventHandler(FormAd_FormClosed);
                    this.Hide();
                    FormAd.Show();
                }
                else
                {
                    MessageBox.Show("Podany login, lub hasło jest nieprawidłowe");
                }
            }
        }
        private bool Logging(String login, String password, bool is_admin)
        {
            if (labelLogowanie.Text == "Logowanie administratora")
            {
                if (login == "admin" && password == "admin") return true;
                else return false;
            }
            else
            {
                //return true;
                return klient.Logowanie(dbHelp);
            }
        }

        private void FormLogowanie_Load(object sender, EventArgs e)
        {
            dbHelp.ConnectToDataBase();
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            klient.SetLogin(textBoxLogin.Text);
        }

        private void textBoxHaslo_TextChanged(object sender, EventArgs e)
        {
            klient.SetHaslo(textBoxHaslo.Text);
        }
    }
}
