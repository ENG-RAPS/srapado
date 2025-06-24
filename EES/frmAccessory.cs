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
    public partial class frmAccessory : Form
    {
        private String query;
        private int flag;
        public frmAccessory()
        {
            InitializeComponent();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

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
                    query = "INSERT INTO CUSTOMER (CustomerID,CustomerName,PhoneNO,Email,Gender,NationalID,Location,RegDate,EmployeeID) VALUES('" + txtCustomerID.Text + "','" + txtCustomerName.Text + "','" + txtphoneNo.Text + "','" + txtEmail.Text + "','" +  "','" + txtNationalID.Text + "','" + txtReoder.Text + "','" + regDate + "','" + Connection.UserID + "')";
                }
                else
                {
                    msg = "changes Successfully...";
                    query = "UPDATE CUSTOMER SET CustomerID='" + txtCustomerID.Text + "',CustomerName='" + txtCustomerName.Text + "',PhoneNo='" + txtphoneNo.Text + "',Email='" + txtEmail.Text + "',Gender='" +  "',NationalID='" + txtNationalID.Text + "',Location='" + txtReoder.Text + "',RegDate='" + regDate + "',EmployeeID='"+Connection.UserID +"' WHERE CustomerID='"+txtCustomerID.Text+"'";
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
            
        private void clean()
        {
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtEmail.Text = "";      
            txtNationalID.Text = "";
            txtphoneNo.Text = "";
            dtpRegDate.Value = DateTime.Now;
            txtReoder.Text = "";


             txtCustomerID.Focus();
             getItemID();
             getAllItemID();

        }
   
        

        private void btnReset_Click(object sender, EventArgs e)
        {
            
                txtCustomerID.Text = "";
                txtCustomerName.Text = "";
                txtphoneNo.Text = "";
                txtEmail.Text = "";
                txtNationalID.Text = "";
                dtpRegDate.Text = "";
                txtReoder.Text = "";
            

               

                txtCustomerID.Focus();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
              {

                  query = "SELECT * FROM  accessory WHERE ItemID LIKE '%" + txtCustomerID.Text + "%' ";
            if(!(txtCustomerName.Text == "")){
                query = "SELECT * FROM  accessory WHERE CustomerName LIKE '%" + txtCustomerName.Text + "%' ";
            }
            
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCustomerID.Text = reader["ItemID"].ToString();
                    txtCustomerName.Text = reader["ItemName"].ToString();
                    txtphoneNo.Text = reader["Quantity"].ToString();
                    txtEmail.Text = reader["Price"].ToString();
                    txtReoder.Text = reader["Reoder"].ToString();
                    txtNationalID.Text = reader["|  Warant"].ToString();
                  
                  
                  
                }
            } 
        }

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
                    query = "DELETE FROM accessory WHERE ItemID='" + cboCustomerID.Text + "'";
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


        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAccessory_Load(object sender, EventArgs e)
        {


            getItemID();
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;
            pnlMain.Left = (this.Width - pnlMain.Width) / 2;
            cboCustomerID.Visible = false;
            getAllItemID();
            flag = 0;
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void getAllItemID()
        {
            query = "SELECT *FROM  accessory ORDER by ItemID ASC";
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                cboCustomerID.Items.Clear();
                while (reader.Read())
                {
                    cboCustomerID.Items.Add(reader["ItemID"].ToString());
                }
                reader.Close();
                con.CloseConnection();

            }
        }

        private void getItemID()
        {
            query = "SELECT *FROM accessory ORDER By ItemID DESC";
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                string ACCESID;
                if (reader.Read())
                {
                    int cus;

                   ACCESID = reader["ItemID"].ToString();
                    cus = int.Parse(ACCESID.Substring(4));
                    cus += 1;
                    if (cus < 10)
                    {
                        ACCESID = "Item-00" + cus;

                    }
                    else if (cus >= 10 && cus < 100)
                    {
                        ACCESID = "Item-0" + cus;
                    }
                    else
                    {
                        ACCESID = "Item-" + cus;
                    }
                }
                else
                {
                    ACCESID = "Item-001";
                }
                txtCustomerID.Text = ACCESID;
                reader.Close();
                con.CloseConnection();
            }
        }

    }
}
