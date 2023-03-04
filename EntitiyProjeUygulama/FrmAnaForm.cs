using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitiyProjeUygulama
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrun fr = new FrmUrun();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frmİstatistik frm = new Frmİstatistik();
            frm.Show();
        }
    }
}
