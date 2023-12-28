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
    public partial class frmAddPro : Form
    {
        public frmAddPro()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAddPro_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        public void LoadCombo() {
            comboBox1.Items.Clear();
            SqlConnection _conn = new SqlConnection(@"Data Source=FACULTY-218;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _conn.Open();
            SqlCommand _cmd = new SqlCommand("SELECT * FROM CATEGORY", _conn);
            SqlDataReader _dreader = _cmd.ExecuteReader();
            while (_dreader.Read())
            {
                comboBox1.Items.Add(_dreader["CATNAME"]);
              
            }
            _conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection _conn = new SqlConnection(@"Data Source=FACULTY-218;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _conn.Open();
            SqlCommand _cmd = new SqlCommand("INSERT INTO PRODUCTS(PRONAME,PRICE,QUANTITY,CATID) VALUES(@PRONAME,@PRICE,@QUANTITY,@CATID)", _conn);
            _cmd.Parameters.Add("@PRONAME", textBox1.Text);
            _cmd.Parameters.Add("@PRICE", textBox2.Text);
            _cmd.Parameters.Add("@QUANTITY", textBox3.Text);
            _cmd.Parameters.Add("@CATID", comboBox1.SelectedIndex+1);
            _cmd.ExecuteNonQuery();
            _conn.Close();
            MessageBox.Show("Data has been inserted.");
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
        }
    }
}
