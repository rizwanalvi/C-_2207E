using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POSSystem
{    public partial class frmAddCat : Form
    {        public frmAddCat()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "CATEGORY";
        }
                private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=FACULTY-218;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _conn.Open();
            SqlCommand _cmd = new SqlCommand("INSERT INTO CATEGORY VALUES(@CATNAME)", _conn);
            _cmd.Parameters.Add("@CATNAME", textBox1.Text);
            _cmd.ExecuteNonQuery();
            _conn.Close();
            textBox1.Text = String.Empty;
            MessageBox.Show("Data has been inserted.");
            LoadGridData();
         }
        public void LoadGridData() {
            SqlConnection _conn = new SqlConnection(@"Data Source=FACULTY-218;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _conn.Open();
            SqlCommand _cmd = new SqlCommand("SELECT * FROM CATEGORY", _conn);
            SqlDataReader _dreader  = _cmd.ExecuteReader();
            while (_dreader.Read()) 
            {
                dataGridView1.Rows.Add(new object[] { _dreader["ID"], _dreader["CATNAME"] });
            }
            _conn.Close();
                    }
        private void frmAddCat_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
    }
}
