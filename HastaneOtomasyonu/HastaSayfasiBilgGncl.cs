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
    public partial class HastaSayfasiBilgGncl : Form
    {
        public HastaSayfasiBilgGncl()
        {
            InitializeComponent();
        }

        private void buttonRandevu_Click(object sender, EventArgs e)
        {
            HastaSayfasiRandevu hastaSayfasiRandevu = new HastaSayfasiRandevu();
            hastaSayfasiRandevu.Show();
            this.Hide();
        }

        private void Button_VkiHesapla_Click(object sender, EventArgs e)
        {
            HastaSayfasi hastaSayfasi = new HastaSayfasi();
            hastaSayfasi.Show();
            this.Hide();
        }

        public String ConStr = "Server=.;Database=Hastane;Trusted_Connection=True;";
        private void HastaSayfasiBilgGncl_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"server = .; initial catalog = Hastane; integrated security = true");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * from HastaTablosu where TcNo = @1 ", con);

            string tc1 = Veritabani.HastaTC;
            cmd.Parameters.AddWithValue("@1",tc1);
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
                comboBoxKanGrp.Text = dr["KanGrubu"].ToString();
                txtB_Tel.Text = dr["Telefon"].ToString();
                txtB_Adres.Text = dr["Adres"].ToString();
            }
             con.Close();
        }
        private void button_BilgKydt_Click(object sender, EventArgs e)
        {
            Veritabani.HastaBilgGncl(txtB_TCNo.Text, txtB_Ad.Text, txtB_Soyad.Text, txtB_Sifre.Text, dateTimePicker1.Value, txtB_DgmYer.Text, comboBoxCinsiyet.Text, comboBoxKanGrp.Text, txtB_Tel.Text, txtB_Adres.Text);

        }
        public static void HastaBilg()
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
HastaAnasayfa hastaAnasayfa = new HastaAnasayfa();
            hastaAnasayfa.Show();
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
    }
}
