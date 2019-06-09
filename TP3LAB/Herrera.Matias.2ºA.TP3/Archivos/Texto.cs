using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                StreamWriter writer = new StreamWriter(archivo);
                writer.Write(datos);
                retorno = true;
                writer.Close();
            }
            catch(Exception e)
            {
                retorno = false;
                throw new ArchivosException(e.InnerException);
                
            }

            return retorno;
            
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = null;

            try
            {
                StreamReader reader = new StreamReader(archivo,true);
                while (!reader.EndOfStream)
                {
                    datos += reader.ReadLine();
                    datos += "\n";
                }
                retorno = true;
                reader.Close();
            }
            catch(Exception e)
            {
                retorno = false;
                throw new ArchivosException(e.InnerException);
            }

            return retorno;


        }

        
    }
}
