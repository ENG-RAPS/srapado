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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
          
            this.Width = this.MdiParent.Width;
            this.Height = this.MdiParent.Height;
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;
            pnlMain.Left = (this.Width - pnlMain.Width) / 2;

        }
    }
}