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
    public partial class DoktorEkran : Form
    {
        public DoktorEkran()
        {
            InitializeComponent();
        }

        string tarih;
        private void DoktorEkran_Load(object sender, EventArgs e)
        {
            tarih = DateTime.Today.ToString("yyyy-MM-dd");
            dataGridView1.DataSource = Veritabani.Randevu(tarih);
        }

        private void buttonBilgGnclle_Click(object sender, EventArgs e)
        {
            DrEkranBilgGnclle drEkranBilgGnclle = new DrEkranBilgGnclle();
            drEkranBilgGnclle.Show();
            this.Hide();
        }

        private void buttonHastGoruntule_Click(object sender, EventArgs e)
        {

        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat= "yyyy-MM-dd";
            tarih = dateTimePicker1.Text;
            dataGridView1.DataSource = Veritabani.Randevu(tarih);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = "DR. " + (Veritabani.DrAd.ToString() + " " + Veritabani.DrSoyad.ToString()).ToUpper();
        }

        private void btnHastaListesi_Click(object sender, EventArgs e)
        {
            HastaListesi hstlst = new HastaListesi();
            hstlst.Show();
            this.Hide();
        }
    }
}
