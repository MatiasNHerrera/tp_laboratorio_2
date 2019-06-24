using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }


        public static Correo operator + (Correo c, Paquete p)
        {
            bool validacion = false; 

            foreach(Paquete pa in c.paquetes)
            {
                if(pa == p)
                {
                    validacion = true;
                }
            }

            if(!validacion)
            {
                try
                {
                    c.paquetes.Add(p);
                    Thread hilo = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(hilo);
                    hilo.Start();
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                throw new TrackingIdRepetidoException("Error, el paquete ya se encuentra en el correo");
            }

            return c;
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string retorno = "";

            foreach (Paquete p in this.paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado);
            }

            return retorno;

        }

        public void FinEntregas()
        {
            foreach(Thread t in this.mockPaquetes)
            {
                if(t.IsAlive)
                {    
                   t.Abort();
                }
            }
        }

    }
}
