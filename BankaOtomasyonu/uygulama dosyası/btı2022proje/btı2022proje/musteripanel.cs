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
using System.Xml;



namespace btı2022proje
{
    public partial class musteripanel : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-QTHG79F;Initial Catalog=bankauyg2022;User ID=sa;Password=123456789");
        private string sorgu;
        public string _musNo;

        public object Musteri_No { get; private set; }

        public musteripanel()
        {
            InitializeComponent();
            panelkapat();
        }
        public musteripanel(string musNo)
        {
            _musNo = musNo;
            InitializeComponent();
            panelkapat();
        }
        private void panelkapat()
        {
            ParaIslemleri.Visible = false;
            HesapOzet.Visible = false;
            KurHesp.Visible = false;
            MusteriGiriş.Visible = false;
        }

        private void işlemŞeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem1.Text == "")
            {
                MessageBox.Show("Lütfen Bir Arama Yapınız.");
                return;
            }
            MusteriGiriş.Visible = true;
            ParaIslemleri.Visible = false;
            HesapOzet.Visible = false;
            KurHesp.Visible = false;
        }    
      
        private void buttonParaYatir_Click(object sender, EventArgs e)
        {
            panelkapat();
            ParaIslemleri.Visible = true;
            textBox2.Text = "2";
            tabPage2.Visible = true;
            this.tabControl1.SelectedTab = tabPage2;

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT[Hesap_Id] FROM[bankauyg2022].[dbo].[Hesaplar] WHERE Musteri_No = @deger";
            komut.Connection = connect;
            komut.Parameters.AddWithValue("@deger", textBoxParaYatirma.Text);
            komut.CommandType = CommandType.Text;

            if (textBoxParaYatirma.Text == "")
            {
                MessageBox.Show("Girişler boş geçilemez!", "işlem Sonuç");

                return;
            }
            
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                // SqlCommand komut = new SqlCommand("insert into Hesap_Islemleri (Hesap_No,Islem_Tur_Id,Miktar,Alıcı_Hesap) values( @hesapno, @Islemtur, @miktar, @alıcıhesap)", connect);

                komut.Parameters.AddWithValue("@hesapno", textBoxParaYatirma.Text);
                komut.Parameters.AddWithValue("@Islemtur", textBoxParaYatirma.Text);
                komut.Parameters.AddWithValue("@miktar", textBoxParaYatirma.Text);
                komut.Parameters.AddWithValue("@alıcıhesap", textBoxParaYatirma.Text);
                komut.ExecuteNonQuery();
                connect.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show($"HATA: {hata.Message}");
                return;
            }
            MessageBox.Show("İşlem Başarılı");

        }
        
        private void btnParaCek_Click(object sender, EventArgs e)
        {
            panelkapat();
            ParaIslemleri.Visible = true;
            textBox2.Text = "1";
            tabPage3.Visible = true;
            this.tabControl1.SelectedTab = tabPage3;
        }
        
        private void btnHavale_Click(object sender, EventArgs e)
        {
            panelkapat();
            ParaIslemleri.Visible = true;
            textBox2.Text = "3";
            tabPage1.Visible = true;
            this.tabControl1.SelectedTab = tabPage1;
        }

        private void btnHesapOzeti_Click(object sender, EventArgs e)
        {
            panelkapat();
            HesapOzet.Visible = true;
        }

        private void btnHesaplar_Click(object sender, EventArgs e)
        {
            panelkapat();
            KurHesp.Visible = true;
        }
        
        private void musteripanel_Load(object sender, EventArgs e)

        {
            VeriGetir();


            ///KUR HESAPLAMA PANELİ İÇİN;///
            string bugun = "https://tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolarAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
           DolarAlisText.Text = dolarAlis;

            string dolarSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            DolarSatisText.Text = dolarSatis;

            string euroAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            EuroAlisText.Text = euroAlis;

            string euroSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            EuroSatisText.Text = euroSatis;
            ////////////////BURAYA KADAR KUR HESAPLAMA///////////
            

            /////HESAP BLGİLERİ MUSTERİ NUMARASI KULLANILABİLİR BAKİYE BAKİYE ////////

            // TODO: Bu kod satırı 'bankauyg2022DataSet.Hesap_Islemleri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.hesap_IslemleriTableAdapter.Fill(this.bankauyg2022DataSet.Hesap_Islemleri);

                SqlConnection baglanti = new SqlConnection();
                baglanti.ConnectionString = "Data Source=.;Initial Catalog=bankauyg2022;Integrated Security=SSPI";


            TextBoxMusteriNO.Text = _musNo;

        }

        private void VeriGetir()
        {

        }

        private void buttonIslemHavale_Click(object sender, EventArgs e)
        {
            panelkapat();
            ParaIslemleri.Visible = true;
            textBox2.Text = "3";
            tabPage2.Visible = true;
            this.tabControl1.SelectedTab = tabPage1;

            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QTHG79F;Initial Catalog=bankauyg2022;User ID=sa;Password=123456789");

            baglanti.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Hesap_Islemler (Miktar) VALUES (@miktar)", baglanti);

            cmd.Parameters.AddWithValue("Miktar", textBoxHavaleYatirilacakHesap.Text);

            if (textBoxHavaleYatirilacakHesap.Text == "")
            {
                MessageBox.Show("Girişler boş geçilemez!", "işlem Sonuç");

                return;
            }

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                //SqlCommand komut = new SqlCommand("insert into Hesap_Islemleri (Hesap_No,Islem_Tur_Id,Miktar,Alıcı_Hesap) values( @hesapno, @Islemtur, @miktar, @alıcıhesap)", connect);

               
                connect.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show($"HATA: {hata.Message}");
                return;
            }
            MessageBox.Show("İşlem Başarılı");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            //MessageBox.Show(string.Format("{0:C0}", decimal.Parse(textBoxParaYatirma.Text)) + " - " + comboBox1.SelectedItem.ToString() + " No'lu hesaba yatırıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //textBoxParaYatirma.Clear();
            //textBoxParaYatirma.Focus();


            string bakiye="" , kullanılabilirbakiye =""; 
            SqlConnection cnn = new SqlConnection("Data Source=.;Initial Catalog=bankauyg2022;Integrated Security=SSPI");
            cnn.Open();
           
            textBoxParaYatirma.Clear();
            textBoxParaYatirma.Focus();
            SqlCommand cmd = new SqlCommand("Select * from [Hesaplar] where Musteri_No=@deger and Hesap_ID=@deger1 ", cnn);
            cmd.Parameters.AddWithValue("@deger", TextBoxMusteriNO.Text); 
            cmd.Parameters.AddWithValue("@deger1", comboBox1.SelectedItem); 
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               
                bakiye = dr["Bakiye"].ToString();
                kullanılabilirbakiye = dr["Kullanılabilir_bakiye"].ToString();

            }
            label9.Text = bakiye;
            label21.Text = kullanılabilirbakiye;
            Convert.ToInt32(label21.Text);
            dr.Close();
            cmd.Dispose();
            cnn.Close();

            //label19.Text = "bakiye";
            //baglanti.Close();
        }

        private void TextBoxMusteriNO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT[Hesap_Id] FROM[bankauyg2022].[dbo].[Hesaplar] WHERE Musteri_No = @deger";
                komut.Connection = connect;
                komut.Parameters.AddWithValue("@deger", TextBoxMusteriNO.Text);
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Hesap_Id"]);
                }
                komut.Dispose();
                dr.Close();
                connect.Close();
            }
            catch (Exception hata)

            {
                MessageBox.Show($"HATA: {hata.Message}");
            }
        }
      
        private void buttonParaCek_Click(object sender, EventArgs e)
        {
           
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT[Hesap_Id] FROM[bankauyg2022].[dbo].[Hesaplar] WHERE Musteri_No = @deger";
            komut.Connection = connect;
            komut.Parameters.AddWithValue("@deger", textBoxParaCekme.Text);
            komut.CommandType = CommandType.Text;

            if (textBoxParaCekme.Text == "" )
            {
            MessageBox.Show("Gecerli miktar değeri giriniz...!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
               // SqlCommand komut = new SqlCommand("insert into Hesap_Islemleri (Hesap_No,Islem_Tur_Id,Miktar,Alıcı_Hesap) values( @hesapno, @Islemtur, @miktar, @alıcıhesap)", connect);
              
                komut.Parameters.AddWithValue("@hesapno", textBoxParaCekme.Text);
                komut.Parameters.AddWithValue("@Islemtur", textBoxParaCekme.Text);
                komut.Parameters.AddWithValue("@miktar", textBoxParaCekme.Text);
                komut.Parameters.AddWithValue("@alıcıhesap", textBoxParaCekme.Text);
                komut.ExecuteNonQuery();
                connect.Close();
                
            }
            catch (Exception hata)
            {
                MessageBox.Show($"HATA: {hata.Message}");
                return;
            }
            MessageBox.Show("İşlem Başarılı");

        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            panelkapat();
            ParaIslemleri.Visible = true;
            textBox2.Text = "2";
            tabPage2.Visible = true;
            this.tabControl1.SelectedTab = tabPage2;
        }

        private void TextBoxMusteriNO_Click(object sender, EventArgs e)
        {
            //connect.Open();
            //SqlCommand komut = new SqlCommand("select *from Hesaplar where Musteri_No");
        }


        void bakiye()
        {
            sorgu = @"select 
            (select SUM(tutar) from satislar where bakiye=@bakiye) - 
            (select SUM(tutar) from tahsilat where kullanılabilirbakiye=@kullanılabilirbakiye)";

            connect.Open();

            SqlCommand cmd = new SqlCommand(sorgu, (SqlConnection)connect);
            

            decimal tutar = Convert.ToDecimal(cmd.ExecuteScalar());
            label19.Text = tutar.ToString();

            connect.Close();
        }
        

        private void comboBoxOzetHesaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bakiye = "", kullanılabilirbakiye = "";
            SqlConnection cnn = new SqlConnection("Data Source=.;Initial Catalog=bankauyg2022;Integrated Security=SSPI");
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Select * from [Hesaplar] where Musteri_No=@deger and Hesap_ID=@deger1 ", cnn);
            cmd.Parameters.AddWithValue("@deger", TextBoxMusteriNO.Text);
            cmd.Parameters.AddWithValue("@deger1", comboBoxOzetHesaplar.SelectedItem);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                bakiye = dr["Bakiye"].ToString();
                kullanılabilirbakiye = dr["Kullanılabilir_bakiye"].ToString();

            }
            label16.Text = bakiye;
            label15.Text = kullanılabilirbakiye;

            dr.Close();
            cmd.Dispose();
            cnn.Close();
        }

        /////HESAP BLGİLERİ MUSTERİ NUMARASI KULLANILABİLİR BAKİYE BAKİYE ////////



        ///KUR HESAPLAMA PANELİ İÇİN;///
        private void btnDlrAl_Click(object sender, EventArgs e)
        {
            textKur.Text = DolarAlisText.Text;
        }

        private void btnEurAl_Click(object sender, EventArgs e)
        {
            textKur.Text = EuroAlisText.Text;
        }

        private void btnDlrSa_Click(object sender, EventArgs e)
        {
            textKur.Text = DolarSatisText.Text;
        }

        private void btnEurSa_Click(object sender, EventArgs e)
        {
            textKur.Text = EuroSatisText.Text;
        }

        private void Kur_Bozdur_Click(object sender, EventArgs e)
        {
            kur = Convert.ToDouble(textKur.Text);
            int miktar = Convert.ToInt32(textMiktar.Text);
            int tutar = Convert.ToInt32( miktar / kur );
            textTutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            textKalan.Text = kalan.ToString();

        }

        private void textKur_Changed(object sender, EventArgs e)
        {
            textKur.Text = textKur.Text.Replace(".", ".");  
        } 
        
        
            double kur, miktar, tutar;

        private void aNAMENUToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void textBoxParaCekme_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBoxParaYatirma_TextChanged(object sender, EventArgs e)
        {

        }
            //Para İşlemlerinde Sadece Numara Giriş
        private void textBoxParaYatirma_KeyPressa(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxParaYatirma_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxHavaleYatirilacakHesap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxHavaleTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
       
        //Para İşlemlerinde Sadece Numara Giriş\\
        
        //private object db;

        private void Kur_Hesapla_Click(object sender, EventArgs e)
        {
            kur = Convert.ToDouble(textKur.Text);
            miktar = Convert.ToDouble(textMiktar.Text);
            tutar = miktar = kur;
            textTutar.Text = tutar.ToString();
            textTutar.Text = tutar.ToString();

        }

        ////////////////BURAYA KADAR KUR HESAPLAMA///////////
    }
}
