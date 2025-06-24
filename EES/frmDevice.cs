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
    public partial class frmDevice : Form
    {
        private int flag; 
        private String query;

        public frmDevice()
       
        {
            
            InitializeComponent();
        }

        private void frmDevice_Load(object sender, EventArgs e)
        {
            getDeviceID();
            getCustomerID();
            getAllCustomerID();
            cboCustomerID.Visible = false;
            

           
            this.Width = this.MdiParent.Width;
            this.Height = this.MdiParent.Height;
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;
            pnlMain.Left = (this.Width - pnlMain.Width) / 2;
               
        }

        private void cboCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDeviceDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpRegDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void getAllCustomerID()
        {
            query = "SELECT *FROM Device ORDER by DeviceID DESC";
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                cboCustomerID.Items.Clear();
                while (reader.Read())
                {

                    cboCustomerID.Items.Add(reader["DeviceID"].ToString());
                }
                reader.Close();
                con.CloseConnection();

            }
        }

        private void getDeviceID()
        {
            Connection con = new Connection();
            if (con.OpenConnection())
            {
                query = "SELECT *FROM  DEVICE ORDER by CustomerID DESC";
                MySqlCommand cmd = new MySqlCommand(query, con.connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                string DEVID;
                if (reader.Read())
                {
                    int dev;
                    DEVID = reader["DeviceID"].ToString();
                    dev = int.Parse(DEVID.Substring(4));
                       dev += 1;
                    if (dev < 10)
                    {
                        DEVID = "CUS-00" + dev;

                    }
                    else if (dev >= 10 && dev < 100)
                    {
                        DEVID = "CUS-0" + dev;
                    }
                    else
                    {
                        DEVID= "DEV-" + dev;
                    }
                }
                else
                {
                    DEVID = "DEV-001";
                }
                txtDeviceID.Text = DEVID;
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtDeviceID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!",
            "EES Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDeviceID.Focus();
            }
            else if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Ensure All Fields", "EES Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerID.Focus();

            }
            else if (txtDeviceDescription.Text == "")
            {
                MessageBox.Show("Ensure All Fields Are Filled ", "EES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDeviceDescription.Focus();
            }
            else if (txtEmployeecbo.Text == "")
            {
                MessageBox.Show("Ensure All Fields Are Filled ", "EES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeecbo.Focus();
            }
            else if (txtSerialNo.Text == "")
            {
                MessageBox.Show("Ensure All Fields Are Filled ", "EES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerialNo.Focus();
            }

            else
            {
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
                    mmonth = "0" + dtpRegDate.Value.Month + "";
                }
                else
                {
                    mmonth = dtpRegDate.Value.Month + "";
                }

                regDate = dtpRegDate.Value.Year + "_" + mmonth + dday;
            }
            String msg;

            if (flag == 0)
            {
                msg = "Record Succesfully Saved";
                query = "INSERT INTO DEVICE(DeviceID,DeviceDescription,SerialNo,CustomerID,RegDate,EmployeeID) VALUES('" + txtCustomerID.Text + "', '" + txtDeviceID.Text + "', '" + txtDeviceDescription.Text + "', '" + txtSerialNo.Text + "', '" + txtEmployeecbo + "','" + dtpRegDate + "')";
            }
            else
            {
                msg = "changes Successfully...";
                query = "UPDATE DEVICE SET DeviceID'" + txtCustomerID.Text + "', '" + txtDeviceID.Text + "', '" + txtDeviceDescription.Text + "', '" + txtSerialNo.Text + "', '" + txtEmployeecbo + "','" + dtpRegDate + "')";
            }
               Connection con = new Connection();
                    if (con.OpenConnection()== true)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, con.connect);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show(msg, "EES Message ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clean();
                        flag = 0;
                        con.CloseConnection();
               }

            }

        
       private void panel1_Paint(object sender, PaintEventArgs e)
        {

       }

        private  void clean()
          {
            txtCustomerID.Text = "";
            txtDeviceID.Text = "";
            txtDeviceDescription.Text= "";
            txtSerialNo.Text = "";
            txtEmployeecbo.Text = "";
           dtpRegDate.Value = DateTime.Now;

   }

        private void txtDeviceID_TextChanged(object sender, EventArgs e)
        {

        }
 }
}

