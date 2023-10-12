<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TiendaDeArticulos.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
        <div class="col-4 mx-4" >
                    <div class="mb-3">
                        <h5>¡Creá tu cuenta!</h5>
                        <label for="exampleDropdownFormEmail1" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="exampleDropdownFormPassword1" class="form-label">Password</label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password"  runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnRegistro" CssClass="btn btn-primary" OnClick="btnRegistro_Click" runat="server" Text="Registrarse" />
        </div>
    </div>
</asp:Content>
