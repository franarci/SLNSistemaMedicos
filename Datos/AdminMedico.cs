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
    public static class AdminMedico
    {
        public static List<Medico> Listar()  //Modelo conectado
        {
            string consulta = "SELECT Id,Nombre,Apellido,NroMatricula,EspecialidadId FROM dbo.Medico";

            SqlCommand comando = new SqlCommand(consulta, AdminDB.ConectarBase());
            SqlDataReader reader;

            //crear el reader
            reader = comando.ExecuteReader();

            //Recorrer leer los datos hacia adelante
            List<Medico> lista = new List<Medico>();

            while (reader.Read())
            {
                lista.Add(
                    new Medico(
                        Convert.ToInt32(reader["Id"]),
                        reader["Nombre"].ToString(),
                        reader["Apellido"].ToString(),
                        Convert.ToInt32(reader["NroMatricula"]),
                        Convert.ToInt32(reader["EspecialidadId"])
                        ));
            }
            AdminDB.ConectarBase().Close();
            return lista;
        }

        public static DataTable Listar(int especialidadId)
        {
            string consultaSQL = "select Id,Nombre,Apellido,NroMatricula,EspecialidadId from dbo.Medico where EspecialidadId=@EspecialidadId";

            SqlConnection conexion = AdminDB.ConectarBase();

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, conexion);

            
            adapter.SelectCommand.Parameters.Add("@EspecialidadId", SqlDbType.Int).Value = especialidadId;

           
            DataSet ds = new DataSet();

            
            adapter.Fill(ds, "Especialidad");

            return ds.Tables["Especialidad"];

        }

        public static DataTable TraerUno(int id)
        {
            string querySql = "SELECT Id,Nombre,Apellido,NroMatricula,EspecialidadId FROM dbo.Medico WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            //Declarar parametros
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            //Crear DataSet
            DataSet ds = new DataSet();
            adapter.Fill(ds, "idMedico");


            return ds.Tables["idMedico"];
        }

        
    }
}
