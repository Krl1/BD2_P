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
    public partial class FormKlientZarzadzaj : Form
    {
        Klient activeKlient;
        public FormKlientZarzadzaj(Klient k)
        {
            activeKlient = k;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
