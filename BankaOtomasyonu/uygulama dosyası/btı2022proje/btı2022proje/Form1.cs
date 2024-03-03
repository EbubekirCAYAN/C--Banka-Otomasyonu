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
using System.Net.Mail;
using System.Net;
using System.Data.Sql;


namespace btı2022proje
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-QTHG79F;Initial Catalog=bankauyg2022;User ID=sa;Password=123456789");
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private static Encoding encode;

        public Form1()
        {
            InitializeComponent();
            panelleriKapat();
            girs.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            musteri frm = new musteri();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panelleriKapat();
            musterino.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelleriKapat();
            kayıtemail.Visible = true;
        }
        void panelleriKapat()
        {
            girs.Visible = false;
            musterino.Visible = false;
            kayıtemail.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelleriKapat();
            girs.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panelleriKapat();
            girs.Visible = true;



        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelleriKapat();
            girs.Visible = true;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            sfreunutsqlbaglant baglanti = new sfreunutsqlbaglant();
            SqlCommand komut = new SqlCommand("Select * from Kullaniciler where Email'" + textBox3.Text.ToString() + "'", baglanti.baglan());

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())

                try
            {

                if (baglanti.baglan().State == ConnectionState.Closed)
                {
                        baglanti.baglan().Open();
    
                    SmtpClient Gonderen = new SmtpClient("smtp.gmail.com");
                    Gonderen.Port = 587;
                    Gonderen.EnableSsl = true;
                    Gonderen.Timeout = 100000;
                    Gonderen.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Gonderen.UseDefaultCredentials = false;
                    Gonderen.Credentials = new NetworkCredential("npyproje@gmail.com", "npyproje2016");
                    MailMessage yeniMail = new MailMessage();
                    yeniMail.To.Add(textBox3.Text);
                    yeniMail.From = new MailAddress("npyproje@gmail.com", "Banka Otamasyonu");
                    yeniMail.Subject = "Banka Otamasyonu Şifre Yenileme";
                    yeniMail.Body = "İyi günler " + ",\n\nŞifre : " +  " \nKullanıcı Adı: " +  "\n\nBankamız adına teşekkürlerimizi bildiriyoruz.";
                    Gonderen.Send(yeniMail);
                    if (MessageBox.Show("Teşekkürler, Başarı ile tamamlanmıştır.", "İşlem Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        textBox3.Clear();
                       
                    }
                    else
                    {
                        textBox3.Clear();
                        MessageBox.Show("Gönderemedik", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Gecerli mail adresi giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Clear();
                    textBox3.Focus();
                }
            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Sistemde böyle bir email adresi bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Clear();
                textBox3.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

                private void button1_Click(object sender, EventArgs e)
                {
                    string sql = "Select* from parola where Kullanıcı_Ad=@username Sifre= @sifre";
                    string user = textBox1.Text;
                    string pass = textBox2.Text;
                    con = new SqlConnection("server=.; Initial Catalog=bankauyg2022;Integrated Security=SSPI");
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Kullaniciler where Kullanıcı_Adı='" + textBox1.Text + "' AND Sifre='" + textBox2.Text + "'";
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız. ");
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                        return;
                    }
                    con.Close();

                    kullanici kullanici = new kullanici();
                    kullanici.Show();
                }

                private void button2_Click(object sender, EventArgs e)
                {
                    musteripanel musteri = new musteripanel();
                    musteri.Show();
                }

                private void button2_Click_1(object sender, EventArgs e)
                {
                    if (textBox4.Text == "")
                    {
                        MessageBox.Show("Müşteri No Alanı Boş Geçilemez");
                        return;
                    }
                    musteripanel musteripanel = new musteripanel(textBox4.Text);
                    musteripanel.Show();
                }

                private void textBox2_TextChanged(object sender, EventArgs e)
                {
                    textBox2.PasswordChar = '*';
                }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }

        }

    


 