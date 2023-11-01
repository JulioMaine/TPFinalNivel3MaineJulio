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
    public partial class ListaDeArticulos : System.Web.UI.Page
    {

        // Maxi, hice un poco de choclo en el code behind tratando de acomodar el filtro, PERDON JAJA!
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FiltroAvanzado = ckbFiltroAvanzado.Checked;

                if (!Seguridad.esAdmin(Session["user"]))
                {
                    Session.Add("error", "No eres admin");
                    Response.Redirect("Error.aspx", false);
                }


                // Guardo en Session las listas filtradas para que se carguen con el PageIndexChanging.
                if (Session["listaFiltradaAvanzada"] != null)
                {
                    dgvArticulos.DataSource = Session["listaFiltradaAvazada"];
                    dgvArticulos.DataBind();
                    btnBuscar_Click(sender, e);
                }
                if (Session["listaFiltradaRapida"] != null)
                {
                    dgvArticulos.DataSource = Session["listaFiltradaRapida"];
                    dgvArticulos.DataBind();
                    txtFiltroRapido_TextChanged(sender, e);
                }

                if (!IsPostBack || !ckbFiltroAvanzado.Checked)
                {
                    FiltroAvanzado = false;
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    dgvArticulos.DataSource = negocio.listar();
                    dgvArticulos.DataBind();
                    if (Session["listaFiltradaRapida"] != null)
                    {
                        dgvArticulos.DataSource = Session["listaFiltradaRapida"];
                        dgvArticulos.DataBind();
                    }


                    Session.Add("listaArticulos", negocio.listar());
                }

                if (!IsPostBack)
                {
                    //Para que esten precargados los valores del ddlCriterio
                    ddlCriterio.Items.Clear();
                    ddlCriterio.Items.Add("Empieza con:");
                    ddlCriterio.Items.Add("Termina con:");
                    ddlCriterio.Items.Add("Contiene:");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = dgvArticulos.SelectedDataKey.Value.ToString();
                Response.Redirect("AltaArticulo.aspx?Id=" + id, false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ckbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroAvanzado = ckbFiltroAvanzado.Checked;
                txtFiltroRapido.Enabled = !FiltroAvanzado;
                txtFiltroRapido.Text = "";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];
                List<Articulo> listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();

                Session.Add("listaFiltradaRapida", listaFiltrada);
                Session.Remove("listaFiltradaAvanzada");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (Session["listaFiltradaAvanzada"] == null && Session["listaFiltradaRapida"] == null)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    dgvArticulos.DataSource = negocio.listar();
                    dgvArticulos.DataBind();
                }

                dgvArticulos.PageIndex = e.NewPageIndex;
                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCriterio.Items.Clear();
                if (ddlCampo.SelectedValue == "Nombre" || ddlCampo.SelectedValue == "Descripción")
                {
                    ddlCriterio.Items.Add("Empieza con:");
                    ddlCriterio.Items.Add("Termina con:");
                    ddlCriterio.Items.Add("Contiene:");
                }
                else if (ddlCampo.SelectedValue == "Precio")
                {
                    ddlCriterio.Items.Add("Mayor o igual a:");
                    ddlCriterio.Items.Add("Menor o igual a:");
                    ddlCriterio.Items.Add("Precio exacto:");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ddlCampo.SelectedValue) && !string.IsNullOrEmpty(ddlCriterio.SelectedValue))
                {
                    if (txtbFiltroAvanzado.Text == "")
                    {
                        ArticuloNegocio negocio2 = new ArticuloNegocio();
                        dgvArticulos.DataSource = negocio2.listar();
                        dgvArticulos.DataBind();
                        return;
                    }

                    if (ddlCampo.Text == "Precio" && !helpers.Helper.soloNumeros(txtbFiltroAvanzado.Text))
                        return;

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> listaFiltrada = negocio.filtrar(ddlCampo.SelectedValue.ToString(), ddlCriterio.SelectedValue.ToString(), txtbFiltroAvanzado.Text);
                    dgvArticulos.DataSource = listaFiltrada;
                    dgvArticulos.DataBind();

                    Session.Add("listaFiltradaAvanzada", listaFiltrada);
                    Session.Remove("listaFiltradaRapida");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}