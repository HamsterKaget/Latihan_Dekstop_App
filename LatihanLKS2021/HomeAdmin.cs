using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatihanLKS2021
{
    public partial class HomeAdmin : Form
    {
        public static HomeAdmin instance;

        public HomeAdmin()
        {
            InitializeComponent();
            instance = this;
            label2.Text = "Welcome," + Form1.loginData[1];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormManageMenu menu = new FormManageMenu();
            menu.Show();
            this.Close();
        }
    }
}
