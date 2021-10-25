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
        public static List<Medico> Listar()
        {
            string consulta = "SELECT Nombre,Apellido,NroMatricula,IdEspecialidad FROM dbo.Medico";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());
            List<Medico> medicos = new List<Medico>()
            {
                new Medico("Pedro", "Perez", 32, 2),
                new Medico("Carla", "Arce", 15, 1)
            };
            return medicos;
        }

        public static DataTable Listar(int idEspecialidad)
        {
            //TODO Listar(idEspecialidad)
            return null;
        }

        public static DataTable TraerUno(int id)
        {
            //TODO TraerUno(id)
            return null;
        }

        public static int Crear(Medico medico)
        {


            string insertSQL = "INSERT dbo.Medico(Nombre,Apellido,NroMatricula, IdEspecialidad) VALUES(@Nombre, @Apellido, @NroMatricula, @IdEspecialidad)";

            SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConectarBase());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = medico.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = medico.Apellido;
            command.Parameters.Add("@NroMatricula", SqlDbType.Int).Value = medico.NroMatricula;
            command.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = medico.IdEspecialidad;

            //ejecuta el insert
            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }

        public static int Eliminar(int id)
        {
            string consulta = "DELETE FROM dbo.Medico WHERE Id=@Id";
            SqlCommand command = new SqlCommand(consulta, AdminDB.ConectarBase());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            //ejecuta el insert
            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
        public static int Modificar(Medico medico)
        {
            string consulta = "UPDATE dbo.Medico SET Nombre =@Nombre, Apellido=@Apellido, NroMatricula=@NroMatricula, IdEspecialidad= @IdEspecialidad WHERE Id=@Id";
            SqlCommand command = new SqlCommand(consulta, AdminDB.ConectarBase());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = medico.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = medico.Apellido;
            command.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = medico.IdEspecialidad;
            command.Parameters.Add("@NroMatricula", SqlDbType.Int).Value = medico.NroMatricula;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = medico.Id;


            //ejecuta el insert
            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
    }
}
