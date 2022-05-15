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
    public partial class Form1 : Form
    {
        public SqlConnection cn;
        private FormQry formQry;

        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection("Data Source=(local);Initial Catalog=parainfo;Integrated Security=SSPI;");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form form in Application.OpenForms)
            {
                if(form.GetType() == typeof(FormQry))
                {
                    form.Activate();
                    return;
                }
            }

            formQry = new FormQry(this);
            formQry.MdiParent = this;
            formQry.Show();
            formQry.BringToFront();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIns formIns = new FormIns(this, formQry);

            formIns.MdiParent = this;
            formIns.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDel formDel = new FormDel(this, formQry);

            formDel.MdiParent = this;
            formDel.Show();
        }

        private void actualizarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpd formUpd = new FormUpd(this, formQry);

            formUpd.MdiParent = this;
            formUpd.Show();
        }
    }
}
