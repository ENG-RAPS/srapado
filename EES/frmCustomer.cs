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
    public partial class frmCustomer : Form
    {
        private String query;
        private int flag;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcbo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            getCustomerID();
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;
            pnlMain.Left = (this.Width - pnlMain.Width) / 2;
            cboCustomerID.Visible = false;
            getAllCustomerID();
            flag = 0;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            this.Height = this.MdiParent.Height;
            this.Width = this.MdiParent.Width;
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;
            pnlMain.Left = (this.Width - pnlMain.Width) / 2;
            

        }

        private void getAllCustomerID()
        {
            query = "SELECT *FROM customer ORDER by CustomerID ASC";
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                cboCustomerID.Items.Clear();
                while (reader.Read())
                {
                    cboCustomerID.Items.Add(reader["CustomerID"].ToString());
                }
                reader.Close();
                con.CloseConnection();

            }
        }

        private void getCustomerID()
        {
            query = "SELECT *FROM customer ORDER By CustomerID DESC";
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                string CusID;
                if (reader.Read())
                {
                    int cus;

                    CusID = reader["CustomerID"].ToString();
                    cus = int.Parse(CusID.Substring(4));
                    cus += 1;
                    if (cus < 10)
                    {
                        CusID = "CUS-00" + cus;

                    }
                    else if (cus >= 10 && cus < 100)
                    {
                        CusID = "CUS-0" + cus;
                    }
                    else
                    {
                        CusID = "CUS-" + cus;
                    }
                }
                else
                {
                    CusID = "CUS-001";
                }
                txtCustomerID.Text = CusID;
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
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtphoneNo.Text = "";
            txtEmail.Text = "";
            txtNationalID.Text = "";
            txtLocation.Text = "";
            dtpRegDate.Text = "";

            rbnMale.Text = "";
            rbnFemale.Text = "";

            txtCustomerID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerID.Focus();
            }
            else if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerID.Focus();
            }
            else if (txtphoneNo.Text == "")
            {
                MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtphoneNo.Focus();
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
            else if (txtLocation.Text == "")
            {
                MessageBox.Show("Ensure Fll Fields are Filled", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
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
                String dday;
                String mmonth;
                String regDate;

                if (dtpRegDate.Value.Day < 10)
                {
                    dday = "0" + dtpRegDate.Value.Day + "";
                }
                else
                {
                    dday = dtpRegDate.Value.Day + "";
                }
                if (dtpRegDate.Value.Month < 0)
                {
                    mmonth = "0" + dtpRegDate.Value.Month;
                }
                else
                {
                    mmonth = dtpRegDate.Value.Month + "";
                }
                regDate= dtpRegDate.Value.Year + "_"+ mmonth + dday;
                String msg;
                if (flag == 0)
                {
                    msg = "Record Succesfully Saved";
                    query = "INSERT INTO CUSTOMER (CustomerID,CustomerName,PhoneNO,Email,Gender,NationalID,Location,RegDate,EmployeeID) VALUES('" + txtCustomerID.Text + "','" + txtCustomerName.Text + "','" + txtphoneNo.Text + "','" + txtEmail.Text + "','" + gender + "','" + txtNationalID.Text + "','" + txtLocation.Text + "','" + regDate + "','" + Connection.UserID + "')";
                }
                else
                {
                    msg = "changes Successfully...";
                    query = "UPDATE CUSTOMER SET CustomerID='" + txtCustomerID.Text + "',CustomerName='" + txtCustomerName.Text + "',PhoneNo='" + txtphoneNo.Text + "',Email='" + txtEmail.Text + "',Gender='" + gender + "',NationalID='" + txtNationalID.Text + "',Location='" + txtLocation.Text + "',RegDate='" + regDate + "',EmployeeID='"+Connection.UserID +"' WHERE CustomerID='"+txtCustomerID.Text+"'";
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
        private void clean()
        {
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtEmail.Text = "";
            txtLocation.Text = "";
            txtNationalID.Text = "";
            txtphoneNo.Text = "";
            txtLocation.Text = "";

            dtpRegDate.Value = DateTime.Now;


             txtCustomerID.Focus();
            getCustomerID();
            getAllCustomerID();

        }
   

        private void btnEdit_Click(object sender, EventArgs e)
        {
           cboCustomerID.Visible = true;
            flag = 1;
        }
             private void btnDelete_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                MessageBox.Show("Select the record to delete", "EES message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCustomerID.Visible = true;
                cboCustomerID.Focus();
            }
            else
            {
                DialogResult option = MessageBox.Show("Are you sure you want to delete the record", "EES message", MessageBoxButtons.YesNo);
                if (option == DialogResult.Yes)
                {
                    query = "DELETE FROM customer WHERE CustomerID='" + cboCustomerID.Text + "'";
                    Connection con = new Connection();
                    if (con.OpenConnection())
                    {
                        MySqlCommand cmd = new MySqlCommand(query, con.connect);
                        cmd.BeginExecuteReader();
                        
                        MessageBox.Show("Record successfully deleted!", "EES message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        clean();
                        flag = 0;
                        con.CloseConnection();

                    }

                }
            }
        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rbnMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbnFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void cboCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
          query = "SELECT *FROM customer WHERE CustomerID LIKE '" + cboCustomerID.Text + "'";
           Connection con =new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCustomerID.Text = reader["CustomerID"].ToString();
                    txtCustomerName.Text = reader["CustomerName"].ToString();
                    txtphoneNo.Text = reader["PhoneNo"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtNationalID.Text = reader["NationalID"].ToString();
                    txtLocation.Text = reader["Location"].ToString();
                }
            }
           cboCustomerID.Visible = false;
         }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            query = "SELECT * FROM customer WHERE CustomerID LIKE '%" + txtCustomerID.Text + "%' ";
            if(!(txtCustomerName.Text == "")){
                query = "SELECT * FROM customer WHERE CustomerName LIKE '%" + txtCustomerName.Text + "%' ";
            }
            
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCustomerID.Text = reader["CustomerID"].ToString();
                    txtCustomerName.Text = reader["CustomerName"].ToString();
                    txtphoneNo.Text = reader["PhoneNo"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtNationalID.Text = reader["NationalID"].ToString();
                    txtLocation.Text = reader["Location"].ToString();
                    
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

        }
        }
        
    

