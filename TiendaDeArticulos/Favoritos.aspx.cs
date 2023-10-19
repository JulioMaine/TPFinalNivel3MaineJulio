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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.sesionActiva(Session["user"]))
            {
                Response.Redirect("Login.aspx", false);
                return;
            }



            ArticuloNegocio negocio = new ArticuloNegocio();
            FavoritoNegocio favorito = new FavoritoNegocio();
            User user = (User)Session["user"];

            if(Request.QueryString["Id"] != null)
            {
                favorito.insertarFavorito(user.Id.ToString(), Request.QueryString["Id"].ToString());
            }

            repRepetidor.DataSource = negocio.listarFavoritos(user.Id.ToString());
            repRepetidor.DataBind();
        }
    }
}