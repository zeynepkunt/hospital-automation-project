using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;

namespace HastaneOtomasyonu_
{
    class Veritabani
    {
        public static String ConStr = "Server=.;Database=Hastane;Trusted_Connection=True;";
        public static String HastaTC;
        public static String HastaId;
        public static String DrTC;
        public static int DrID;
        public static String HastaAd;
        public static String HastaSoyad;
        public static String DrAd;
        public static String DrSoyad;


        public static int HastaEkle(string TC, string Ad, string Soyad, string Sifre, DateTime DTarih, string DYeri, string Cins, string KanGrup, string Tel, string Adres)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            try
            {
                if (TC != "" && Ad != "" && Soyad!="" && Sifre != "" && DYeri != "" &&Cins != "" && KanGrup != "" &&Tel != "" &&Adres != "" )
                {
                    Regex rgx = new Regex(@"(\d){11}");
                    if (rgx.Match(TC.ToString()).Success && rgx.Match(Tel.ToString()).Success)
                    {
                        con.Open();
                        string _sql = "insert into HastaTablosu (TcNo, Ad, Soyad, Sifre, DogumTarihi, DogumYeri, Cinsiyet, KanGrubu, Telefon, Adres) Values (@TC, @Ad, @Soyad, @Sifre, @DTarih, @DYeri, @Cins, @KanGrup, @Tel, @Adres) ";
                        SqlCommand cmd = new SqlCommand(_sql, con);
                        cmd.Parameters.AddWithValue("@TC", TC);
                        cmd.Parameters.AddWithValue("@Ad", Ad.ToUpper());
                        cmd.Parameters.AddWithValue("@Soyad", Soyad.ToUpper());
                        cmd.Parameters.AddWithValue("@Sifre", Sifre);
                        cmd.Parameters.AddWithValue("@DTarih", DTarih);
                        cmd.Parameters.AddWithValue("@DYeri", DYeri);
                        cmd.Parameters.AddWithValue("@Cins", Cins);
                        cmd.Parameters.AddWithValue("@KanGrup", KanGrup);
                        cmd.Parameters.AddWithValue("@Tel", Tel);
                        cmd.Parameters.AddWithValue("@Adres", Adres);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Kaydiniz basariyla gerceklesmistir");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("Tc No ve telefon 11 haneli olmalı");
                        return 0;
                    }
                }
                else
                {
                    MessageBox.Show("Tum alanlar doldurulmalidir!");
                    return 0;
                }

            }
            catch
            {

                MessageBox.Show("Kaydiniz Gerceklestirilemedi");
                return 0;
            }


        }
        public static bool HastaGiris(string TC, string Sifre)
        {
            bool girisOK = false;
            if ((TC != "") && (Sifre != ""))
            {
                String user_pass = "";
                SqlConnection Con = new SqlConnection();
                Con.ConnectionString = Veritabani.ConStr;

                try
                {
                    Con.Open();
                    SqlCommand Cmd = new SqlCommand("Select Sifre From HastaTablosu WHERE TcNo=" + TC, Con);
                    user_pass = Convert.ToString(Cmd.ExecuteScalar());

                    SqlCommand Cmd2 = new SqlCommand("Select Id From HastaTablosu WHERE TcNo=" + TC, Con);
                    HastaId = Convert.ToString(Cmd2.ExecuteScalar());
                    SqlCommand Cmd3 = new SqlCommand("Select Ad From HastaTablosu WHERE TcNo=" + TC, Con);
                    HastaAd = Convert.ToString(Cmd3.ExecuteScalar());
                    SqlCommand Cmd4 = new SqlCommand("Select Soyad From HastaTablosu WHERE TcNo=" + TC, Con);
                    HastaSoyad = Convert.ToString(Cmd4.ExecuteScalar());
                    Con.Close();
                    if (Sifre == user_pass)
                    {
                        girisOK = true;
                        HastaTC = TC;
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                        girisOK = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Boyle bir kullanici bulunmamaktadir.\n\n     LUTFEN KAYIT OLUNUZ!");
                }
                

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş olamaz.");
                girisOK = false;
            }

            return girisOK;
        }
        public static void RandevuKayit(string DrID, string HTID, string Tarih, string Saat)
        {
            HTID = HastaId;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            try
            {
                con.Open();
                string _sql = "insert into Randevu (DrID, HTID, Tarih, Saat)  Values ( @DrID, @HTID, @Tarih, @Saat) ";
                SqlCommand cmd = new SqlCommand(_sql, con);
                cmd.Parameters.AddWithValue("@DrID", DrID);
                cmd.Parameters.AddWithValue("@HTID", HTID);
                cmd.Parameters.AddWithValue("@Tarih", Tarih);
                cmd.Parameters.AddWithValue("@Saat", Saat);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

                MessageBox.Show("Kaydiniz Gerceklestirilemedi");
            }


        }
        public static void HastaBilgGncl(string TC, string Ad, string Soyad, string Sifre, DateTime DTarih, string DYeri, string Cins, string KanGrup, string Tel, string Adres)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            try
            {
                con.Open();
                string _sql = "update HastaTablosu set TcNo=@TC, Ad=@Ad, Soyad=@Soyad, Sifre=@Sifre, DogumTarihi=@DTarih, DogumYeri=@DYeri, Cinsiyet=@Cins, KanGrubu=@KanGrup, Telefon=@Tel, Adres=@Adres where TcNo=@TC";
                SqlCommand cmd = new SqlCommand(_sql, con);
                cmd.Parameters.AddWithValue("@TC", TC);
                cmd.Parameters.AddWithValue("@Ad", Ad);
                cmd.Parameters.AddWithValue("@Soyad", Soyad);
                cmd.Parameters.AddWithValue("@Sifre", Sifre);
                cmd.Parameters.AddWithValue("@DTarih", DTarih);
                cmd.Parameters.AddWithValue("@DYeri", DYeri);
                cmd.Parameters.AddWithValue("@Cins", Cins);
                cmd.Parameters.AddWithValue("@KanGrup", KanGrup);
                cmd.Parameters.AddWithValue("@Tel", Tel);
                cmd.Parameters.AddWithValue("@Adres", Adres);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Bilgileriniz Guncellenmistir");
            }
            catch
            {

                MessageBox.Show("Veritabanina erisilemiyor");
            }


        }

