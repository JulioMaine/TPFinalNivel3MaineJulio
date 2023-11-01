﻿using System;
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
            try
            {
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo articuloSeleccionado = negocio.listar(id)[0];

                    txtbNombre.Text = articuloSeleccionado.Nombre;
                    txtbDescripcion.Text = articuloSeleccionado.Descripcion;
                    imgArticulo.ImageUrl = articuloSeleccionado.ImagenUrl;
                    txtPrecio.Text = "$" + articuloSeleccionado.Precio.ToString("0.00");
                    txtMarca.Text = articuloSeleccionado.Marca.Descripcion;
                    txtCategoria.Text = articuloSeleccionado.Categoria.Descripcion;

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Error.aspx", false);
                Session.Add("error", "Este es un proyecto de practica, los articulos no existen.");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}