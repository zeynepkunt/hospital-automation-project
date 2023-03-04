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
    public partial class HtRndvGrntl : Form
    {
        public HtRndvGrntl()
        {
            InitializeComponent();
        }

        string tarih;
        private void HtRndvGrntl_Load(object sender, EventArgs e)
        {
            tarih = DateTime.Today.ToString("yyyy-MM-dd");
            dataGridView1.DataSource = Veritabani.HtRandevu(tarih);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            tarih = dateTimePicker1.Text;
            dataGridView1.DataSource = Veritabani.HtRandevu(tarih);
        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            HastaAnasayfa hastaAnasayfa = new HastaAnasayfa();
            this.Hide();
            hastaAnasayfa.Show();
        }

        private void buttonRandevu_Click(object sender, EventArgs e)
        {
            HastaSayfasiRandevu randevu = new HastaSayfasiRandevu();
            this.Hide();
            randevu.Show();
        }

        private void Button_VkiHesapla_Click(object sender, EventArgs e)
        {
            HastaSayfasi hastaSayfasi = new HastaSayfasi();
            this.Hide();
            hastaSayfasi.Show();
        }

        private void buttonBilgGncl_Click(object sender, EventArgs e)
        {
            HastaSayfasiBilgGncl bilgGncl = new HastaSayfasiBilgGncl();
            this.Hide();
            bilgGncl.Show();
        }
    }
}
