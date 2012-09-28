<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Escritos.aspx.cs" Inherits="Abogado_Escritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Agregar Escritos Al Expediente </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Width="100%">
        <asp:Label ID="lblConsulta" runat="server" Visible="False"></asp:Label>
        &nbsp;<asp:Label ID="lblExpediente" runat="server" Visible="False"></asp:Label>
        &nbsp;<asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />
    <table align="center" style="width: 69%;">
        <tr>
            <td colspan="4"><b> Datos Del Expediente </b></td>
        </tr>
        <tr>
            <td> Juzgado :</td>
            <td><asp:TextBox ID="txtJuzgado" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
            <td> Secretaria : </td>
            <td><asp:TextBox ID="txtSecretaria" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Fecha Inicio :</td>
            <td><asp:TextBox ID="txtFechaInicio" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td> Caratula : </td>
            <td colspan="3"><asp:TextBox ID="txtCaratula" runat="server" Width="644px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Descripcion : </td>
            <td colspan="3"><asp:TextBox ID="txtDescripcion" runat="server" Width="644px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Actores :</td>
            <td colspan="3"><asp:TextBox ID="txtActores" runat="server" Width="644px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4"><asp:LinkButton ID="lnkCmabiarExpediente" runat="server" > Cambiar Expediente </asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4"><b> Escritos </b></td>
        </tr>
        <tr>
            <td colspan="2" style="font-style: italic"><span> Datos del Escritos el Expediente : </span><br />
                <br />
                Aqui se debe ingresar una breve descripcion del escrito<br />
                asociado el expediente.-
            </td>
            <td colspan="2"><asp:TextBox ID="txtEscrito" runat="server" Height="119px" TextMode="MultiLine" Width="341px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td colspan="4"><asp:CheckBox ID="chkCerrarExpediente" runat="server" Text="Cerrar Expediente" /></td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnCargar" runat="server" onclick="btnCargar_Click" Text="Cargar" Width="100px" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" Text="Cancelar" Width="100px" />
            </td>
        </tr>
    </table>
    <br />

</asp:Content>