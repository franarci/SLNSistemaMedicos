using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebMedicos
{
    public partial class VistaMedico : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarDatos();
            LlenarCombo();
        }

        private void LlenarCombo()
        {
            DataTable dt = AdminEspecialidad.Listar();
            dropEspecialidad.DataSource = dt;
            dropEspecialidad.DataValueField = dt.Columns["Id"].ToString();
            dropEspecialidad.DataTextField = dt.Columns["Nombre"].ToString();
            dropEspecialidad.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtNroMatricula.Text), Convert.ToInt32(dropEspecialidad.SelectedValue));

            int filasAfectadas = AdminMedico.Crear(medico);

            Actualizar(filasAfectadas);
        }

        private void Actualizar(int filasAfectadas)
        {
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }

            if (!Page.IsPostBack)
            {
                MostrarDatos();
                LlenarCombo();
            }
        }

        private void MostrarDatos()
        {
            gridMedico.DataSource = AdminMedico.Listar();
            gridMedico.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico(Convert.ToInt32(txtId.Text), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtNroMatricula.Text), Convert.ToInt32(dropEspecialidad.SelectedValue));

            int filasAfectadas = AdminMedico.Modificar(medico);
            Actualizar(filasAfectadas);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int filasAfectadas = AdminMedico.Eliminar(Convert.ToInt32(txtId.Text));
            Actualizar(filasAfectadas);
        }
    }
}