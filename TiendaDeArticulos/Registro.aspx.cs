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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if (txtEmail.Text == "" || txtPassword.Text == "")
                    return;

                User nuevoUser = new User();
                UserNegocio nuevo = new UserNegocio();

                nuevoUser.Email = txtEmail.Text;
                nuevoUser.Pass = txtPassword.Text;
                nuevoUser.Id = nuevo.insertarNuevo(nuevoUser);
                Session.Add("user", nuevoUser);

                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");

            }
        }
    }
}