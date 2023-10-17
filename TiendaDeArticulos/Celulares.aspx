<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Celulares.aspx.cs" Inherits="TiendaDeArticulos.Celulares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    </style>
     <h1>Celulares:</h1>    
    <div class="row row-cols-1 row-cols-md-3 g-5 mt-3 w-auto">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col gallery">
                        <div class="card">
                            <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" onerror= "this.src='https://www.mansor.com.uy/wp-content/uploads/2020/06/imagen-no-disponible2.jpg'" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <asp:Button ID="btnDetalle" CssClass="btn btn-primary" OnClick="btnDetalle_Click" runat="server" Text="Ver Detalle" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
