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
using System.Windows.Controls;

namespace BazyDanychProj
{
    public partial class FormAdmin : Form
    {
        private DBHelper dbHelp;
        private Aplikacja aplikacja;
        private String selectedItem;
        public FormAdmin(DBHelper dbHelp)
        {
            this.dbHelp = dbHelp;
            aplikacja = new Aplikacja(dbHelp);
            InitializeComponent();
        }

        private void buttonDeleteProd_Click(object sender, EventArgs e)
        {
            
        }

        private void formAdminDodaj_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            listBox1.Items.Clear();
            listBox1.ResetText();
        }

        private void buttonAddProd_Click(object sender, EventArgs e)
        {
            FormAdminDodaj formAdminDodaj = new FormAdminDodaj(aplikacja, dbHelp);
            formAdminDodaj.FormClosed += new FormClosedEventHandler(formAdminDodaj_FormClosed);
            this.Hide();
            formAdminDodaj.Show();
        }

        private void formAdminEdytuj_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            listBox1.Items.Clear();
            listBox1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FormAdminEdytuj formAdminEdytuj = new FormAdminEdytuj(selectedItem, aplikacja);
            formAdminEdytuj.FormClosed += new FormClosedEventHandler(formAdminEdytuj_FormClosed);
            this.Hide();
            formAdminEdytuj.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.ResetText();
            listBox1.Items.Clear();
            listBox1.Items.Add("id_produkt;nazwa;kategoria;nazwa_producenta;rozmiar;cena");
            List<String> wszystkieProdukty = aplikacja.PrzegladajProdukty();
            aplikacja.WyswietlProdukty(listBox1, wszystkieProdukty);
            wszystkieProdukty.Clear();
            
            
            /////////////////////////////////////////
            /////////////////////////////////////////
            /////////////////////////////////////////
            /////////// POBIERANIE PRODUKTÓW ////////
            /////////// Z BAZY DANYCH        ////////
            /////////////////////////////////////////
            /////////////////////////////////////////
            /////////////////////////////////////////

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = listBox1.SelectedItem.ToString();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
