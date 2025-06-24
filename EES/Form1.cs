using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EES
{
    public partial class frmSplash : Form
    {
        int counter;
        public frmSplash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;
            pnlMain.Left= (this.Width - pnlMain.Width) / 2;
            counter = 0;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter += 5;
            if (counter <= 100)
            {
                
            
                     progressBar1.Value =counter;

                lblprogress.Text = "progress...." + counter + "%";
            }
            if (counter == 100)
            {
                frmLogin login = new frmLogin();
                login.Visible = true;
                this.Hide();
            } 
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
