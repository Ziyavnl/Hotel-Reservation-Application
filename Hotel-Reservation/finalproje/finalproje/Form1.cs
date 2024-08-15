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

namespace finalproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string conString = "Data Source=DESKTOP-BAUKP8V;Initial Catalog=hotel_reservation3;Integrated Security=True";
        readonly SqlConnection connect = new SqlConnection(conString);
        private void label1_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();  // form 1 üzerinden login butonu ile form 2 geçme kodu.

            if (textBox1.Text == "Ziya" && textBox2.Text == "12345" || textBox1.Text == "Hüseyin" && textBox2.Text == "123456") //İlk çalışanlarımız.
            {
                this.Hide();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı Veya Şifre Girdiniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
            
            
        }
    }
}
