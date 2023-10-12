<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="TiendaDeArticulos.AltaArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label for="txtbID" CssClass="form-label" runat="server">Id</asp:Label>
                    <asp:TextBox ID="txtbID" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="txtbCodigo" CssClass="form-label" runat="server">Código</asp:Label>
                    <asp:TextBox ID="txtbCodigo" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="txtbNombre" CssClass="form-label" runat="server">Nombre</asp:Label>
                    <asp:TextBox ID="txtbNombre" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="ddlTipo" CssClass="form-label" runat="server">Categoria</asp:Label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label for="ddlDebilidad" runat="server" Text="Label" CssClass="form-label">Marca</asp:Label>
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                 <div class="mb-3">
                    <asp:Label for="txtbPrecio" CssClass="form-label" runat="server">Precio</asp:Label>
                    <asp:TextBox ID="txtPrecio" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Aceptar" OnClick="btnAceptar_Click" class="btn btn-primary" ID="btnAceptar" runat="server" />
                    <a href="ListaDeArticulos.aspx" class="btn btn-primary">Cancelar</a>
                    <asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" class="btn btn-danger" runat="server" Text="Borrar" />
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label for="txtbDescripcion" CssClass="form-label" runat="server">Descripción</asp:Label>
                    <asp:TextBox ID="txtbDescripcion" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Label for="txtbUrlImagen" CssClass="form-label" runat="server">Url Imagen</asp:Label>
                            <asp:TextBox ID="txtbUrlImagen" class="form-control" runat="server" AutoPostBack="true"
                               ></asp:TextBox>
                        </div>
                        <div>
                            <asp:Image ID="imgArticulo" runat="server" Width="54%" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
</asp:Content>
