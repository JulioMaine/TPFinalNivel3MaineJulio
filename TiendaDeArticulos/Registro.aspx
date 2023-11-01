<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TiendaDeArticulos.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScripManagerRegistro" runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>


            <div class="row">
                <div class="col-4">
                </div>
                <div class="col mx-4">
                    <div class="mb-3">
                        <h4 class="text-white text-center">¡Creá tu cuenta!</h4>
                        <label for="exampleDropdownFormEmail1" class="form-label text-white">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control text-white bg-dark" TextMode="Email" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ErrorMessage="El e-mail no es valido" CssClass="validacion text-danger" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="exampleDropdownFormPassword1" class="form-label text-white">Password</label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control text-white bg-dark" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ErrorMessage="Se requiere un minimo de 4 caracteres hasta un maximo de 15." CssClass="validacion text-danger" ControlToValidate="txtPassword" ValidationExpression="^[\s\S]{4,15}$" runat="server" />
                    </div>
                <asp:Button ID="btnRegistro" CssClass="btn btn-primary" OnClick="btnRegistro_Click" runat="server" Text="Registrarse" />
                <div class="text-white mt-3">
                    <p class="h5 text-white">O ingresá directamente con:</p>
                    <p>Cuenta usuario(funcionalidades como usuario):</p>
                    <p class="text-success">Email: user@user.com     Password: user</p>
                    <p>Cuenta admin(funcionalidades como admin):</p>
                    <p class="text-success">Email: admin@admin.com   Password: admin</p>
                </div>
            </div>
            <div class="col-4">
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
