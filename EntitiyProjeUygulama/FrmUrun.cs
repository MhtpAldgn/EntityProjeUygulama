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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntitiyProjeEntities efp = new DbEntitiyProjeEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from u in efp.TBLURUN
                                        select new
                                        {
                                            u.URUNID,
                                            u.URUNAD,
                                            u.MARKA,
                                            u.STOK,
                                            u.FIYAT,
                                            u.DURUM,
                                            u.TBLKATEGORİ.AD,

                                        }).ToList();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.KATEGORİ = int.Parse(cmbKategori.SelectedValue.ToString());
            t.DURUM = true;
            t.STOK = short.Parse(txtStok.Text);
            efp.TBLURUN.Add(t);
            efp.SaveChanges();
            MessageBox.Show("Ürün Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtİd.Text);
            var urun = efp.TBLURUN.Find(x);
            efp.TBLURUN.Remove(urun);
            efp.SaveChanges();
            MessageBox.Show("Ürün Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtİd.Text);
            var urun = efp.TBLURUN.Find(x);
            urun.STOK = short.Parse(txtStok.Text);
            urun.URUNAD = txtUrunAd.Text;
            urun.MARKA = txtMarka.Text;
            efp.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from k in efp.TBLKATEGORİ select new { k.AD, k.ID }).ToList();
            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember = "AD";
            cmbKategori.DataSource = kategoriler;

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            //txtİd.Text = cmbKategori.SelectedValue.ToString();
        }
    }
}
