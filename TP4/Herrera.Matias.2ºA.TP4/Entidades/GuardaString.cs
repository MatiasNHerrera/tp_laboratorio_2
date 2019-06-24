using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo,true);
                writer.WriteLine(texto);
                retorno = true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (retorno)
                    writer.Close();
            }

            return retorno;

        }
    }
}
