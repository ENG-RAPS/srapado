using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace EES
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;
            pnlMain.Left = (this.Width - pnlMain.Width) / 2;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if
                (txtUsername.Text == "")
            {

                MessageBox.Show("Ensure all fields are filled!",
                 "EES Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else if

                (txtPassword.Text == "")
            {

                MessageBox.Show("Ensure all fields are filled!",
                 "EES Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else
            {
                String query = "SELECT* FROM employees WHERE Username='" + txtUsername.Text + "' AND password='" + txtPassword.Text + " ' ";
                Connection con = new Connection();
                if (con.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, con.connect);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Connection.UserID = reader["EmployeeId"].ToString();
                        Connection.EmployeeName = reader["EmployeeName"].ToString();
                        MDIParent1 mdi =new  MDIParent1();
                        mdi.Visible = true;
                        this.Hide();

                    }

                    else
                    {
                        MessageBox.Show("Invalid Username/Password!",
                        "EES Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtUsername.Focus();

                    }
                    reader.Close();
                    con.CloseConnection();
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
