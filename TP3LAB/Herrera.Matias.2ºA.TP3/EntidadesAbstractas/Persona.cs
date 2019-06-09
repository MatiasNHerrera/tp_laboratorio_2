using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.DNI = dni;
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int resultado = 0;
            string aux = dato.ToString();

            if (aux.ToCharArray().Length <= 8 && aux.ToCharArray().Length > 1 && int.TryParse(aux, out resultado) && nacionalidad == ENacionalidad.Argentino && int.Parse(aux) > 0 && int.Parse(aux) < 90000000)
            {
                return dato;
            }
            else if (aux.ToCharArray().Length <= 8 && aux.ToCharArray().Length > 1 && int.TryParse(aux, out resultado) && nacionalidad == ENacionalidad.Extranjero && int.Parse(aux) > 89999999 && int.Parse(aux) < 100000000)
            {
                return dato;
            }
            else if (aux.ToCharArray().Length <= 8 && aux.ToCharArray().Length > 1 && int.TryParse(aux, out resultado))
            {
                throw new DniInvalidoExcepcion("Error en el formato ingresado sobre el dni");
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }


        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int resultado = 0;

            if (dato.ToCharArray().Length <= 8 && dato.ToCharArray().Length > 1 && int.TryParse(dato, out resultado) && nacionalidad == ENacionalidad.Argentino && int.Parse(dato) > 1 && int.Parse(dato) < 89999999)
            {
                return int.Parse(dato);
            }
            else if (dato.ToCharArray().Length <= 8 && dato.ToCharArray().Length > 1 && int.TryParse(dato, out resultado) && nacionalidad == ENacionalidad.Extranjero && int.Parse(dato) > 90000000 && int.Parse(dato) < 99999999)
            {
                return int.Parse(dato);
            }
            else if (dato.ToCharArray().Length > 8 && dato.ToCharArray().Length < 1 || !(int.TryParse(dato, out resultado)))
            {
                throw new DniInvalidoExcepcion("Error en el formato ingresado sobre el dni");
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }

        }

        private string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[A-Za-zÁ-Úá-ú]+$");
            string retorno = null;

            if (r.IsMatch(dato) == true)
            {
                retorno = dato;
            }

            return retorno;
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }



        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }


        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Nombre + " " + this.Apellido + "\nNACIONALIDAD: " + this.Nacionalidad;
        }
    }
}
