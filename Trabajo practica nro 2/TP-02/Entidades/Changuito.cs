using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito 
    {
        private List<Producto> productos;
        private int espacioDisponible;

        public enum ETipoProducto
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retorno = "";

            retorno += "Tenemos: " + this.productos.Count + " Espacios ocupados de: " + this.espacioDisponible + " Disponibles\n";

            foreach (Producto p in this.productos)
            {
                retorno += p.Mostrar();
            }

            return retorno;
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, ETipoProducto tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c.productos)
            {
                if(tipo == ETipoProducto.Snacks && v is Snacks)
                {
                    sb.AppendLine(v.Mostrar());
                }
                else if(tipo == ETipoProducto.Dulce && v is Dulce)
                {
                    sb.AppendLine(v.Mostrar());
                }
                else if(tipo == ETipoProducto.Leche && v is Leche)
                {
                    sb.AppendLine(v.Mostrar());
                }
                else if(tipo == ETipoProducto.Todos)
                {
                    sb.AppendLine(v.Mostrar());
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            bool confirmacion = false;

            
            foreach (Producto v in c.productos)
            {
                if ((v == p))
                {
                    {
                        confirmacion = true;
                        break;
                    }
                }

            }

            if (confirmacion == false && c.productos.Count < c.espacioDisponible)
            {
                c.productos.Add(p);
            }

            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {

            bool confirmacion = false;

            foreach (Producto v in c.productos)
            {
                if ((v == p))
                {
                    {
                        confirmacion = true;
                        break;
                    }
                }

            }

            if (confirmacion == true)
            {
                c.productos.Remove(p);
            }


            return c;
        }
        #endregion
    }
}
