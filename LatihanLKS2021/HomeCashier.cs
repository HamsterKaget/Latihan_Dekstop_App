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
    public partial class HomeCashier : Form
    {
        public HomeCashier()
        {
            InitializeComponent();
            label2.Text = "Welcome, " + Form1.loginData[1];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void HomeCashier_Load(object sender, EventArgs e)
        {

        }
    }
}
