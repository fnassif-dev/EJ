<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VerEscritos.aspx.cs" Inherits="Abogado_VerEscritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Agregar Escritos Al Expediente </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="False" 
        Width="100%">
        <asp:Label ID="lblExpedienteId" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />

    <table style="width:58%;" align="center">
        <tr>
            <td colspan="4"><b><em> Escritos Correspondientes al Expediente </em></b></td>
        </tr>
        <tr>
            <td> Numero :</td>
            <td><asp:TextBox ID="txtNumeroExpediente" runat="server" Width="192px" Enabled="False"></asp:TextBox></td>
            <td> Fecha :</td>
            <td><asp:TextBox ID="txtFechaInicio" runat="server" Width="192px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Caratula :</td>
            <td colspan="3"><asp:TextBox ID="txtCaratula" runat="server" Width="527px" Enabled="False" Height="22px"></asp:TextBox></td>
        </tr>
    </table>

    <br />
    <br />
    <div align="center">
        <b><em> Escritos Del Expediente </em></b>
        <br />
        <br />
        <asp:GridView ID="GridViewEscritos" runat="server" 
            CellPadding="4" 
            DataSourceID="ObjectDataSourceEscritos" 
            ForeColor="#333333" 
            GridLines="None" 
            AutoGenerateColumns="False" 
            Width="822px" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                    SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                    DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
                <asp:BoundField DataField="Expediente" HeaderText="Expediente" SortExpression="Expediente" Visible="false" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
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
        <asp:ObjectDataSource ID="ObjectDataSourceEscritos" runat="server" 
            SelectMethod="traerEscritos" 
            TypeName="BussinessLayer.Controller">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblExpedienteId" Name="pId" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <br />    

</asp:Content>