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
using MySql.Data.Types;

namespace EES
{
    public partial class frmEmployee : Form
    {
        private String query;
        private int flag;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            {
                if (cboEmployeeID.Text == "")
                {
                    MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboEmployeeID.Focus();
                }
                else if (txtEmployeeName.Text == "")
                {
                    MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeName.Focus();
                }
                else if (txtphone.Text == "")
                {
                    MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtphone.Focus();
                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
                else if (txtNationalID.Text == "")
                {
                    MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNationalID.Focus();
                }
                else if (txtPriviledges.Text == "")
                {
                    MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPriviledges.Focus();
                }
                else if (txtDesignation.Text == "")
                {
                    MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesignation.Focus();
                }

                else
                {
                    string gender;
                    if (rbnMale.Checked)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Female";
                    }

                    String msg;
                    if (flag == 0)
                    {
                        msg = "Record Succesfully Saved";
                        query = "INSERT INTO CUSTOMER (CustomerID,CustomerName,PhoneNO,Email,Gender,NationalID,Location,RegDate,EmployeeID) VALUES('" + cboEmployeeID.Text + "','" + txtEmployeeName.Text + "','" + txtphone.Text + "','" + txtEmail.Text + "','" + gender + "','" + txtNationalID.Text + "','" + txtPriviledges.Text + "','" + txtDesignation + "','" + Connection.UserID + "')";
                    }
                    else
                    {
                        msg = "changes Successfully...";
                        query = "UPDATE CUSTOMER SET CustomerID='" + cboEmployeeID.Text + "',CustomerName='" + txtEmployeeName.Text + "',PhoneNo='" + txtphone.Text + "',Email='" + txtEmail.Text + "',Gender='" + gender + "',NationalID='" + txtNationalID.Text + "',Location='" + txtPriviledges.Text + "',RegDate='" + txtDesignation + "',EmployeeID='" + Connection.UserID + "' WHERE CustomerID='" + cboEmployeeID.Text + "'";
                    }
                    Connection con = new Connection();
                    if (con.OpenConnection())
                    {
                        MySqlCommand cmd = new MySqlCommand(query, con.connect);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show(msg, "EES Message ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clean();
                        flag = 0;
                        con.CloseConnection();
                    }

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            cboEmployeeID.Visible = true;
            
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            getEmployeeID();
            cboEmployeeID.Visible = false;
            getAllEmployeeID();
            flag = 0;

            this.Width = this.MdiParent.Width;
            this.Height = this.MdiParent.Height;
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;
            pnlMain.Left = (this.Width - pnlMain.Width) / 2;

        }

        private void getEmployeeID()
        {
            query = "SELECT *FROM Employees ORDER By EmployeeID DESC";
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                string EmpID;
                if (reader.Read())
                {
                    int cus;

                    EmpID = reader["EmployeeID"].ToString();
                    cus = int.Parse(EmpID.Substring(4));
                    cus += 1;
                    if (cus < 10)
                    {
                        EmpID = "EMP-00" + cus;

                    }
                    else if (cus >= 10 && cus < 100)
                    {
                        EmpID = "EMP-0" + cus;
                    }
                    else
                    {
                        EmpID = "EMP-" + cus;
                    }
                }
                else
                {
                    EmpID = "EMP-001";
                }
                cboEmployeeID.Text =EmpID;
                reader.Close();
                con.CloseConnection();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtphone.Text = "";
            txtEmail.Text = "";
            txtNationalID.Text = "";
            rbnMale.Text = "";
            rbnFemale.Text = "";
            txtPriviledges.Text = "";
            txtDesignation.Text = "";
            txtStatus.Text = "";
            rbnMale.Text = "";
            rbnFemale.Text = "";



            cboEmployeeID.Focus();
        }


        private void getAllEmployeeID()
        {
            
                query = "SELECT *FROM Employees ORDER by EmployeeID ASC";
                Connection con = new Connection();
                if (con.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, con.connect);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    cboEmployeeID.Items.Clear();
                    while (reader.Read())
                    {
                        cboEmployeeID.Items.Add(reader["EmployeeID"].ToString());
                    }
                    reader.Close();
                    con.CloseConnection();

                }
            }
        

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtcbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEmployeeID.Visible = true;
            
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            query = "SELECT * FROM Employees WHERE EmployeeID LIKE '%" + cboEmployeeID.Text + "%' ";
            if (!(txtEmployeeName.Text == ""))
            {
                query = "SELECT * FROM Employees WHERE EmployeeName LIKE '%" + txtEmployeeName.Text + "%' ";
            }

            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cboEmployeeID.Text = reader["EmployeeID"].ToString();
                    txtEmployeeName.Text = reader["EmployeeName"].ToString();
                    txtphone.Text = reader["PhoneNo"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtPassword.Text = reader["Password"].ToString();
                    txtNationalID.Text = reader["NationalID"].ToString();
                    txtPriviledges.Text = reader["Priviledges"].ToString();

                    if (reader["Gender"].ToString() == "male")
                    {
                        rbnMale.Checked = true;
                    }
                    else
                    {
                        rbnFemale.Checked = true;
                    }
                    //flag = 1;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboEmployeeID.Visible = true;
            flag = 1;
        }
        private void clean()
        {
            cboEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtEmail.Text = "";
            txtPriviledges.Text = "";
            txtNationalID.Text = "";
            txtphone.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtDesignation.Text = "";
            txtStatus.Text = "";
      


            cboEmployeeID.Focus();
            getEmployeeID();
            getAllEmployeeID();

        }
   

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                if (flag == 0)
                {
                    MessageBox.Show("Select the record to delete", "EES message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboEmployeeID.Visible = true;
                    cboEmployeeID.Focus();
                }
                else
                {
                    DialogResult option = MessageBox.Show("Are you sure you want to delete the record", "EES message", MessageBoxButtons.YesNo);
                    if (option == DialogResult.Yes)
                    {
                        query = "DELETE FROM customer WHERE CustomerID='" + cboEmployeeID.Text + "'";
                        Connection con = new Connection();
                        if (con.OpenConnection())
                        {
                            MySqlCommand cmd = new MySqlCommand(query, con.connect);
                            cmd.BeginExecuteReader();

                            MessageBox.Show("Record successfully deleted!", "EES message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                            flag = 0;
                            con.CloseConnection();

                        }

                    }
                }
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}