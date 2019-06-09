using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoExcepcion : Exception
    {
        private string mensajeBase;

        public DniInvalidoExcepcion() : base()
        {

        }

        public DniInvalidoExcepcion(Exception e) : base(e.Message)
        {

        }

        public DniInvalidoExcepcion(string mensaje) : base(mensaje)
        {

        }

        public DniInvalidoExcepcion(string mensaje, Exception e) : base(mensaje, e.InnerException)
        {

        }
    }
}