        public static void DrBilgGncl(string TC, string Ad, string Soyad, string Sifre, DateTime DTarih, string DYeri, string Cins, string Tel, string Adres, string Bolum)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            try
            {
                con.Open();
                string _sql = "update DoktorTablo set TcNo=@TC, Ad=@Ad, Soyad=@Soyad, Sifre=@Sifre, DogumTarihi=@DTarih, DogumYeri=@DYeri, Cinsiyet=@Cins, Telefon=@Tel, Adres=@Adres, Bolum=@Bolum where TcNo=@TC";
                SqlCommand cmd = new SqlCommand(_sql, con);
                cmd.Parameters.AddWithValue("@TC", TC);
                cmd.Parameters.AddWithValue("@Ad", Ad);
                cmd.Parameters.AddWithValue("@Soyad", Soyad);
                cmd.Parameters.AddWithValue("@Sifre", Sifre);
                cmd.Parameters.AddWithValue("@DTarih", DTarih);
                cmd.Parameters.AddWithValue("@DYeri", DYeri);
                cmd.Parameters.AddWithValue("@Cins", Cins);
                cmd.Parameters.AddWithValue("@Tel", Tel);
                cmd.Parameters.AddWithValue("@Adres", Adres);
                cmd.Parameters.AddWithValue("@Bolum", Bolum);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Bilgileriniz Guncellenmistir");
            }
            catch
            {
                MessageBox.Show("Veritabanina erisilemiyor");
            }


        }
        public static bool DrGiris(string TC, string Sifre)
        {
            bool girisOK = false;
            if ((TC != "") && (Sifre != ""))
            {
                String user_pass = "";
                SqlConnection Con = new SqlConnection();
                Con.ConnectionString = Veritabani.ConStr;

                try
                {
                    Con.Open();
                    string _sql = "Select Sifre From DoktorTablo WHERE TcNo='" + TC + "'";
                    SqlCommand Cmd = new SqlCommand(_sql, Con);
                    user_pass = Convert.ToString(Cmd.ExecuteScalar());

                    SqlCommand Cmd2 = new SqlCommand("Select Id From DoktorTablo WHERE TcNo='" + TC + "'", Con);
                    DrID = Convert.ToInt32(Cmd2.ExecuteScalar());

                    SqlCommand Cmd3 = new SqlCommand("Select Ad From DoktorTablo WHERE TcNo='" + TC + "'", Con);
                    DrAd = Convert.ToString(Cmd3.ExecuteScalar());
                    SqlCommand Cmd4 = new SqlCommand("Select Soyad From DoktorTablo WHERE TcNo='" + TC + "'", Con);
                    DrSoyad = Convert.ToString(Cmd4.ExecuteScalar());

                    Con.Close();
                    if (Sifre == user_pass)
                    {
                        girisOK = true;
                        DrTC = TC;
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                        girisOK = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Kullanıcı bilgileri ALINAMADI.");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş olamaz.");
                girisOK = false;
            }
            return girisOK;
        }

        public static List<string> HastaListesi()
        {
            List<string> hastalar = new List<string>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            con.Open();
            string _sql = "select Ad, Soyad from HastaTablosu ";

            SqlCommand cmd = new SqlCommand(_sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                hastalar.Add(dr["Ad"].ToString()+" "+dr["Soyad"].ToString());
                // hastalar.Add(dr["Soyad"].ToString());
            }
            con.Close();
            return hastalar;
        }

        public static DataTable randevu = new DataTable();

        public static DataTable Randevu(string gun)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            con.Open();
            string _sql = "Select DR.Ad DoktorAd, DR.Soyad DoktorSoyad, Dr.Bolum, HT.Ad + ' ' + HT.Soyad HASTADISOYADI, R.Tarih, R.Saat " +
                           "From Randevu R " +
                           "inner join DoktorTablo DR on R.DrID = DR.Id " +
                           "inner join HastaTablosu HT on R.HTID = HT.Id " +
                            "Where DR.Id =" + DrID + " AND Tarih ='" + gun + "'";

            SqlCommand cmd = new SqlCommand(_sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            randevu.Clear();
            da.Fill(randevu);
            return randevu;
        }
        public static DataTable HtRandevu(string gun)
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            con.Open();
            string _sql = "Select DR.Ad DoktorAd, DR.Soyad DoktorSoyad, Dr.Bolum, R.Tarih, R.Saat " +
                           "From Randevu R " +
                           "inner join DoktorTablo DR on R.DrID = DR.Id " +
                           "inner join HastaTablosu HT on R.HTID = HT.Id " +
                            "Where HT.Id =" + HastaId + " AND Tarih ='" + gun + "'";

            SqlCommand cmd = new SqlCommand(_sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            randevu.Clear();
            da.Fill(randevu);
            return randevu;
        }

        public static DataTable DoktorListesi(string bolum)
        {
            DataTable drlist = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConStr;
            con.Open();
            string _sql = "select Id, Ad + ' '+ Soyad DrAdSoyad, Bolum From DoktorTablo Where Bolum='" + bolum + "'";
            SqlCommand cmd = new SqlCommand(_sql, con);
            SqlDataAdapter ad = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            ad.SelectCommand = cmd;
            ad.Fill(drlist);
            ad.Dispose();
            return drlist;

        }



    }
}
