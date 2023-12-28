using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSSystem
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }
        public frmAdminDashboard(string title) {
            InitializeComponent();
            label1.Text = title;
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        public void LoadProduct()
        {
            SqlConnection _sqlConn = new SqlConnection(@"Data Source=FACULTY-218;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _sqlConn.Open();
            SqlCommand _cmd = new SqlCommand("SELECT * FROM products p INNER JOIN Category c ON P.CATID = C.ID", _sqlConn);
           SqlDataReader _dReader =  _cmd.ExecuteReader();
            while (_dReader.Read())
            {
                dataGridView1.Rows.Add(new object[] {_dReader.GetInt32(0), _dReader.GetString(2), _dReader.GetDouble(3), _dReader.GetInt32(4), _dReader.GetString(7) });
            }

           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmAddCat fmc = new frmAddCat();
            fmc.Show();
          //  new frmAddCat().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmAddPro().Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection _sqlConn = new SqlConnection(@"Data Source=FACULTY-218;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _sqlConn.Open();
            SqlCommand _cmd = new SqlCommand("UPDATE PRODUCTS SET PRONAME = @PRONAME,PRICE = @PRICE,QUANTITY=@QUANTITY WHERE ID = @ID", _sqlConn);
            _cmd.Parameters.Add("@PRONAME", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            _cmd.Parameters.Add("@PRICE", dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            _cmd.Parameters.Add("@QUANTITY", dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            _cmd.Parameters.Add("@ID", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            _cmd.ExecuteNonQuery();
            _sqlConn.Close();
           
            //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
            MessageBox.Show($"This value {dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()}has been updated");
        }
    }
}
