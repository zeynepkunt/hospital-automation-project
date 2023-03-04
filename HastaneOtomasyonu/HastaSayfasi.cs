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
    public partial class HastaSayfasi : Form
    {
        public HastaSayfasi()
        {
            InitializeComponent();
        }

        private void btn_vkiHesapla_Click(object sender, EventArgs e)
        {
            double boy;
            double kilo;
            double vki;
            boy = Convert.ToDouble(txtB_boy.Text);
            kilo = Convert.ToDouble(txtB_kilo.Text);

            vki = kilo / (boy * boy);
            lbl_VkiSonuc.Text = vki.ToString();
        }

        private void buttonRandevu_Click(object sender, EventArgs e)
        {
            HastaSayfasiRandevu hastaSayfasiRandevu = new HastaSayfasiRandevu();
            hastaSayfasiRandevu.Show();
            this.Hide();
        }

        private void button_BigGncl_Click(object sender, EventArgs e)
        {
            HastaSayfasiBilgGncl hastaSayfasiBilgGncl = new HastaSayfasiBilgGncl();
            hastaSayfasiBilgGncl.Show();
            this.Hide();
        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            HastaAnasayfa hastaAnasayfa = new HastaAnasayfa();
            hastaAnasayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtRndvGrntl htRndvGrntl = new HtRndvGrntl();
            this.Hide();
            htRndvGrntl.Show();
        }

        private void Button_VkiHesapla_Click(object sender, EventArgs e)
        {

        }
    }
}
