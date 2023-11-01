<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Audio.aspx.cs" Inherits="TiendaDeArticulos.Audio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
        <h2 class="text-center text-white">Proyecto web e-commerce</h2>
    <p class="text-center text-white">Los artículos mostrados no existen, son a modo de prueba</p>
    <div class="row row-cols-1 row-cols-md-3 g-5 mt-3">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                      <div class="card border-black" style="width: 90%">
                            <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" Style="max-width:500px;max-height: 700px; object-fit:cover" onerror= "this.src='https://www.mansor.com.uy/wp-content/uploads/2020/06/imagen-no-disponible2.jpg'" alt="...">
                            <div class="card-body bg-dark">
                                <h5 class="card-title text-white"><%#Eval("Nombre")%></h5>
                                <p class="card-text text-white"><%#Eval("Descripcion")%></p>
                                <a href="Detalle.aspx?Id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a>
                                <a class="card-text text-sm-start btn btn-primary"  href="Favoritos.aspx?Id=<%#Eval("Id") %>">⭐</a> 
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
