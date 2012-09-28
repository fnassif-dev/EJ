<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BuscarConsultas.aspx.cs" Inherits="BuscarConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Buscar Consultas</h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="False" 
        Width="100%">
        <asp:Label ID="lblCliente" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblAbogado" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblFecha" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />
    
    <table align="center" style="width: 445px" border="1">
        <tr>
            <td> Cliente :</td>
            <td><asp:TextBox ID="txtBuscarCliente" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Abogado :</td>
            <td><asp:TextBox ID="txtBuscarAbogado" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Fecha :</td>
            <td><asp:TextBox ID="txtBuscarFecha" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" Height="30px" onclick="btnBuscar_Click" />&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100px" Height="30px" onclick="btnLimpiar_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />

    <asp:Panel ID="PanelOpciones" runat="server" Visible="false">
        <asp:LinkButton ID="lnkModificarConsulta" runat="server" 
            onclick="lnkModificarConsulta_Click"> Modificar Consulta </asp:LinkButton>&nbsp; | &nbsp;
        <asp:LinkButton ID="lnkIniciarExpediente" runat="server" 
            onclick="lnkIniciarExpediente_Click" > Iniciar Expediente </asp:LinkButton>
    </asp:Panel>

    <br />
    <div align="center" style="overflow: auto">
        <asp:GridView ID="GridViewConsultas" runat="server" 
            AutoGenerateColumns="False" 
            CellPadding="4" 
            ForeColor="#333333" 
            GridLines="None" 
            EmptyDataText="No Se Encontraron Consultas"
            EmptyDataRowStyle-HorizontalAlign="Center"
            RowStyle-HorizontalAlign="Center"
            onrowdeleted="GridViewConsultas_RowDeleted" 
            onrowdeleting="GridViewConsultas_RowDeleting" 
            onselectedindexchanged="GridViewConsultas_SelectedIndexChanged" 
            AllowPaging="True" PageSize="15">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                    SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                    DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                    <ItemTemplate>
                        <asp:Label ID="Cliente" runat="server" Text='<%# Eval("Cliente.ApellidoNombre") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Abogado" SortExpression="Abogado">
                    <ItemTemplate>
                        <asp:Label ID="Abogado" runat="server" Text='<%# Eval("Abogado.ApellidoNombre") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TemaConsulta" SortExpression="TemaConsulta">
                    <ItemTemplate>
                        <asp:Label ID="TemaConsulta" runat="server" Text='<%# Eval("TemaConsulta.Descripcion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceConsultas" runat="server" 
            DeleteMethod="eliminarConsulta" 
            SelectMethod="buscarConsultas" 
            TypeName="BussinessLayer.Controller">
            <DeleteParameters>
                <asp:Parameter Name="pId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lblCliente" Name="pCliente" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblAbogado" Name="pAbogado" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblFecha" Name="pFecha" PropertyName="Text" Type="DateTime" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />

    </div>
</asp:Content>