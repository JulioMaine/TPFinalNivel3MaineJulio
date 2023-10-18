using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TiendaDeArticulos
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articuloSeleccionado = negocio.listar(id)[0];

                txtbNombre.Text = articuloSeleccionado.Nombre;
                txtbDescripcion.Text = articuloSeleccionado.Descripcion;
                txtbUrlImagen.Text = articuloSeleccionado.ImagenUrl;
                imgArticulo.ImageUrl = articuloSeleccionado.ImagenUrl;
                txtPrecio.Text = "$" + articuloSeleccionado.Precio.ToString("0.00");
                txtMarca.Text = articuloSeleccionado.Marca.Descripcion;
                txtCategoria.Text = articuloSeleccionado.Categoria.Descripcion;

            }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Session.Add("error", "Este es proyecto de practica, lamentablemente los articulos no existen.");
            Response.Redirect("Error.aspx", false);
        }

    }
}