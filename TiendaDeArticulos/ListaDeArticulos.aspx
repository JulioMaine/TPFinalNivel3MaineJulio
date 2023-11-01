<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaDeArticulos.aspx.cs" Inherits="TiendaDeArticulos.ListaDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scripMangaerListaArticulos">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanelListaArticulo">
        <ContentTemplate>
            <h1 class="text-white">Lista de Articulos</h1>
            <div class="row">
                <div class="col-4">
                    <div>
                        <asp:Label ID="Label1" runat="server" CssClass="fs-6 h1 font-weight-bold text-white" Text="Buscar por Nombre:"></asp:Label>
                        <asp:Label Text="(Apretar enter para buscar)" runat="server" CssClass="text-white" style="font-size: 15px;" />
                    </div>
                    <div class="d-inline">
                        <asp:TextBox ID="txtFiltroRapido" CssClass="form-control bg-dark text-white" OnTextChanged="txtFiltroRapido_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-2" style="display: flex; flex-direction: column; justify-content: end">
                    <asp:CheckBox ID="ckbFiltroAvanzado" CssClass="form-check-inline text-white" OnCheckedChanged="ckbFiltroAvanzado_CheckedChanged" AutoPostBack="true" Text="Filtro avanzado" runat="server" />
                </div>
                <div class="col-1" style="width: 25px">
                </div>
            </div>


            <% if (FiltroAvanzado)
                { %>
            <div class="row mt-3">
                <div class="col-3">
                    <asp:Label ID="Label2" CssClass="fs-6 h1 font-weight-bold  text-white" runat="server" Text="1- Elige un Campo:"></asp:Label>
                    <asp:DropDownList ID="ddlCampo" CssClass="form-control bg-dark text-white" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Descripción" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label3" CssClass="fs-6 h1 font-weight-bold  text-white" runat="server" Text="2- Elige un Criterio:"></asp:Label>
                    <asp:DropDownList ID="ddlCriterio"  CssClass="form-control bg-dark text-white" runat="server"></asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label4" CssClass="fs-6 h1 font-weight-bold  text-white" runat="server" Text="3- Introduce el Filtro:"></asp:Label>
                    <asp:TextBox ID="txtbFiltroAvanzado" CssClass="form-control bg-dark text-white" runat="server"></asp:TextBox>
                </div>
                <div class="col-3">
                    <br />
                    <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" CssClass="btn btn-primary" Text="Buscar 🔍" />
                </div>
            </div>
            <% } %>




            <asp:GridView ID="dgvArticulos" runat="server" CssClass="table mt-3 table-dark" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AutoGenerateColumns="false"
              OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍️" />
                </Columns>
            </asp:GridView>
            <a href="AltaArticulo.aspx" class="btn btn-primary">Agregar Artículo</a>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
