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

namespace btı2022proje
{
    public partial class kullanici : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-QTHG79F;Initial Catalog=bankauyg2022;User ID=sa;Password=123456789");
        bool emailDegistiMi = false;
        public kullanici()
        {
            InitializeComponent();
            panelkapat();

        }
        private void panelkapat()
        {
            kul_kayıt.Visible = false;
            musyenkay.Visible = false;
            Banka_gelgid_panl.Visible = false;
            Islem_tur.Visible = false;
            kulgiris.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void kullanici_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankauyg2022DataSet2.Banka_Rapor' table. You can move, or remove it, as needed.
            this.banka_RaporTableAdapter.Fill(this.bankauyg2022DataSet2.Banka_Rapor);




        }

        private void buttonKlcUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxKlcUpdateKlcad.Text == "" || textBoxKlcUpdateIsim.Text == "" || textBoxKlcUpdateSifre.Text == "" || textBoxKlcUpdateEmail.Text == "")
            {
                MessageBox.Show("Girişler boş geçilemez!");
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand komut = new SqlCommand("insert into Kullaniciler (Kullanıcı_Adı,Isim,Sifre,Email) values( @username, @isim, @sifre, @email)", connection);
                komut.Parameters.AddWithValue("@username", textBoxKlcUpdateKlcad.Text);
                komut.Parameters.AddWithValue("@isim", textBoxKlcUpdateIsim.Text);
                komut.Parameters.AddWithValue("@sifre", textBoxKlcUpdateSifre.Text);
                komut.Parameters.AddWithValue("@email", textBoxKlcUpdateEmail.Text);
                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kayıt Başarılı");
            }
            catch (Exception hata)
            {
                MessageBox.Show($"HATA: {hata.Message}");
            }



        }

        private void menuKlcItemYeni_Click(object sender, EventArgs e)
        {
            panelkapat();
            kul_kayıt.Visible = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem1.Text == "")
            {
                MessageBox.Show("Lütfen Bir Arama Yapınız.");
                return;
            }
            kulgiris.Visible = true;
            kul_kayıt.Visible = false;
            musyenkay.Visible = false;
            Banka_gelgid_panl.Visible = false;
            Islem_tur.Visible = false;
        }

        private void menuMusteriItemYeniHesap_Click(object sender, EventArgs e)
        {
            panelkapat();
            musyenkay.Visible = true;

        }

        private void menuItemRapor_Click(object sender, EventArgs e)
        {
            panelkapat();
            Banka_gelgid_panl.Visible = true;
        }

        private void işlemTürüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelkapat();
            Islem_tur.Visible = true;

        }

        private void buttonIslemTurEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxIslemTur.Items.IndexOf(textBoxYeniIslem.Text) != -1) MessageBox.Show("Kayıtlı Bilgi Vardır.");

                //connection.State != ConnectionState.Open
                {
                    connection.Open();
                }
                SqlCommand komut = new SqlCommand("insert into Islem_Turler values Islem= '" + comboBoxIslemTur.SelectedItem.ToString() + "'", connection);


                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("İşlem Başarılı");
                comboBoxIslemTur.Items.IndexOf(textBoxYeniIslem.Text);
            }
            catch (Exception hata)
            {
                MessageBox.Show($"HATA: {hata.Message}");
            }

        }

        private void buttonIslemTurSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand komut = new SqlCommand("delete Islem_Turler where Islem= '"+ comboBoxIslemTur.SelectedItem.ToString()+"'", connection);


                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("İşlem Silindi");
            comboBoxIslemTur.Items.Remove(comboBoxIslemTur.SelectedItem);
            }
            catch (Exception hata)
            {
                MessageBox.Show($"HATA: {hata.Message}");
            }
        }

        private void kullaniGetir_Click(object sender, EventArgs e)
        {
            panelkapat();
            kul_kayıt.Visible = true;
            if (textBoxMenuSearch.Text=="")
            {
                MessageBox.Show("Numara alanı boş bırakılamaz");
                return;
            }
            connection.Open();
            SqlCommand komut = new SqlCommand($"select * from Kullaniciler where no = {textBoxMenuSearch.Text}", connection);

            SqlDataReader cevap = komut.ExecuteReader();
            if (cevap.HasRows)
            {
                while(cevap.Read())
                {
                    Console.WriteLine("{0}\t{1}", cevap.GetInt32(0),
                    cevap.GetString(1));
                    string[] adSoyad = cevap.GetString(1).Split(' ');
                    string ad = adSoyad[0];
                    string soyad = adSoyad[1];
                }
            }
            connection.Close();
        }

        private void hesapGetir_Click(object sender, EventArgs e)
        {
            panelkapat();
            musyenkay.Visible = true;
            if(textBoxMenuSearch.Text == "")
            {
                MessageBox.Show("Numara alanı boş bırakılamaz");
                return;
            }
            connection.Open();
            SqlCommand komut = new SqlCommand($"select * from Musteriler where no = {textBoxMenuSearch.Text}", connection);


            SqlDataReader cevap = komut.ExecuteReader();
            if (cevap.HasRows)
            {
                while (cevap.Read())
                {
                    Console.WriteLine("{0}\t{1}", cevap.GetInt32(0),
                        cevap.GetString(1));
                    string[] adSoyad = cevap.GetString(1).Split(' ');
                    string ad = adSoyad[0];
                    string soyad = adSoyad[1];
                    textBoxMyeniAd.Text = ad;
                    textBoxMyeniSoyad.Text = soyad;
                    textBoxMyeniTel.Text = cevap.GetString(2);
                    textBoxMyeniEmail.Text = cevap.GetString(3);
                    textBoxMyeniAdres.Text = cevap.GetString(4);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }

            cevap.Close();
        }

        private void buttonMusteriGuncelle_Click(object sender, EventArgs e)
        {
            string guncelleme = "update Musteriler set Isim_Soyisim = @isim, Telefon =@Telefon ,Adress=@adress where no = @musteriNo ";
            string emailleGuncelleme = "update Musteriler set Isim_Soyisim = @isim, Telefon =@Telefon ,Adress=@adress, Email = @email where no = @musteriNo";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                if (textBoxMyeniAd.Text == "" || textBoxMyeniSoyad.Text == "" || textBoxMyeniTel.Text == "" || textBoxMyeniAdres.Text == "" || textBoxMyeniEmail.Text == "")
                {
                    MessageBox.Show("Hesap Güncellenemiyor Çünkü Bilgilerinizi Boş Bıraktınız");
                }
                else
                {
                    SqlCommand update = new SqlCommand(emailDegistiMi == true ? emailleGuncelleme : guncelleme, connection);
                    update.Parameters.AddWithValue("@isim", textBoxMyeniAd.Text + " " + textBoxMyeniSoyad.Text);
                    update.Parameters.AddWithValue("@Telefon", textBoxMyeniTel.Text);
                    update.Parameters.AddWithValue("@email", textBoxMyeniEmail.Text);
                    update.Parameters.AddWithValue("@adress", textBoxMyeniAdres.Text);
                    update.Parameters.AddWithValue("@musteriNo", textBoxMenuSearch.Text);
                    update.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Güncelleme Başarılı");
                }
            }
            catch (Exception hata)
            
            {
                MessageBox.Show($"HATA: {hata.Message}");
            }
           
        }

        private void buttonMusteriEkle_Click(object sender, EventArgs e)
        {
            string kayıt = "insert into Musteriler (Isim_Soyisim,Telefon,Email,Adress) values( @isim, @Telefon, @email, @adress)";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                if (textBoxMyeniAd.Text == "" || textBoxMyeniSoyad.Text == "" || textBoxMyeniTel.Text == "" || textBoxMyeniAdres.Text == "" || textBoxMyeniEmail.Text == "")
                {
                    MessageBox.Show("Hesap Eklenemiyor Çünkü Bilgilerinizi Boş Bıraktınız");
                }
                else
                {
                    SqlCommand insertinto = new SqlCommand(kayıt, connection);
                    insertinto.Parameters.AddWithValue("@isim", textBoxMyeniAd.Text + " " + textBoxMyeniSoyad.Text);
                    insertinto.Parameters.AddWithValue("@Telefon", textBoxMyeniTel.Text);
                    insertinto.Parameters.AddWithValue("@email", textBoxMyeniEmail.Text);
                    insertinto.Parameters.AddWithValue("@adress", textBoxMyeniAdres.Text);
                    insertinto.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Kayıt  Başarılı");
                    MessageBox.Show("Hesap Eklendi");
                }

            }
            catch (Exception hata)

            {
                MessageBox.Show($"HATA: {hata.Message}");
            }


        }

        private void buttonHesapSil_Click(object sender, EventArgs e)
        {
            string kayıtsil = "delete Musteriler where no = @musteriNo";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand insertinto = new SqlCommand(kayıtsil, connection);
                insertinto.Parameters.AddWithValue("@musteriNo", textBoxMyeniMusteriNo.Text);
                insertinto.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Silme İşlemi Başarılı");
            }
            catch (Exception hata)

            {
                MessageBox.Show($"HATA: {hata.Message}");
            }
        }

        private void textBoxMyeniEmail_TextChanged(object sender, EventArgs e)
        {
            emailDegistiMi = true;
        }

        private void comboBoxIslemTur_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand komut = new SqlCommand("SELECT[Islem] FROM[bankauyg2022].[dbo].[Islem_Turler]", connection);
                SqlDataReader cevap = komut.ExecuteReader();
                if (cevap.HasRows)
                {
                    comboBoxIslemTur.Items.Clear();
                    while (cevap.Read())
                    {
                        comboBoxIslemTur.Items.Add(cevap.GetString(0));
                    }
                }
                connection.Close();
                cevap.Close();
            }
            catch (Exception hata)

            {
                MessageBox.Show($"HATA: {hata.Message}");
            }
        }

        private void buttonMusteriHesapAc_Click(object sender, EventArgs e)
        {
            if (textBoxMyeniAd.Text=="" || textBoxMyeniSoyad.Text=="" || textBoxMyeniTel.Text=="" || textBoxMyeniAdres.Text=="" || textBoxMyeniEmail.Text=="")
            {
                MessageBox.Show("Hesap Oluşturulamadı Çünkü Bilgilerinizi Boş Bıraktınız");
            }
            else
            {
                MessageBox.Show("Hesap Oluşturuldu");
            }
           
        }
    }
}
