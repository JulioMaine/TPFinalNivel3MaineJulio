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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar();
            

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();
            }

        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            FavoritoNegocio negocio = new FavoritoNegocio();
            User user = (User)Session["user"];
            negocio.insertarFavorito(user.Id.ToString(), )
        }
    }
}