using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases clasesQueToma;
        EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }


        public Alumno() : base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\nESTADO DE CUENTA: " + this.estadoCuenta + this.ParticiparEnClase() + "\n";
        }

        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASE DE: " + this.clasesQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases e)
        {
            bool retorno = false;

            if (a.clasesQueToma == e && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Alumno a, Universidad.EClases e)
        {
            bool retorno = false;

            if (a.clasesQueToma != e)
            {
                retorno = true;
            }

            return retorno;
        }

    }
}
