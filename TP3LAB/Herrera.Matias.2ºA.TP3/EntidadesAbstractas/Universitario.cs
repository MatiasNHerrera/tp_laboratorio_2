using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario() : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            return  base.ToString() + "\n\nLEGAJO NUMERO: " + this.legajo + "\n";
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.DNI == pg2.DNI && pg1.legajo == pg2.legajo)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
