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
    public partial class FormKlient : Form
    {
        Klient klient;
        DBHelper dbHelp;
        List<Produkt> listaProduktów = new List<Produkt>();
        public FormKlient(Klient k,DBHelper db)
        {
            dbHelp = db;
            klient = k;
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormKlientZarzadzaj FormKZ = new FormKlientZarzadzaj(klient);
            FormKZ.FormClosed += new FormClosedEventHandler(FormKZ_FormClosed);
            this.Hide();
            FormKZ.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormKlientZamowienia FormKZA = new FormKlientZamowienia(klient);
            FormKZA.FormClosed += new FormClosedEventHandler(FormKZ_FormClosed);
            this.Hide();
            FormKZA.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void FormKZ_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void FormKlient_Load(object sender, EventArgs e)
        {
            NpgsqlDataReader read = dbHelp.PROCEDURE("sprawdzstanmagazynu");
            while (read.Read())
            {
                Produkt pr = new Produkt(read.GetFieldValue<string>(0), read.GetFieldValue<string>(1), read.GetFieldValue<int>(2), read.GetFieldValue<string>(3)) ;
                listaProduktów.Add(pr);
                listBox1.Items.Add(pr.GetNazwa() + " " + pr.GetKategoria());
            }
            dbHelp.GetConn().Close();

            read = dbHelp.SELECT("nazwa", "producenci");
            while (read.Read())
            {
                comboBox1.Items.Add(read.GetFieldValue<string>(0));
            }
            dbHelp.GetConn().Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
