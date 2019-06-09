using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;


        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }


        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public Jornada this[int index]
        {
            get
            {
                Jornada j = null;

                int i = 0;

                foreach(Jornada ju in this.jornada)
                {
                    if(i == index)
                    {
                        j = ju;
                        break;
                    }

                    i++;
                }

                return j;
            }

            set
            {
                int i = 0;

                foreach (Jornada ju in this.jornada)
                {
                    if (i == index)
                    {
                        this.jornada[i] = value;
                    }

                    i++;
                }
            }

            
        }

        public static bool operator ==(Universidad u, Alumno a)
        {
            bool retorno = false;
            
            foreach(Alumno al in u.alumnos)
            {
                if(a == al)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        public static bool operator ==(Universidad u, Profesor p)
        {
            bool retorno = false;

            foreach(Profesor pr in u.profesores)
            {
                if(pr == p)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor pr = null;
            bool validacion = false;

            foreach(Profesor p in u.profesores)
            {
                if(p == clase)
                {
                    pr = p;
                    validacion = true;
                    break;
                }

            }

            if(validacion == false)
            {
                throw new SinProfesorException();
            }

            return pr;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor pr = null;

            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    pr = p;
                    break;
                }
            }

            return pr;
        }

        public static Universidad operator + (Universidad u, EClases clase)
        {
            Profesor p;
            int i = 0;
            p = u == clase;
                
            Jornada j = new Jornada(clase, p);

            foreach (Alumno a in u.alumnos)
            {
                if (a == clase)
                {
                    j.Alumnos.Add(a);
                }
            }
   
            u.jornada.Add(j);

            return u;
            
        }

        public static Universidad operator + (Universidad u, Alumno a)
        {
            if(!(u == a))
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (!(u == p))
            {
                u.profesores.Add(p);
            }

            return u;
        }

        private static string MostrarDatos(Universidad u)
        {
            string retorno = "";

            foreach(Jornada j in u.jornada)
            {
                retorno += j.ToString();
            }

            return retorno;
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> Guardar = new Xml<Universidad>();
            bool retorno = false;

            if(Guardar.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni))
            {
                retorno = true;
            }

            return retorno;
        }

        public static Universidad Leer()
        {
            Xml<Universidad> lector = new Xml<Universidad>();
            Universidad u = new Universidad();

            lector.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out u);

            return u;
        }
    }
}
