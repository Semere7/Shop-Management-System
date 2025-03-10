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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int startPos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPos += 1;
            MyProgress.Value = startPos;
            percentage.Text = startPos + "%";
            if(MyProgress.Value==100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
