using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonu_
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();      
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonHastaGiris_Click(object sender, EventArgs e)
        {
            bool giris_durum = false;
            giris_durum = Veritabani.HastaGiris(txtB_UserName.Text, txtB_UserPass.Text);

            if (giris_durum == true)
            {
                HastaAnasayfa hastaAnasayfa = new HastaAnasayfa();
                hastaAnasayfa.Show();
                this.Hide();
            }
            else
            {
                txtB_UserName.Clear();
                txtB_UserPass.Clear();
            }
        }
        
        private void buttonDrGiris_Click(object sender, EventArgs e)
        {
            bool giris_durum = false;
            giris_durum = Veritabani.DrGiris(txtB_UserNameDr.Text, txtB_UserPassDr.Text);
            if (giris_durum == true)
            {
                DoktorEkran doktorEkran = new DoktorEkran();
                doktorEkran.Show();
                this.Hide();
            }
            else
            {
                txtB_UserNameDr.Clear();
                txtB_UserPassDr.Clear();
            }
        }
        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            HastaKayit hastaKayit = new HastaKayit();
            hastaKayit.Show();
            this.Hide();
        }
        private void lbl_kayit_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {


        }


        private void txtB_UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_hastaBaslik_Click(object sender, EventArgs e)
        {

        }
    }
}
