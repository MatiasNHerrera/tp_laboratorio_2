using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero nro1, Numero nro2, string operador)
        {
            double resultado = 0;

            operador = ValidarOperador(operador);

               switch(operador)
                {
                    case "+":
                        resultado = nro1 + nro2;
                        break;
                    case "-":
                        resultado = nro1 - nro2;
                        break;
                    case "*":
                        resultado = nro1 * nro2;
                        break;
                    case "/":
                         resultado = nro1 / nro2;
                         break;
                }
            

            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if(operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }

            return retorno;
        }

    
    }
}
