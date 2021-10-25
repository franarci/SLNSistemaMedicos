using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos.Servidor
{
    internal static class AdminDB
    {
        internal static SqlConnection ConectarBase()
        {
            string cadena = Properties.Settings.Default.KeyMedicos;

            //objeto de conexion
            SqlConnection connection = new SqlConnection(cadena);
            connection.Open();

            return connection;
        }
    }
}
