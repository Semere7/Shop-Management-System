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
    public partial class Billing : Form
    {
        public Billing()
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
        private void UpdatedBook()
        {
            int newQty = stock-Convert.ToInt32(QtyTb.Text);
            try
            {
                Con.Open();
                string query = "update BookTbl set BQty=" +QtyTb.Text+ "where BId=" + key + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Book Updated Successfully");
                Con.Close();
                populate();
                //Reset();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        int n = 0, Grdtotal = 0;
        private void label5_Click(object sender, EventArgs e)
        {
            if(QtyTb.Text==""|| Convert.ToInt32(QtyTb.Text)>stock)
            {
                MessageBox.Show("No Enough Stock");
            }
            else
            {
                int total = Convert.ToInt32(QtyTb.Text) * Convert.ToInt32(PriceTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDG);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = BTitle.Text;
                newRow.Cells[2].Value = QtyTb.Text;
                newRow.Cells[3].Value = PriceTb.Text;
                newRow.Cells[4].Value = total;
                BillDG.Rows.Add(newRow);
                n++;
                UpdatedBook();
                Grdtotal = Grdtotal + total;
                TotalBl.Text = "Rs" + Grdtotal;
            }
        }
        int key = 0,stock=0;
        private void BookDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitle.Text = BookDG.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = BookDG.SelectedRows[0].Cells[5].Value.ToString();

            if (BTitle.Text == "")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(BookDG.SelectedRows[0].Cells[0].Value.ToString());
                stock= Convert.ToInt32(BookDG.SelectedRows[0].Cells[4].Value.ToString());
            }
        }
        private void Reset()
        {
            BTitle.Text = "";
            QtyTb.Text = "";
            PriceTb.Text = "";
            ClientNameTb.Text = "";
        }
        int prodid, prodqty, prodprice, tottal, pos = 60;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Billing_Load(object sender, EventArgs e)
        {
            UserNameLbl.Text = Login.UserName;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void UserNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void ClientNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        string prodname;
        private object birthday;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Book Shop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Centuary Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(26, 40));
            foreach(DataGridViewRow row in BillDG.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = "" + row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Grand Total:RS" + Grdtotal, new Font("Centuary Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(60, pos + 50));
            e.Graphics.DrawString("***********BookStor************", new Font("Centuary Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(40, pos + 85));
            BillDG.Rows.Clear();
            BillDG.Refresh();
            pos = 100;
            Grdtotal = 0;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ClientNameTb.Text == "" || BTitle.Text == "") 
            {
                MessageBox.Show("Select Client name");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Billd values('" + UserNameLbl.Text + "','" + ClientNameTb.Text + "','" + Grdtotal + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Saved Successfully");
                    Con.Close();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }

                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm",400, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private void QtyTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
