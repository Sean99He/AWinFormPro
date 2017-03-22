using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WindowsFormsApplication.BAS
{
    public partial class Employee : DockContent
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            const string dbConStr = "Data Source=.;Initial Catalog=Test;Integrated Security=True";
            const string query = "SELECT id,name FROM dbo.Table1";
            DataTable tb = new DataTable();
            using (var connection = new SqlConnection(dbConStr))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(tb);
                }
            }
            dataGridView1.DataSource = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string dbConStr = "Data Source=.;Initial Catalog=Test;Integrated Security=True";
            StringBuilder builder = new StringBuilder("SELECT id,name FROM dbo.Table1 where 1=1 ");
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                builder.Append(string.Format(" and name like '%{0}%'", txtName.Text.Trim()));
            var query = builder.ToString();
            DataTable tb = new DataTable();
            using (var connection = new SqlConnection(dbConStr))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(tb);
                }
            }
            dataGridView1.DataSource = tb;
        }
    }
}
