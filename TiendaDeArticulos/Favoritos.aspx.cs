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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.sesionActiva(Session["user"]))
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            if (Request.QueryString["Id"] != null)
            {
                listaFavoritos = new List<Articulo>();
                ArticuloNegocio negocio = new ArticuloNegocio();
                string id = Request.QueryString["Id"];
                List<Articulo> articuloSeleccionado = new List<Articulo>();    
                articuloSeleccionado = negocio.listar(id);
                Articulo articulo = new Articulo();
                articulo = articuloSeleccionado[0];
                listaFavoritos.Add(articulo);
            }

            repRepetidor.DataSource = listaFavoritos;
            repRepetidor.DataBind();
        }
    }
}