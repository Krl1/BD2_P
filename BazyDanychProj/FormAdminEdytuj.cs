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
    public partial class FormAdminEdytuj : Form
    {
        private Aplikacja aplikacja;
        private String selectedItem;
        private String[] dane;
        private char[] separator = { ',', '\r', '\n' };
        String cena_stara, cena_nowa, nazwa, rozmiar;
        public FormAdminEdytuj(String selectedItem, Aplikacja aplikacja)
        {
            this.aplikacja = aplikacja;
            this.selectedItem = selectedItem;
            dane = selectedItem.Split(separator);
            cena_stara = dane[5] + '.' + dane[6];
            InitializeComponent();
            this.textBox1.Text = this.dane[1]; //nazwa
            this.textBox2.Text = this.dane[4]; //rozmiar
            this.textBox4.Text = this.cena_stara; //cena
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.nazwa = this.textBox1.Text;
            this.rozmiar = this.textBox2.Text;
            this.cena_nowa = this.textBox4.Text;
            aplikacja.aktualizujProdukt(dane[1], this.nazwa, this.cena_stara, this.cena_nowa, dane[4], this.rozmiar);
            this.Close();
        }

        private void FormAdminEdytuj_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
