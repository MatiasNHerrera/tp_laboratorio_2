using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
            comando = new SqlCommand();
        }

        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) values ('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Herrera')";

                if (comando.ExecuteNonQuery() > 0)
                {
                    retorno = true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if(retorno)
                {
                    conexion.Close();
                }
            }

            return retorno;

        }


    }
}
