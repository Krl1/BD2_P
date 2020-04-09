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
    public partial class FormAdminDodaj : Form
    {
        private Aplikacja aplikacja;
        private DBHelper dbHelp;
        private List<String> firmy;
        private String kategoria, nazwa, producent, rozmiar, ilosc, cena;
        public FormAdminDodaj(Aplikacja aplikacja, DBHelper dbHelp)
        {
            this.dbHelp = dbHelp;
            this.aplikacja = aplikacja;
            InitializeComponent();
            firmy = dbHelp.FULL_QUESTION("SELECT nazwa FROM producenci;");
            foreach(String firma in firmy)
            {
                comboBox1.Items.Add(firma);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategoria = textBox5.Text;
            nazwa = textBox1.Text;
            producent = comboBox1.SelectedItem.ToString();
            producent = char.ToUpper(producent[0]) + producent.Substring(1);
            rozmiar = textBox2.Text;
            ilosc = textBox3.Text;
            cena = textBox4.Text;
            List<String> id_producent = dbHelp.FULL_QUESTION("SELECT id_producent FROM producenci WHERE nazwa='"+producent+"';");
            aplikacja.DodajNowyProdukt(id_producent[0], kategoria, nazwa, rozmiar, ilosc, cena);
            this.Close();
        }

        private void FormAdminDodaj_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        
    }
}
