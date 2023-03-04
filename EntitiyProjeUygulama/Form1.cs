using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitiyProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntitiyProjeEntities efp = new DbEntitiyProjeEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategori = efp.TBLKATEGORİ.ToList();
            dataGridView1.DataSource = kategori;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLKATEGORİ kategori = new TBLKATEGORİ();
            kategori.AD = txtKategoriAd.Text;
            efp.TBLKATEGORİ.Add(kategori);
            efp.SaveChanges();
            MessageBox.Show("Ekleme işlemi yapıldı");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int ssil = Convert.ToInt32(txtkatgorid.Text);
            var ktgr = efp.TBLKATEGORİ.Find(ssil);
            efp.TBLKATEGORİ.Remove(ktgr);
            efp.SaveChanges();
            MessageBox.Show("Kategori silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int ssil = Convert.ToInt32(txtkatgorid.Text);
            var ktgr = efp.TBLKATEGORİ.Find(ssil);
            ktgr.AD = txtKategoriAd.Text;
            efp.SaveChanges();
            MessageBox.Show("Bilgiler Güncellendi");
        }
    }
}
