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
using System.Data;


namespace HastaneOtomasyonu_
{
    public partial class HastaSayfasiRandevu : Form
    {
        public static string DrID;
        public HastaSayfasiRandevu()
        {
            InitializeComponent();
        }
        private void Button_VkiHesapla_Click(object sender, EventArgs e)
        {
            HastaSayfasi hastaSayfasi = new HastaSayfasi();
            hastaSayfasi.Show();
            this.Hide();
        }

        private void Button_BlgGncl_Click(object sender, EventArgs e)
        {
            HastaSayfasiBilgGncl hastaSayfasiBilgGncl = new HastaSayfasiBilgGncl();
            hastaSayfasiBilgGncl.Show();
            this.Hide();
        }
       
        public static String ConStr = "Server=.;Database=Hastane;Trusted_Connection=True;";

        private void HastaSayfasiRandevu_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            con.Open();
            string _sql = "select distinct (Bolum) from DoktorTablo ";

            SqlCommand cmd = new SqlCommand(_sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBoxBolum.Items.Add(dr[0].ToString());
            }
            con.Close();
        }


        private void cmbBoxBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbDrList.DataSource = Veritabani.DoktorListesi(cmbBoxBolum.Text);
                cmbDrList.DisplayMember = "DrAdSoyad";
                cmbDrList.ValueMember = "Id";
                DrID = Convert.ToString(cmbDrList.SelectedValue);
                cbxSaatKontrol();

            }
            catch
            {
                MessageBox.Show("Verilere Erisilemiyor");
            }
        }

        private void cmbDrList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbxSaatKontrol()
        {
            string tarih = dateTimePicker1.Text.ToString();
            //comboBox1.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            con.Open();
            SqlCommand cmd = new SqlCommand("select Saat from Randevu Where DRID='" + DrID + "' AND Tarih='" + tarih + "'", con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();

            List<string> Saatler = new List<string>() { "09:00", "10:00", "11:00", "12:00", "14:00", "15:00", "16:00" };

            List<string> RandevuluSaat = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToList();
            comboBox1.DataSource = Saatler.Except(RandevuluSaat).ToList();
            comboBox1.DisplayMember = "Saat";
            comboBox1.SelectedIndex = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string x = Convert.ToString(cmbDrList.SelectedValue);
                string tarih = dateTimePicker1.Text.ToString();

                if (cmbBoxBolum.Text!="")
                {
                    Veritabani.RandevuKayit(x, Veritabani.HastaId, tarih, comboBox1.Text);
                    MessageBox.Show("Randevunuz Alinmistir");
                    comboBox1.ResetText();
                    cbxSaatKontrol();
                }
                else
                {
                    MessageBox.Show("Tum alanlari doldurmalisiniz");
                }
            }
            catch
            {
                MessageBox.Show("Uygun randevu saati bulunmamaktadır.");
            }
        }

        private void cmbDrList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DrID = Convert.ToString(cmbDrList.SelectedValue);
        }


        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            HastaAnasayfa hastaAnasayfa = new HastaAnasayfa();
            hastaAnasayfa.Show();
            this.Hide();
        }

        private void buttonRandevu_Click(object sender, EventArgs e)
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
