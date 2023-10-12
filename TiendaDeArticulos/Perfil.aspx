<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TiendaDeArticulos.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
         <div class="col-1" style="width: 25px">
        </div>
        <div class="col">
            <h1 class="fs-3">Mi Perfil</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-1" style="width: 25px">
        </div>
        <div class="col-md-3">
            <div class="mb-3">
                <asp:Label runat="server" class="form-label fs-6 h1 font-weight-bold" Text="Email"></asp:Label>
                <asp:TextBox Id="txtEmail" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <hr />
                <asp:Label runat="server"  class="form-label fs-6 h1 font-weight-bold" Text="Nombre"></asp:Label>
                <asp:TextBox Id="txtNombre" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <hr />
                <asp:Label runat="server"  class="form-label fs-6 h1 font-weight-bold" Text="Apellido"></asp:Label>
                <asp:TextBox id="txtApellido" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="mb-3">
                <asp:Label runat="server" class="form-label fs-6 h1 font-weight-bold" Text="Imagen de Perfil"></asp:Label>
                <input type="file" id="txtImage" class="form-control" name="name" runat="server" /> 
            </div>
            <asp:Image runat="server" id="imgPerfil" imageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" cssclass="img-fluid mb-3"></asp:Image>
        </div>
    </div>
    <div class="row">
        <div class="col-1" style="width: 25px">
        </div>
        <div class="col-md-4">   
            <asp:Button runat="server" id="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click"  cssclass="btn btn-primary" />
            <a href="/">Regresar</a>
        </div>
    </div>
</asp:Content>
