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
    public partial class Dashbored : Form
    {
        public Dashbored()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            books obj = new books();
            obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\semer\Documents\bookshop.mdf;Integrated Security=True;Connect Timeout=30");
        private void Dashbored_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select sum(BQty) from BookTbl",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BookStackLbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select sum(Amount) from Billd", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            AmountLbl.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("Select Count(*) from UserTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UserTotalbl.Text = dt2.Rows[0][0].ToString();
            Con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
