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

namespace POSSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection _sqlConn = new SqlConnection(@"Data Source=FACULTY-218;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _sqlConn.Open();
            SqlCommand _cmd = new SqlCommand("SELECT * FROM USERS WHERE USERNAME = @UNAME AND PASSWORD = @UPASS ",_sqlConn);
         
            String sUserName = textBox1.Text;
            String sPassword = textBox2.Text;
            if (sUserName != String.Empty && sPassword != String.Empty)
            {
                _cmd.Parameters.Add("@UNAME", textBox1.Text);
                _cmd.Parameters.Add("@UPASS", textBox2.Text);
                SqlDataReader _dReader = _cmd.ExecuteReader();
                if (_dReader.Read()) {
                    if (_dReader.GetInt32(3) == 1)
                    {
                        new frmAdminDashboard(_dReader.GetString(1)).Show();
                        this.Hide();
                    }
                    else if (_dReader.GetInt32(3) == 2) {
                        new frmSaleDashboard().Show();
                        this.Hide();
                    }
                }
                else{
                    MessageBox.Show("Invalid user/password");
                }
               
              

            }
            else {

                MessageBox.Show("Field must not be empty");
            }
           
        }
    }
}
