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
    public partial class FormUpd : Form
    {
        private Form1 form1;
        private FormQry formQry;

        public FormUpd()
        {
            InitializeComponent();
        }

        public FormUpd(Form1 form1, FormQry formQry)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formQry = formQry;
        }

        private void FormUpd_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT idalumno, nombre FROM alumnos", form1.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "idalumno";
            comboBox1.DisplayMember = "nombre";

            for (int i = 0; i <= 20; i++)
            {
                comboBox2.Items.Add("" + i);
                comboBox3.Items.Add("" + i);
                comboBox4.Items.Add("" + i);
            }

            PintaDatos();
        }

        private void PintaDatos()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT idalumno, nombre, nota1, nota2, nota3 FROM alumnos WHERE idalumno = " + comboBox1.SelectedValue, form1.cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataRow row = ds.Tables[0].Select().ElementAt(0);
                textBox1.Text = row["nombre"].ToString();
                comboBox2.SelectedIndex = Convert.ToInt32(row["nota1"].ToString());
                comboBox3.SelectedIndex = Convert.ToInt32(row["nota2"].ToString());
                comboBox4.SelectedIndex = Convert.ToInt32(row["nota3"].ToString());
            }
            else
            {
                MessageBox.Show("Seleccione Alumno");
            }  
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PintaDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                SqlCommand cm = new SqlCommand();

                cm.Connection = form1.cn;
                cm.CommandText = "UPDATE alumnos SET nombre = '" + textBox1.Text + "', " +
                                 "nota1 = " + comboBox2.SelectedIndex + ", " +
                                 "nota2 = " + comboBox3.SelectedIndex + ", " +
                                 "nota3 = " + comboBox4.SelectedIndex +
                                 " WHERE idalumno = " + comboBox1.SelectedValue;
                //MessageBox.Show(cm.CommandText); PARA SABER LOS POSIBLES ERRORES AL HACER LA CONSULTA
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
