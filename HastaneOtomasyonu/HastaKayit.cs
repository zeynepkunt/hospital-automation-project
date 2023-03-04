using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonu_
{
    public partial class HastaKayit : Form
    {
        public HastaKayit()
        {
            InitializeComponent();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {

            int kontrol = Veritabani.HastaEkle(txtB_TCNo.Text, txtB_Ad.Text, txtB_Soyad.Text, txtB_Sifre.Text, dateTimePicker1.Value, txtB_DgmYer.Text, comboBoxCinsiyet.Text, comboBoxKanGrp.Text, txtB_Tel.Text, txtB_Adres.Text);
            if (kontrol == 1)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                foreach (Control item in this.Controls)
                {
                    if (item.GetType().ToString() == "System.Windows.Forms.TextBox") item.Text = "";
                }
                comboBoxCinsiyet.SelectedIndex = -1;
                comboBoxKanGrp.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Today;
            }

        }

        private void HastaKayit_Load(object sender, EventArgs e)
        {

        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
