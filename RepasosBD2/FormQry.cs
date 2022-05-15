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

namespace RepasosBD2
{
    public partial class FormQry : Form
    {
        private Form1 form1;

        public FormQry()
        {
            InitializeComponent();
        }

        public FormQry(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void FormQry_Load(object sender, EventArgs e)
        {
            consulta();
        }

        public void consulta()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM alumnos", form1.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
