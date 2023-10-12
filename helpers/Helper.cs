using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helpers
{
    public static class Helper
    {
        // Método para ocultar columnas.
        // Maxi, les hice sobrecargas para poder ocultar más de una columna, no sé si está bien hecho pero no se me
        // ocurrió otra forma de hacerlo, si tenés otra idea mejor la espero en la devolución del tp, gracias!
        public static void ocultarColumnas(DataGridView dataGridView, string columna1)
        {
            dataGridView.Columns[columna1].Visible = false;        
        }
        public static void ocultarColumnas(DataGridView dataGridView, string columna1, string columna2)
        {
            dataGridView.Columns[columna1].Visible = false;
            dataGridView.Columns[columna2].Visible = false;
        }

        public static void ocultarColumnas(DataGridView dataGridView, string columna1, string columna2, string columna3)
        {
            dataGridView.Columns[columna1].Visible = false;
            dataGridView.Columns[columna2].Visible = false;
            dataGridView.Columns[columna3].Visible = false;
        }


        // Metodo para cargar imagenes.
        public static void cargarImagen (PictureBox pictureBox, string urlImagen)
        {
            try
            {
                pictureBox.Load(urlImagen);
            }
            catch (Exception)
            {

                pictureBox.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
            }
        }

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
                    MessageBox.Show("Por favor ingrese el número sin puntos (ejemplo: 25000,25)");
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
                    MessageBox.Show("Por favor ingrese el número con '.' (ejemplo: 25000.25)");
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
                    MessageBox.Show("Por favor ingrese el número sin puntos (ejemplo: 25000.00)");
                    return true;
                }
                    
            }
            return false;
        }




        // Metodo para validar el data grid view.
        // Este método no sé si es correcto ponerlo en la clase Helper, lo hice porque lo tuve que usar muchas veces.
        // Aclaro que lo utilizo para cuando él data grid view no tiene nada seleccionado, por ejemplo cuando filtras y queda
        // la lista vacía.
        public static bool validarDgv(DataGridView dataGridView)
        {
            if (dataGridView.CurrentRow != null)
            {
                return false;
            }
            return true;
        }
    }


}
