using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private string trackingID;
        private EEstado estado;
        public event DelegadoEstado InformarEstado;

        public Paquete(string direccion, string tracking)
        {
            this.DireccionEntrega = direccion;
            this.TrackingID = tracking;
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", this.trackingID, this.direccionEntrega);
        }

        public enum EEstado
        {
            Ingresado,
            Viajando,
            Entregado
        } 

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }


        public delegate void DelegadoEstado(object sender, EventArgs e);

        public override string ToString()
        {
            return this.MostrarDatos(this) + "\n";
        }

        public static bool operator == (Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if(p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {

                Thread.Sleep(4000);

                switch (this.estado)
                {
                    case EEstado.Ingresado:

                        this.estado = EEstado.Viajando;
                        break;

                    case EEstado.Viajando:

                        this.estado = EEstado.Entregado;
                        break;

                    default:

                        this.estado = EEstado.Entregado;
                        break;
                }

                this.InformarEstado(this, new EventArgs());
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
           
           
        }


    }
}
