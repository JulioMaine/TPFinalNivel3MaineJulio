<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TiendaDeArticulos.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2">
        </div>
        <div class="col">
            <h1 class="text-white">Mi Perfil</h1>
        </div>
        <div class="col-2">
        </div>
    </div>
    <div class="row">

        <div class="col-2">
        </div>
        <div class="col-4">
            <div class="mb-3">
                <asp:Label runat="server" class="form-label fs-6 h1 text-white" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" class="form-control bg-dark text-white" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <hr />
                <asp:Label runat="server" class="form-label fs-6 h1 text-white" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" class="form-control bg-dark text-white" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <hr />
                <asp:Label runat="server" class="form-label fs-6 h1 text-white" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" class="form-control bg-dark text-white" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <hr />
                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                <a href="/">Regresar</a>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" class="form-label fs-6 h1 text-white" Text="Imagen de Perfil"></asp:Label>
                <input type="file" id="txtImage" class="form-control bg-dark text-white" name="name" runat="server" />
            </div>
            <asp:Image runat="server" ID="imgPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" CssClass="img-fluid mb-3"></asp:Image>
        </div>
        <div class="col-2">
        </div>

    </div>
    <div class="row">

        <div class="col-2">
        </div>
        <div class="col">
            <%--<asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            <a href="/">Regresar</a>--%>
        </div>
        <div class="col-2">
        </div>
    </div>
</asp:Content>
