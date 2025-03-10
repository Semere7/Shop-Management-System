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

namespace shop_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\semer\Documents\bookshop.mdf;Integrated Security=True;Connect Timeout=30");
        public static string UserName = "";
        private void label8_Click(object sender, EventArgs e)
        {
        Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName='" + UNameTb.Text + "' and UPass='" + UPassTb.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                UserName = UNameTb.Text;
                Billing obj = new Billing();
                obj.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("wrong Username or password");
            }
            Con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }

        private void UPassTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
