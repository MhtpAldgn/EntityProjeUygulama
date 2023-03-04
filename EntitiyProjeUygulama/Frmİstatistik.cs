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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbEntitiyProjeEntities efp = new DbEntitiyProjeEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            lblKategoriSayısı.Text = efp.TBLKATEGORİ.Count().ToString();
            lblUrunSayısı.Text = efp.TBLURUN.Count().ToString();
            lblAktifMusteri.Text = efp.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            lblPasifMusteri.Text = efp.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            lblToplamStok.Text = efp.TBLURUN.Sum(y => y.STOK).ToString();
            lblKasaTutar.Text = efp.TBLURUN.Sum(z => z.FIYAT).ToString() + "TL";
            lblEnYuksekFiyat.Text = (from x in efp.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            lblEnDusukFiyat.Text = (from x in efp.TBLURUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            lblBeyazEsya.Text = efp.TBLURUN.Count(x => x.KATEGORİ == 1).ToString();
            lblBuzdolabı.Text = efp.TBLURUN.Count(y => y.URUNAD == "BUZDOLABI").ToString();
            lblToplamSehir.Text = (from a in efp.TBLMUSTERI select a.SEHIR).Distinct().Count().ToString();
            lblEnFazlaMarka.Text = efp.MARKAGETIR().FirstOrDefault();

        }
    }
}
