using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ArabaSatınalım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                          //Programı çalıştıracak bilgisayarın sqlserver ismi ***** yerine yazılmalıdır
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4KJLAHE;Initial Catalog=ArabaAlimsatim;Integrated Security=True");
        SqlDataAdapter adaptor = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
        string kullaniciAdi = textBox1.Text;
        string email = textBox2.Text;
        string sifre = textBox4.Text;
        if (kullaniciAdi == "" || email == "" || sifre == "")
        {
                MessageBox.Show("Tüm kutuları doldurunuz");
        }
        else
        {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO kullanicilar VALUES ('" + kullaniciAdi + "','" + email + "','" + sifre + "')");
                komut.Connection = baglanti;
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Gerçekleşti. Giriş yapabilirsiniz");
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox5.Text;
            string sifre = textBox6.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM kullanicilar WHERE Email='" + email + "' AND Sifre='" + sifre + "'", baglanti);
            komut.Connection = baglanti;
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read() != false)
            {
                this.Hide();
                Form2 form2 = new Form2(email);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Email ya da şifre yanlış.Bilgilerinizi kontrol ediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }
    }
}
