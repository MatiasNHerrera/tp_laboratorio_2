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

namespace MiCalculadora
{
    public partial class frmCalculadora : Form
    {
        Calculadora NuevaCalculador = new Calculadora();

        public frmCalculadora()
        {
            InitializeComponent();

            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {
     
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            textNumero1.Clear();
            textNumero2.Clear();
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }

        private double OperarCalculadora(string numero1, string numero2, string operador)
        {
            double retorno = 0;

            Numero NumeroUno = new Numero(numero1);
            Numero NumeroDos = new Numero(numero2);

            retorno = NuevaCalculador.Operar(NumeroUno, NumeroDos, operador);

            return retorno;
    
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (OperarCalculadora(textNumero1.Text, textNumero2.Text, cmbOperador.Text)).ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numeroBinario = new Numero();
            double resultado;
            string resultadoString = "";

            if(double.TryParse(lblResultado.Text, out resultado))
            {
               resultadoString += numeroBinario.decimalBinario(resultado);

               MessageBox.Show("la conversion a binario es: " + resultadoString);
            }
           
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numeroDecimal = new Numero();

            string resultado = "";
            if (lblResultado.Text != "")
            {
                resultado += numeroDecimal.binarioDecimal(lblResultado.Text);
                MessageBox.Show("la conversion a decimal es: " + resultado);
            }

        }
    }
}
