using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public double ValidarNumero(string strNumero)
        {
            double retorno;

            if (!double.TryParse(strNumero, out retorno))
            {
                retorno = 0;
                return retorno;

            }
            else
            {
                return retorno;
            }

        }


        public string SetNumero
        {
            set
            {
                if (ValidarNumero(value) != 0)
                {
                    this.numero = double.Parse(value);
                }

            }
        }

        public string binarioDecimal(string binario)
        {
            string retornoDecimal = "";
            char[] arrayString = binario.ToCharArray();

            for (int i = 0; i < arrayString.Length; i++)
            {
                if (arrayString[i] == '1' || arrayString[i] == '0')
                {
                    retornoDecimal += arrayString[i];
                }
                else
                {
                    retornoDecimal = "Valor invalido";
                    break;
                }
            }

            if (retornoDecimal != "Valor invalido")
            {
                retornoDecimal = Convert.ToInt32(binario, 2).ToString();
            }


            return retornoDecimal;
        }

        public string decimalBinario(double numero)
        {
            string retorno = "";

            string parseo;

            parseo = numero.ToString();

            retorno = retorno + decimalBinario(parseo);

            return retorno;
        }

        public string decimalBinario(string numero)
        {
            string retorno = "";
            int auxNumero = 0;

            if(int.TryParse(numero, out auxNumero))
            {
                retorno = retorno + (Convert.ToString(auxNumero, 2)).ToString();
            }
            else
            {
                retorno = "Valor Invalido";
            }

            return retorno;
        }

        public static double operator +(Numero nro1, Numero nro2)
        {
            double retorno = 0;

            retorno = nro1.numero + nro2.numero;

            return retorno;
        }

        public static double operator -(Numero nro1, Numero nro2)
        {
            double retorno = 0;

            retorno = nro1.numero - nro2.numero;

            return retorno;
        }

        public static double operator /(Numero nro1, Numero nro2)
        {
            double retorno = 0;

            if (nro1.numero == 0)
            {
                retorno = 0;
            }
            else if (nro2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = nro1.numero / nro2.numero;
            }
            
            return retorno;
        }

        public static double operator *(Numero nro1, Numero nro2)
        {
            double retorno = 0;

            retorno = nro1.numero * nro2.numero;

            return retorno;
        }
    }
}
