using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpers
{
    public static class Helper
    {

        // Método para validar solo números.
        public static  bool soloNumeros(string cadena)
        {
            foreach (char item in cadena)
            {
                if (!(char.IsNumber(item)))               
                    if (!(item.ToString() == ",")) // Para que me acepte numeros con decimales.                                                     
                        return false;             
            }
            return true;
        }

        // ACLARACIÓN: Maxi, de acá para abajo la verdad que se me complico con las validaciones, ya que el filtro usa "." para los números decimales
        // y el textBox del precio usa ",".


        // Método para que el usuario ingrese el número sin puntos porque puede llegar a ser confuso cuando quiera agregar un nuevo articulo
        // con un precio en decimales (por ejemplo que introduzca 2500.25 queriendo introducir 2500,25. Si hace lo primero el dgv lo toma como 250025.00... espero se entienda jaja)
        public static bool soloNumerosSinPuntos(string cadena)
        {
            foreach (char item in cadena)
            {
               if (char.IsPunctuation(item))
                {
                    
                    return true;
                }
            }
            return false;
        }

        // Maxi, acá tuve que hacer otro método de solonumeros para el filtro, porque en el textbox los números decimales los toma con "," y en el filtro
        // utiliza el "." para filtrar en la base de datos.
        public static bool soloNumerosFiltroAvanzado(string cadena)
        {
            foreach (char item in cadena)
            {
                if (!(char.IsNumber(item)))
                    if (!(item.ToString() == ".")) // Para que pueda filtrar números decimales.
                        return false;
            }
            return true;
        }


        // Para impedirle al usuario que filtre el número con "," ya que la base de datos filtra con "." los decimales.
        public static bool formatoCorrectoFiltroAvanzado(string cadena)
        {
            foreach (char item in cadena)
            {
                if ((item.ToString() == ","))
                {
                   
                    return true;
                }
            }
            return false;
        }


        // Este método lo hago para impedir que el usuario ingrese un número separado por puntos (por ejemplo: 25.000.25) ya que la base de datos
        // no va a permitir filtrarlo así.
        public static bool numeroSinPuntosFiltroAvanzado(string cadena)
        {
            int bandera = 0;
            foreach (char item in cadena)
            {
                if (char.IsPunctuation(item))
                {
                    bandera++;
                }
                if (bandera > 1)
                {
                   
                    return true;
                }
                    
            }
            return false;
        }
    }


}
