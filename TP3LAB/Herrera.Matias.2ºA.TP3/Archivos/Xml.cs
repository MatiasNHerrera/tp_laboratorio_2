using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamWriter writer = new StreamWriter(archivo);
                serializer.Serialize(writer, datos);
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

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            datos = default(T);

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(archivo);
                datos = (T)deserializer.Deserialize(reader);
                retorno = true;
                reader.Close();

            }
            catch (Exception e)
            {
                retorno = false;
                throw new ArchivosException(e.InnerException);
            }

            return retorno;
        }
    }
}
