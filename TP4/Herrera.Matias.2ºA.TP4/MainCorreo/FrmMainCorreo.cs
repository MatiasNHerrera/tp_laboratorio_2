using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmMainCorreo : Form
    {
        Correo correo = new Correo();

        public FrmMainCorreo()
        {
            InitializeComponent();
        }

        private void FrmMainCorreo_Load(object sender, EventArgs e)
        {
            this.Text = "Correo UTN por Herrera.Matias.2ºA";
        }

        private void lblTrackingID_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.mtextTrackingID.Text);
            EventHandler evento = new EventHandler(paq_InformaEstado);

            p.InformarEstado += new Paquete.DelegadoEstado(paq_InformaEstado);

            try
            {
                correo += p;
            }
            catch(TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.ActualizarEstado();

        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }
        }

        private void ActualizarEstado()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach(Paquete p in correo.Paquetes)
            {
                if(p.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(p);
                }
                else if(p.Estado == Paquete.EEstado.Viajando)
                {
                    lstEstadoEnViaje.Items.Add(p);
                }
                else
                {
                    lstEstadoEntregado.Items.Add(p);
                }
            }
        }

        private void FrmMainCorreo_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    GuardaString.Guardar(rtbMostrar.Text, "salida");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
