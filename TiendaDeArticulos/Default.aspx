<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TiendaDeArticulos.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Proyecto web e-commerce</h1>
	<p>Este es un proyecto web de practica, los articulos mostrados son a modo de prueba.</p>
       <div class="row row-cols-1 row-cols-md-3 g-4 mt-3">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col gallery">
                        <div class="card border-black" style="width: 90%">
                            <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" Style="max-width:500px;max-height:600px;" onerror= "this.src='https://www.mansor.com.uy/wp-content/uploads/2020/06/imagen-no-disponible2.jpg'" alt="...">
                            <div class="card-body bg-success">
                                <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <a href="Detalle.aspx?Id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a>
                                <a class="card-text text-sm-start btn btn-primary"  href="Favoritos.aspx?Id=<%#Eval("Id") %>">⭐</a> 
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
