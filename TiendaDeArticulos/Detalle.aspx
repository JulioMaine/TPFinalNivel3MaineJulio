<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TiendaDeArticulos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scripManagerDetalle">
        </asp:ScriptManager>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label for="txtbNombre" CssClass="form-label text-white" runat="server">Nombre</asp:Label>
                    <asp:TextBox ID="txtbNombre" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="txtCategoria" CssClass="form-label text-white" runat="server">Categoria</asp:Label>
                    <asp:TextBox ID="txtCategoria" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="txtMarca" runat="server" Text="Label" CssClass="form-label text-white">Marca</asp:Label>
                    <asp:TextBox ID="txtMarca" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label for="txtbPrecio" CssClass="form-label text-white" runat="server">Precio</asp:Label>
                    <asp:TextBox ID="txtPrecio" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button runat="server" ID="btnComprar" OnClick="btnComprar_Click" CssClass="btn btn-success btn-lg" Text="Comprar ahora" />
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label for="txtbDescripcion" CssClass="form-label text-white" runat="server">Descripción</asp:Label>
                    <asp:TextBox ID="txtbDescripcion" ReadOnly="true" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Image ID="imgArticulo" runat="server" Width="54%" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
</asp:Content>
