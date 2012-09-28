<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NuevaConsulta.aspx.cs" Inherits="NuevaConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Nueva Consulta </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Width="100%">
        <asp:Label ID="lblClienteId" runat="server" Visible="False"></asp:Label>
        &nbsp;<asp:Label ID="lblConsultaId" runat="server" Visible="False"></asp:Label>
        &nbsp;<asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />
    <table align="center" style="width: 66%;">
        <tr>
            <td colspan="4"><b> Datos Personales Cliente </b></td>
        </tr>
        <tr>
            <td> Nombre :</td>
            <td><asp:TextBox ID="txtNombreCliente" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
            <td> Fecha Nacimiento :</td>
            <td><asp:TextBox ID="txtNacimientoCliente" runat="server" Width="200px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td> Direccion : </td>
            <td><asp:TextBox ID="txtDireccioncliente" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
            <td> Telefono : </td>
            <td><asp:TextBox ID="txtTelefonoCliente" runat="server" Width="200px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:LinkButton ID="lnkCliente" runat="server" onclick="lnkCliente_Click">Cambiar Cliente</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4"><b> Datos de la Consulta </b></td>
        </tr>
        <tr>
            <td> Tema Consulta :</td>
            <td> 
                <asp:DropDownList ID="ddlTemaConsulta" runat="server" 
                    Width="150px"
                    DataSourceID="SqlDataSourceTemaConsulta" 
                    DataTextField="Descripcion" 
                    DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceTemaConsulta" runat="server" 
                    ConnectionString="Data Source=TURCO-PC\SQLEXPRESS;Initial Catalog=EstudioJuridico;User ID=Turco;Password=31020252" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Id], [Descripcion] FROM [TemasConsulta]">
                </asp:SqlDataSource>
            </td>
            <td> Estado :</td>
            <td> 
                <asp:DropDownList ID="ddlEstado" runat="server" Width="150px">
                    <asp:ListItem>Estado 1</asp:ListItem>
                    <asp:ListItem>Estado 2</asp:ListItem>
                    <asp:ListItem>Estado 3</asp:ListItem>
                    <asp:ListItem>Estado 4</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td> Descripcion :</td>
            <td> 
                <asp:TextBox ID="txtDescripcion" runat="server" Height="142px" TextMode="MultiLine" Width="270px"></asp:TextBox>
            </td>
            <td colspan="2"> 
                <em>Ingresar en este campo una breve
                <br />
                descripcion de la consulta.</em>
            </td>
        </tr>
        <tr>
            <td colspan="4"> 
                <asp:CheckBox ID="chkGenerarExpediente" runat="server" Text="Generar Expediente" />
            </td>
        </tr>
        <tr>
            <td colspan="4"> 
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Width="100px" Height="30px" onclick="btnAceptar_Click"/>&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="100px" Height="30px" onclick="btnCancelar_Click"/>
            </td>
        </tr>
        </table>
    <br />
    <br />

</asp:Content>