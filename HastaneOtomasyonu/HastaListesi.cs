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
    public partial class HastaListesi : Form
    {
        public HastaListesi()
        {
            InitializeComponent();
        }

        private void HastaListesi_Load(object sender, EventArgs e)
        {
            label1.Text = " DR. " + (Veritabani.DrAd.ToString() + " " + Veritabani.DrSoyad.ToString()).ToUpper();
            listBox1.DataSource= Veritabani.HastaListesi();
        }

        private void buttonHastGoruntule_Click(object sender, EventArgs e)
        {
            DoktorEkran doktorEkran = new DoktorEkran();
            doktorEkran.Show();
            this.Hide();
        }

        private void buttonBilgGnclle_Click(object sender, EventArgs e)
        {
            DrEkranBilgGnclle drEkranBilgGnclle = new DrEkranBilgGnclle();
            drEkranBilgGnclle.Show();
            this.Hide();
        }
    }
}
