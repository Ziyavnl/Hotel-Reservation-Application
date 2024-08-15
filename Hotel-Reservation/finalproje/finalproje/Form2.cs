using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalproje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static string conString = "Data Source=DESKTOP-BAUKP8V;Initial Catalog=hotel_reservation3;Integrated Security=True";
        readonly SqlConnection connect = new SqlConnection(conString);
        void SecimleriTemizleme()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            txtBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            


            textBox1.Focus();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kayit;

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                kayit = "SET IDENTITY_INSERT otomat3 ON insert into otomat3 (id,Ad_Soyad,TC_Kimlik_No,Cinsiyet,Rezervasyon_Tarihi,Kisi_Sayisi,Yatak_Sayisi_Turu) values(@id,@Ad_Soyad,@TC_Kimlik_No,@Cinsiyet,@Rezervasyon_Tarihi,@Kisi_Sayisi,@Yatak_Sayisi_Turu) SET IDENTITY_INSERT otomat3 OFF";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@Ad_Soyad", textBox1.Text);
                komut.Parameters.AddWithValue("@TC_Kimlik_No", textBox2.Text);
                komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);               
                komut.Parameters.AddWithValue("@Rezervasyon_Tarihi", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@Kisi_Sayisi", comboBox2.Text);
                komut.Parameters.AddWithValue("@Yatak_Sayisi_Turu", comboBox3.Text);
                komut.Parameters.AddWithValue("@id", txtBox1.Text);

                komut.ExecuteNonQuery();

                connect.Close();

            }                        // Eğer kayıt aşamasında bir hata olursa bu hata ile karşılaşılıcak
            catch (Exception hata)     
            {
                MessageBox.Show("Hata Meydana Geldi" + hata.Message);
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM otomat3", connect))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter verim = new SqlDataAdapter(cmd))
                    {
                        using (DataTable tablom = new DataTable())
                        {
                            verim.Fill(tablom);
                            dataGridView1.DataSource = tablom;
                        }
                    }
                }

                connect.Close();
            }
            catch (Exception hata)        // Eğer kayıt aşamasında bir hata olursa bu hata ile karşılaşılıcak
            {                                 
                MessageBox.Show("Hata Meydana Geldi" + hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try                                      // Buradaki kod tablodaki görüntüleme yani Sql de olan -
                                                     // veriyi from tablosuna aktarıyor.
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * From otomat3", connect))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter verim = new SqlDataAdapter(cmd))
                    {
                        using (DataTable tablom = new DataTable())
                        {
                            verim.Fill(tablom);
                            dataGridView1.DataSource = tablom;
                        }
                    }
                }


                connect.Close();
            }
            catch (Exception hata)           //Eğer aktarılırken herhangi bir sorun çıkarsa bu uyarı geliyor.
            {
                MessageBox.Show("Veri Ekranı Size Aktarılırken Bir Sorunla Karşılaşıldı." + hata.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try                           // Bu bölümdeki kod daha önceden girilmiş veriyi Sql den siler.

            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                SqlCommand cmd = new SqlCommand("Delete From otomat3 where id = '" + dataGridView1.SelectedCells[0].Value + "'", connect);
                SqlDataReader silme = cmd.ExecuteReader();
                silme.Read();

                MessageBox.Show("İstediğiniz Rezervasyon Başarıyla Silinmiştir");   //başarılı silme sonucu gelen bildirim.

                while (silme.Read())
                {

                }
                connect.Close();

                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                using (cmd = new SqlCommand("SELECT * From otomat3", connect))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter verim = new SqlDataAdapter(cmd))
                    {
                        using (DataTable tablom = new DataTable())
                        {
                            verim.Fill(tablom);
                            dataGridView1.DataSource = tablom;
                        }
                    }
                }

                connect.Close();
            }
            catch (Exception hata)          //hatalı silme sonucu gelen bildirim.
            {
                MessageBox.Show("İstediğiniz Rezervasyon Silinirken Bir Hara Oluştu" + hata.Message);

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)      
        {
           /* if (char.IsLetter(e.KeyChar) || e.KeyChar == 8)        boşluk bırakmayı engellediği için kullanmadım.
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
           */
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)          
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)         //TC yazma kısmına rakam harici bir yazı yazılmasını engelliyor.
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SecimleriTemizleme();
        }
    }
}
