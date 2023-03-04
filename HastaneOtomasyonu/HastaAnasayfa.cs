using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonu_
{
    public partial class HastaAnasayfa : Form
    {
        public HastaAnasayfa()
        {
            InitializeComponent();
        }

        private void buttonRandevu_Click(object sender, EventArgs e)
        {
            HastaSayfasiRandevu hastaSayfasiRandevu = new HastaSayfasiRandevu();
            hastaSayfasiRandevu.Show();
            this.Hide();
        }
        public string tckimlikno;
        private void buttonBilgGncl_Click(object sender, EventArgs e)
        {
            HastaSayfasiBilgGncl hastaSayfasiBilgGncl = new HastaSayfasiBilgGncl();
            hastaSayfasiBilgGncl.Show();
            this.Hide();
        }

        private void Button_VkiHesapla_Click(object sender, EventArgs e)
        {
            HastaSayfasi hastaSayfasi = new HastaSayfasi();
            hastaSayfasi.Show();
            this.Hide();
        }

        private void HastaAnasayfa_Load(object sender, EventArgs e)
        {
            lbl_hstAd.Text = " SAYIN "+(Veritabani.HastaAd.ToString()+" "+Veritabani.HastaSoyad.ToString()).ToUpper()+ " KİŞİSEL SAĞLIK\n\nSİSTEMİ SAYFANIZA HOŞ GELDİNİZ.";
        }

        private void lbl_hstAd_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtRndvGrntl htRndvGrntl = new HtRndvGrntl();
            this.Hide();
            htRndvGrntl.Show();
        }
    }
}
