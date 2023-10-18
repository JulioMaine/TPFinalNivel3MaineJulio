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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error || Page is Celulares || Page is Audio || Page is Media
            || Page is Televisores) || Page is Favoritos || Seguridad.sesionActiva(Session["user"]))
            {
                
                if (!(Seguridad.sesionActiva(Session["user"])))
                    Response.Redirect("login.aspx");
                else
                {
                    User user = (User)Session["user"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
            }

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();
            try
            {
                user.Email = txtUser.Text;
                user.Pass = txtPassword.Text;

                if (negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "password o email incorrectos");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("user");
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}