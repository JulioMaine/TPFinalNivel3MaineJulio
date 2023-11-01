<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Favoritos.aspx.cs" Inherits="TiendaDeArticulos.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-1" style="width: 55px">
        </div>
        <div class="col-1">
            <h1 class="text-white">Favoritos</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-1" style="width: 45px">
        </div>
        <div class="row row-cols-1 row-cols-md-3 mt-1 g-5">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col gallery">
                        <div class="card border-black" style="width: 90%">
                            <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" style="max-width: 500px; max-height: 700px; object-fit: cover" onerror="this.src='https://www.mansor.com.uy/wp-content/uploads/2020/06/imagen-no-disponible2.jpg'" alt="...">
                            <div class="card-body bg-dark">
                                <h5 class="card-title text-white"><%#Eval("Nombre")%></h5>
                                <p class="card-text text-white"><%#Eval("Descripcion")%></p>
                                <a href="Detalle.aspx?Id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a>
                                <asp:Button ID="btnEliminarFav" OnClick="btnEliminarFav_Click" CommandArgument='<%#Eval("Id")%>' runat="server" Text="Eliminar" class="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
