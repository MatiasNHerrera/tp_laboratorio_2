using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto 
    {
        public enum ETipoLeche { Entera, Descremada }
        private ETipoLeche tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        /// 
  
        public Leche(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
            this.tipo = ETipoLeche.Entera;
        }

        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipoLeche tipo) : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }



        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------\n");

            return sb.ToString();
        }
    }
}
