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
using System.Data.SqlClient;

namespace LatihanLKS2021
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public static string[] loginData;
        public static string connectionString = @"Data Source=DESKTOP-MAADRDC;Initial Catalog=db_lksa;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
            string sql = "SELECT * FROM MsEmployee Where Email='" + email + "' AND Password='" + password + "'";
            loginData = logindata(sql);


            try
            {
                if (loginData[5].ToString() == "1")
                {
                    this.Hide();
                    HomeAdmin homeAdmin = new HomeAdmin();
                    homeAdmin.Show();

                }
                else if (loginData[5].ToString() == "2")
                {
                    this.Hide();
                    HomeCashier homeCashier = new HomeCashier();
                    homeCashier.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Email Atau Password Salah !");
            }


        }

        private string[] logindata(string sql)
        {
            SqlConnection db = new SqlConnection(connectionString);
            SqlDataAdapter sda = new SqlDataAdapter(sql, db);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();

            return stringArr;
        }
    }
}