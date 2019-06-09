using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public Profesor() : base()
        {

        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }

        protected override string ParticiparEnClase()
        {
            string retorno = "";
            retorno += "CLASES DEL DIA: \n";

            foreach(Universidad.EClases e in this.clasesDelDia)
            {
                retorno += e.ToString() + "\n";
            }

            return retorno;
        }

        private void _randomClase()
        {
            Array valores = Enum.GetValues(typeof(Universidad.EClases));

            for (int i = 0; i < 2; i++)
            {
                clasesDelDia.Enqueue((Universidad.EClases)valores.GetValue(random.Next(valores.Length)));
            }


        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases e in i.clasesDelDia)
            {
                if (e == clase)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string MostrarDatos()
        {
            string retorno = "";

            retorno += base.MostrarDatos();
            retorno += this.ParticiparEnClase();

            return retorno;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
