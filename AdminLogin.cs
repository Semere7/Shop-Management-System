using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_management
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (UPassTb.Text == "Password")
            {
                books obj = new books();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password.Contact The Admin");
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void UPassTb_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
