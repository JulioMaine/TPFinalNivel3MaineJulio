<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Celulares.aspx.cs" Inherits="TiendaDeArticulos.Celulares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .tamañoImagen{
            height: 500px;
            width: 250px;
            object-fit: cover;
        }
    </style>
     <h1>Celulares:</h1>    
    <div class="row row-cols-1 row-cols-md-3 g-5 mt-3 w-auto">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%#Eval("ImagenUrl")%>" class="card-img-top tamañoImagen" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <a href="Detalle.aspx" class="btn btn-primary">Ver Detalle</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
