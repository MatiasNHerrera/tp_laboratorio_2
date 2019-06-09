using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Profesor instructor;
        private Universidad.EClases clase;

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }


        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public static bool operator == (Jornada j, Alumno a)
        {
            bool retorno = false;

            if (a == j.clase)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator + (Jornada j, Alumno a)
        {
            bool validacion = false;

            foreach(Alumno al in j.alumnos)
            {
                if(al.DNI == a.DNI)
                {
                    validacion = true;
                    throw new AlumnoRepetidoException();
                    break;
                }
            }

            if((j == a) && validacion == false)
            {
                j.alumnos.Add(a);
            }
    

            return j;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "JORNADA\n";
            retorno += "CLASES DE: " + this.clase;
            retorno += " POR: " + this.instructor.ToString() + "\n";
            retorno += "ALUMNOS: \n";
            
            foreach(Alumno a in this.alumnos)
            {
                retorno += a.ToString() + "\n";
            }

            retorno += "<-------------------------------------->\n";
            return retorno;
        }

        public static bool Guardar(Jornada j)
        {
            Texto guardado = new Texto();
            bool retorno = false;
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if(guardado.Guardar(AppDomain.CurrentDomain.BaseDirectory + "jornada.txt", j.ToString()))
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public static string Leer ()
        {
            Texto Lectura = new Texto();

            string retorno = "";

            if(Lectura.Leer(AppDomain.CurrentDomain.BaseDirectory + "jornada.txt", out retorno))
            {
                retorno += "\n Se pudo leer\n";
            }


            return retorno;
        }
            


    }
}
