<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BuscarExpedientes.aspx.cs" Inherits="BuscarExpedientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2> Buscador de Expedientes </h2>

    <table align="center" style="width: 445px" border="1">
        <tr>
            <td> Cliente :</td>
            <td><asp:TextBox ID="txtCliente" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Abogado :</td>
            <td><asp:TextBox ID="txtAbogado" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fecha de Inicio :</td>
            <td><asp:TextBox ID="txtFechaInicio" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" onclick="btnBuscar_Click" />&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100px" onclick="btnLimpiar_Click" />
            </td>
        </tr>
    </table>

    <br />

    <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
    <br />

    <div align="center">
        <asp:GridView ID="GridViewExpedientes" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSourceExpedientes" 
            EmptyDataText="No Se Encontraron Expedientes">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Caratula" HeaderText="Caratula" 
                    SortExpression="Caratula" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                    SortExpression="Descripcion" />
                <asp:BoundField DataField="FechaInicio" HeaderText="FechaInicio" 
                    SortExpression="FechaInicio" />
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
        <asp:ObjectDataSource ID="ObjectDataSourceExpedientes" runat="server" 
            DeleteMethod="eliminarExpediente" SelectMethod="traerExpedientes" 
            TypeName="BussinessLayer.Controller">
            <DeleteParameters>
                <asp:Parameter Name="pId" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </div>
    <br />

</asp:Content>

