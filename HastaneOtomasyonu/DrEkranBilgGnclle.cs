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
    public partial class DrEkranBilgGnclle : Form
    {
        public DrEkranBilgGnclle()
        {
            InitializeComponent();
        }
        
        public String ConStr = "Server=.;Database=Hastane;Trusted_Connection=True;";
        private void DrEkranBilgGnclle_Load(object sender, EventArgs e)
        {
            label1.Text = " DR. " + (Veritabani.DrAd.ToString() + " " + Veritabani.DrSoyad.ToString()).ToUpper();
            SqlConnection con = new SqlConnection(@"server = .; initial catalog = Hastane; integrated security = true");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * from DoktorTablo where TcNo = @1 ", con);

            string tc1 = Veritabani.DrTC;
            cmd.Parameters.AddWithValue("@1", tc1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtB_TCNo.Text = dr["TcNo"].ToString();
                txtB_Sifre.Text = dr["Sifre"].ToString();
                txtB_Ad.Text = dr["Ad"].ToString();
                txtB_Soyad.Text = dr["Soyad"].ToString();
                dateTimePicker1.Text = dr["DogumTarihi"].ToString();
                txtB_DgmYer.Text = dr["DogumYeri"].ToString();
                comboBoxCinsiyet.Text = dr["Cinsiyet"].ToString();
                txtB_Tel.Text = dr["Telefon"].ToString();
                txtB_Adres.Text = dr["Adres"].ToString();
                txtB_Bolum.Text = dr["Bolum"].ToString();
            }
            con.Close();
        }

        private void button_BilgKydt_Click(object sender, EventArgs e)
        {
             Veritabani.DrBilgGncl(txtB_TCNo.Text, txtB_Ad.Text, txtB_Soyad.Text, txtB_Sifre.Text, dateTimePicker1.Value, txtB_DgmYer.Text, comboBoxCinsiyet.Text, txtB_Tel.Text, txtB_Adres.Text,txtB_Bolum.Text);
        }

        private void buttonBilgGnclle_Click(object sender, EventArgs e)
        {

        }

        
        private void buttonHastGoruntule_Click_1(object sender, EventArgs e)
        {
            DoktorEkran doktorEkran = new DoktorEkran();
            doktorEkran.Show();
            this.Hide();
        }

        private void btnHastaListesi_Click(object sender, EventArgs e)
        {
            HastaListesi hstlst = new HastaListesi();
            hstlst.Show();
            this.Hide();
        }
    }
}
