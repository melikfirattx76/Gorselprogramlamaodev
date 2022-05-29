using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArabaSatınalım
{
    public partial class Form2 : Form
    {
        string mail;
        public Form2(string email)
        {
            InitializeComponent();
            mail = email;
        }
                                          //Programı çalıştıracak bilgisayarın sqlserver ismi ***** yerine yazılmalıdır
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4KJLAHE;Initial Catalog=ArabaAlimsatim;Integrated Security=True");
        SqlDataAdapter adaptor = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == mail)
            {
                SqlCommand komut = new SqlCommand();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "sp_Sil_araba";
                komut.Parameters.Add("@id", SqlDbType.Int);
                komut.Parameters["@id"].Value = textBox2.Text;
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt silindi");
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Sadece arabayı ekleyen kişiler arabayı silebilir", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox13.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand listelekomut = new SqlCommand();
            SqlDataAdapter adaptor = new SqlDataAdapter(listelekomut);
            baglanti.Open();
            listelekomut.Connection = baglanti;
            listelekomut.CommandType = CommandType.StoredProcedure;
            listelekomut.CommandText = "sp_Listele_araba";
            DataTable table = new DataTable();
            adaptor.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "sp_Araba_ekle";
            komut.Parameters.Add("@Adı", SqlDbType.VarChar, 50);
            komut.Parameters.Add("@Markası", SqlDbType.VarChar, 50);
            komut.Parameters.Add("@Modeli", SqlDbType.VarChar, 50);
            komut.Parameters.Add("@Kilometre", SqlDbType.Int);
            komut.Parameters.Add("@Durumu", SqlDbType.VarChar, 50);
            komut.Parameters.Add("@Vites", SqlDbType.VarChar, 50);
            komut.Parameters.Add("@Fiyatı", SqlDbType.Int);
            komut.Parameters.Add("@Kullanici_Email", SqlDbType.VarChar, 50);
            komut.Parameters["@Adı"].Value = textBox3.Text;
            komut.Parameters["@Markası"].Value = textBox4.Text;
            komut.Parameters["@Modeli"].Value = textBox5.Text;
            komut.Parameters["@Kilometre"].Value = textBox6.Text;
            komut.Parameters["@Durumu"].Value = textBox7.Text;
            komut.Parameters["@Vites"].Value = textBox8.Text;
            komut.Parameters["@Fiyatı"].Value = textBox9.Text;
            komut.Parameters["@Kullanici_Email"].Value = mail;
            komut.ExecuteNonQuery();
            MessageBox.Show("Araba kayıtı eklendi");
            baglanti.Close();

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox13.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == mail)
            {
                SqlCommand guncellekomut = new SqlCommand();
                baglanti.Open();
                guncellekomut.Connection = baglanti;
                guncellekomut.CommandType = CommandType.StoredProcedure;
                guncellekomut.CommandText = "sp_Araba_güncelle";
                guncellekomut.Parameters.Add("@id", SqlDbType.Int);
                guncellekomut.Parameters.Add("@Adı", SqlDbType.VarChar, 50);
                guncellekomut.Parameters.Add("@Markası", SqlDbType.VarChar, 50);
                guncellekomut.Parameters.Add("@Modeli", SqlDbType.VarChar, 50);
                guncellekomut.Parameters.Add("@Kilometre", SqlDbType.Int);
                guncellekomut.Parameters.Add("@Durumu", SqlDbType.VarChar, 50);
                guncellekomut.Parameters.Add("@Vites", SqlDbType.VarChar, 50);
                guncellekomut.Parameters.Add("@Fiyatı", SqlDbType.Int);
                guncellekomut.Parameters["@id"].Value = textBox2.Text;
                guncellekomut.Parameters["@Adı"].Value = textBox3.Text;
                guncellekomut.Parameters["@Markası"].Value = textBox4.Text;
                guncellekomut.Parameters["@Modeli"].Value = textBox5.Text;
                guncellekomut.Parameters["@Kilometre"].Value = textBox6.Text;
                guncellekomut.Parameters["@Durumu"].Value = textBox7.Text;
                guncellekomut.Parameters["@Vites"].Value = textBox8.Text;
                guncellekomut.Parameters["@Fiyatı"].Value = textBox9.Text;
                guncellekomut.ExecuteNonQuery();
                MessageBox.Show("Araba kayıtı güncellendi");
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Sadece arabayı ekleyen kişiler araba üzerinde güncelleme yapabilir", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox13.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satirno;
            satirno = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[satirno].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[satirno].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[satirno].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[satirno].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[satirno].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[satirno].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[satirno].Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.Rows[satirno].Cells[7].Value.ToString();
            textBox13.Text = dataGridView1.Rows[satirno].Cells[8].Value.ToString();

            label14.Text = "Araba Adı : " + dataGridView1.Rows[satirno].Cells[1].Value.ToString();
            label15.Text = "Markası : " + dataGridView1.Rows[satirno].Cells[2].Value.ToString();
            label16.Text = "Modeli : " + dataGridView1.Rows[satirno].Cells[3].Value.ToString();
            label18.Text = "Kilometre : " + dataGridView1.Rows[satirno].Cells[4].Value.ToString();
            label19.Text = "Durumu : " + dataGridView1.Rows[satirno].Cells[5].Value.ToString();
            label20.Text = "Vites : " + dataGridView1.Rows[satirno].Cells[6].Value.ToString();
            label21.Text = "Fiyatı : " + dataGridView1.Rows[satirno].Cells[7].Value.ToString();

        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            string vites,adi,markasi;
           
            if ((textBox1.Text == "" && textBox12.Text == "") || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Lütfen vites durumunu seçiniz veya kutulardan birini doldurunuz");
            }
            else
            {
                adi = textBox1.Text;
                markasi = textBox12.Text;
                if (radioButton1.Checked)
                {
                    vites = radioButton1.Text;
                }
                else
                {
                    vites = radioButton2.Text;
                }

                SqlCommand komut = new SqlCommand();
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "sp_Araba_ara";
                komut.Parameters.Add("@Adı", SqlDbType.VarChar, 50);
                komut.Parameters.Add("@Markası", SqlDbType.VarChar, 50);
                komut.Parameters.Add("@Vites", SqlDbType.VarChar, 50);
                komut.Parameters["@Adı"].Value = adi;
                komut.Parameters["@Markası"].Value = markasi;
                komut.Parameters["@Vites"].Value = vites;
                DataTable table = new DataTable();
                adaptor.Fill(table);
                dataGridView1.DataSource = table;
                baglanti.Close();
            }
        }

        //Araştırma konusu : Selenium
        /// <summary>
        /// Bu kodların çalışması için son sürüm (102.0.5005 sürümüne) google chrome ihtiyaç vardır.Daha eski bir google chrome sürümü
        /// kullanıyorsanız çözüm gezginine sağ tıklayıp manage nuget packages for solution kısmından Selenium.WebDriver.ChromeDriver isimli
        /// paketi seçip kullandığınız google chrome sürümünü version kısmından install edip 
        /// kurulu olan 102.0.5005.6100 sürümünü uninstall etmelisiniz.
        /// </summary>
        IWebDriver driver;
        private void button6_Click(object sender, EventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://www.sahibinden.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("searchText")).SendKeys(textBox10.Text);
            driver.FindElement(By.Id("searchText")).SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
