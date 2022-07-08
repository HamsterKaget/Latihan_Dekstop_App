using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;



namespace LatihanLKS2021
{
    public partial class FormManageMenu : Form
    {
        public static string cmdsql;
        SqlConnection db = new SqlConnection(Form1.connectionString);
        public FormManageMenu()
        {
            InitializeComponent();
            load_data();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Create 
        private void button3_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) )
            {
                MessageBox.Show("Semua Field Harus Diisi Terlebih Dahulu !");
            } else
            {
                cmdsql = "INSERT INTO MsMenu(Name, Price, Photo, Carbo, Protein) VALUES ('" + textBox3.Text + "','" + Int32.Parse(textBox4.Text) + "','" + textBox5.Text + "','" + Int32.Parse(textBox6.Text) + "','" + Int32.Parse(textBox7.Text) + "')";
                db.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmdsql, db);
                sda.SelectCommand.ExecuteNonQuery();
                db.Close();
                MessageBox.Show("data entered succesfully. . . .");
                clear_data();
            }

            load_data();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg, *.png)| *jpg; *.jpeg; *.png";
            
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                string imagePath = open.FileName;
                textBox5.Text = Path.GetFileName(imagePath);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void load_data()
        {
            db.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM MsMenu", db);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            db.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[3].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
                textBox7.Text = row.Cells[5].Value.ToString();
                pictureBox1.ImageLocation = "C:/Users/RPL-SMKN4/Downloads/" + row.Cells[3].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel1.Enabled = true)
            {
                if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
                {
                    MessageBox.Show("Semua Field Harus Diisi Terlebih Dahulu !");
                }
                else
                {
                    db.Open();
                    cmdsql = "UPDATE MsMenu SET Name='" + textBox3.Text + "', Price='" + Int32.Parse(textBox4.Text) + "', Photo='" + textBox5.Text + "', Carbo='" + Int32.Parse(textBox6.Text) + "', Protein='" + Int32.Parse(textBox7.Text) + "' WHERE Id = '" + Int32.Parse(textBox2.Text) + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(cmdsql, db);
                    sda.SelectCommand.ExecuteNonQuery();
                    db.Close();
                    MessageBox.Show("data update succesfully. . . .");
                    clear_data();
                    load_data();
                }
            } 
            else
            {
                MessageBox.Show("please select what you want to update");
            }
            
        }

        private void clear_data()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Semua Field Harus Diisi Terlebih Dahulu !");
            }
            else
            {
                cmdsql = "DELETE FROM MsMenu WHERE Id='" + textBox2.Text + "'";
                db.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmdsql, db);
                sda.SelectCommand.ExecuteNonQuery();
                db.Close();
                MessageBox.Show("Data was deleted succesfully");
                clear_data();
                load_data();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Textbox harus diisi terlebih dahulu");
            } 
            else
            {
                cmdsql = "SELECT * FROM MsMenu WHERE Name LIKE '%" + textBox1.Text + "%'";
                db.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmdsql, db);
                DataTable dt = new DataTable();
                sda.SelectCommand.ExecuteNonQuery();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                db.Close();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
