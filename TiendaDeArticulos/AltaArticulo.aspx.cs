using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TiendaDeArticulos
{
    public partial class AltaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtbID.ReadOnly = true;
            btnEliminar.Visible = false;

            if (!IsPostBack)
            {
                CategoriaNegocio categorias = new CategoriaNegocio();
                MarcaNegocio marcas = new MarcaNegocio();

                ddlCategoria.DataSource = categorias.listar();
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();

                ddlMarca.DataSource = marcas.listar();
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();
            }
            string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                btnEliminar.Visible = true;
                btnAceptar.Text = "Modificar";
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articuloSeleccionado = negocio.listar(id)[0];

                txtbID.Text = articuloSeleccionado.Id.ToString();
                txtbNombre.Text = articuloSeleccionado.Nombre;
                txtbCodigo.Text = articuloSeleccionado.Codigo;
                txtbDescripcion.Text = articuloSeleccionado.Descripcion;
                txtbUrlImagen.Text = articuloSeleccionado.ImagenUrl;
                imgArticulo.ImageUrl = articuloSeleccionado.ImagenUrl;
                txtPrecio.Text = articuloSeleccionado.Precio.ToString("0.00");
                ddlCategoria.SelectedValue = articuloSeleccionado.Categoria.Descripcion;
                ddlMarca.SelectedValue = articuloSeleccionado.Marca.Descripcion;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();

            articulo.Nombre = txtbNombre.Text;
            articulo.Descripcion = txtbDescripcion.Text;
            articulo.Codigo = txtbCodigo.Text;
            articulo.ImagenUrl = txtbUrlImagen.Text;
            articulo.Precio = decimal.Parse(txtPrecio.Text);
            articulo.Categoria = new Categoria();
            articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
            articulo.Marca = new Marca();
            articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

            if (Request.QueryString["Id"] != null) 
            { 
                articulo.Id = int.Parse(txtbID.Text);
                negocio.modificar(articulo);
            }
            else
                negocio.agregarArticulo(articulo);

            Response.Redirect("ListaDeArticulos.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminar(int.Parse(Request.QueryString["Id"]));
            Response.Redirect("ListaDeArticulos.aspx", false);
        }
    }
}