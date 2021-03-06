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
    public partial class FormIns : Form
    {
        private Form1 form1;
        private FormQry formQry;

        public FormIns()
        {
            InitializeComponent();
        }

        public FormIns(Form1 form1, FormQry formQry)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formQry = formQry;
        }

        private void FormIns_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 20; i++)
            {
                comboBox1.Items.Add("" + i);
                comboBox2.Items.Add("" + i);
                comboBox3.Items.Add("" + i);
            }

            comboBox1.SelectedIndex = 14;
            comboBox2.SelectedIndex = 14;
            comboBox3.SelectedIndex = 14;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                SqlCommand cm = new SqlCommand();
                cm.Connection = form1.cn;
                cm.CommandText = "INSERT INTO alumnos VALUES('" +
                                    textBox1.Text + "', " +
                                    comboBox1.SelectedIndex + ", " +
                                    comboBox2.SelectedIndex + ", " +
                                    comboBox3.SelectedIndex + ")";
                //MessageBox.Show(cm.CommandText); // PARA SABER LOS POSIBLES ERRORES AL HACER LA CONSULTA
                form1.cn.Open();
                cm.ExecuteNonQuery();
                form1.cn.Close();

                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(FormQry))
                    {
                        ((FormQry)form).consulta();
                        form.Activate();
                        form.BringToFront();
                    }
                }

                this.Dispose();
            }
            else
            {
                MessageBox.Show("Digite nombre de Alumno");
            }
        }
    }
}
