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
namespace shop_management
{
    public partial class books : Form
    {
        public books()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\semer\Documents\bookshop.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select* from BookTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDG.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Filter()
        {
            Con.Open();
            string query = "select* from BookTbl where BCat='"+CatCbSearch.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDG.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (BTitle.Text == "" || BAuthor.Text == "" || QtyTb.Text == "" || Price.Text == "" || BcatCTb.SelectedIndex == -1)
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update BookTbl set BTitle='" + BTitle.Text + "',BAuthor='" + BAuthor.Text + "',BCat='" + BcatCTb.SelectedItem.ToString() + "',BQty=" + QtyTb.Text + ",Bprice=" + Price.Text + "where BId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Updated Successfully");
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
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BTitle.Text == "" ||BAuthor.Text == "" || QtyTb.Text == "" || Price.Text == "" || BcatCTb.SelectedIndex == -1)
            {
                MessageBox.Show("missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into bookTbl values('" + BTitle.Text + "','" + BAuthor.Text + "','" + BcatCTb.SelectedItem.ToString() + "','" + QtyTb.Text + "','" +Price.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Saved Successfully");
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

        private void CatCbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            populate();
            CatCbSearch.SelectedIndex = -1;
        }
        private void Reset()
        {
            BTitle.Text = "";
            BAuthor.Text = "";
            BcatCTb.SelectedIndex = -1;
            Price.Text = "";
            QtyTb.Text = "";
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
                    string query = "delete from BookTbl where BId=" + key + ";";
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

        private void CatCbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
        }
        int key = 0;
        private void BookGRV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitle.Text = BookDG.SelectedRows[0].Cells[1].Value.ToString();
            BAuthor.Text = BookDG.SelectedRows[0].Cells[2].Value.ToString();
            BcatCTb.Text = BookDG.SelectedRows[0].Cells[3].Value.ToString();
            QtyTb.Text = BookDG.SelectedRows[0].Cells[4].Value.ToString();
            Price.Text = BookDG.SelectedRows[0].Cells[5].Value.ToString();

            if(BTitle.Text== "")
            {
                key = 0;
            }else
            {
                key=Convert.ToInt32(BookDG.SelectedRows[0].Cells[0].Value.ToString());
            }
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
