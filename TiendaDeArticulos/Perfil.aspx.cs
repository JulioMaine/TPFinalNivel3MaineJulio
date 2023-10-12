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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["user"]))
                    {
                        User user = (User)Session["user"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;

                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        {
                            imgPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Server.MapPath("./Images/");
                User user = (User)Session["user"];
                UserNegocio negocio = new UserNegocio();

                if (txtImage.PostedFile.FileName != "")
                {
                    txtImage.PostedFile.SaveAs(ruta + "Perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "Perfil-" + user.Id + ".jpg";
                    imgPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;



                negocio.actualizar(user);
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}