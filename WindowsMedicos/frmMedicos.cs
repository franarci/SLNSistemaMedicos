using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsMedicos
{
    public partial class frmMedicos : Form
    {
        public frmMedicos()
        {
            InitializeComponent();
        }

        private void frmMedicos_Load(object sender, EventArgs e)
        {
            MostrarMedicos();
. compo            LlenarCombo(cbEspecialidadCrear);
            
            //uso el metodo llenar combo generico y le agrego una fila [Todas]
            DataTable filtrarEspecialidad = LlenarCombo(cbEspecialidad);
            DataRow dataRow = filtrarEspecialidad.NewRow();
            dataRow["Nombre"] = "[Todas]";
            filtrarEspecialidad.Rows.InsertAt(dataRow, 0);
        }

        private DataTable LlenarCombo(ComboBox combo)
        {
            DataTable Especialidad = AdminEspecialidad.Listar();
            
            combo.DisplayMember = Especialidad.Columns["Nombre"].ToString();
            combo.ValueMember = Especialidad.Columns["Id"].ToString();
            combo.DataSource = Especialidad;
            return Especialidad;
        }

        private void MostrarMedicos()
        {
            gridMedicos.DataSource= AdminMedico.Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtMatricula.Text), Convert.ToInt32(cbEspecialidadCrear.SelectedValue));

            int filasAfectadas = AdminMedico.Crear(medico);

            if (filasAfectadas > 0)
            {
                MostrarMedicos();
            }
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidad = cbEspecialidad.SelectedValue.ToString();

            if (especialidad == "")
            {
                MostrarMedicos();
            }
            else
            {
                gridMedicos.DataSource = AdminMedico.Listar(Convert.ToInt32(cbEspecialidad.SelectedValue));
            }
        }
    }
}
