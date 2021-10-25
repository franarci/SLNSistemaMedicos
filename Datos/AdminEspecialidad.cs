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
            string querySql = "SELECT Id,Nombre,Apellido,NroMatricula,EspecialidadId FROM dbo.Medico WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Medico");


            return ds.Tables["Medico"];
        }

        public static int Crear(Especialidad especialidad)
        {
            string querySql = "INSERT INTO dbo.Especialidad (Nombre) VALUES (@Nombre)";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());


            adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = especialidad.Nombre;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();

            return filasAfectadas;
        }
    }
}
