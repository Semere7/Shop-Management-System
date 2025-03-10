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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\semer\Documents\bookshop.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select* from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDG.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into UserTbl values('" + UNameTb.Text + "','" + PhoneTb.Text + "','" + AddTb.Text+ "','" + PassTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Saved Successfully");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }
        private void Reset()
        {
            UNameTb.Text = "";
            PassTb.Text = "";
            PhoneTb.Text = "";
            AddTb.Text = "";
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from UserTbl where UId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Deleted Successfully");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }
        int key = 0;

        public static object Birthday { get; internal set; }

        private void UserDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UNameTb.Text = UserDG.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = UserDG.SelectedRows[0].Cells[2].Value.ToString();
            AddTb.Text = UserDG.SelectedRows[0].Cells[3].Value.ToString();
            PassTb.Text = UserDG.SelectedRows[0].Cells[4].Value.ToString();

            if (UNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update UserTbl set UName='" + UNameTb.Text + "',UPhone='" + PhoneTb.Text + "',UAdd='" + AddTb.Text + "',UPass=" + PassTb.Text + " where UId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated Successfully");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            books obj = new books();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashbored obj = new Dashbored();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
   
        }

        private void UNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PassTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
