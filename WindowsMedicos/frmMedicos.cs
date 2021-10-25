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
            LlenarCombo();
        }

        private void LlenarCombo()
        {


            DataTable Especialidad = AdminEspecialidad.Listar();

            
            cbEspecialidad.DisplayMember = Especialidad.Columns["Nombre"].ToString();
            cbEspecialidad.ValueMember = Especialidad.Columns["Id"].ToString();
            cbEspecialidad.DataSource = Especialidad;
            DataRow dataRow = Especialidad.NewRow();
            dataRow["Nombre"] = "[Todas]";
            Especialidad.Rows.InsertAt(dataRow, 0);
        }

        private void MostrarMedicos()
        {
            gridMedicos.DataSource= AdminMedico.Listar();
        }
    }
}
