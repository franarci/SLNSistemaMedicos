using Datos.Servidor;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class AdminEspecialidad
    {
        public static DataTable Listar()
        {
            string consulta = "select Id, Nombre from dbo.Especialidad";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Especialidad");

            return ds.Tables["Especialidad"];

        }

        public static DataTable TraerUno(int id)
        {
            //TODO TraerUno(id)
            return null;
        }

        public static int Crear(Especialidad especialidad)
        {
            //TODO Crear(especialidad)
            return 0;
        }
    }
}
