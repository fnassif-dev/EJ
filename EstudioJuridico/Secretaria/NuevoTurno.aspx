<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NuevoTurno.aspx.cs" Inherits="Secretaria_NuevoTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Asignar Nuevos Turnos </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="False" 
        Width="100%">
        <asp:Label ID="lblNombre" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblApellido" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblDocumento" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
    <table align="center" style="width: 61%;">
        <tr>
            <td colspan="4"><b><em> Datos Personales Del Cliente </em></b></td>
        </tr>
        <tr>
            <td>Apellido :</td>
            <td><asp:TextBox ID="txtApellido" runat="server" Enabled="false" Width="170px"></asp:TextBox></td>
            <td>Nombre :</td>
            <td><asp:TextBox ID="txtNombre" runat="server" Enabled="false" Width="170px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Documento :</td>
            <td><asp:TextBox ID="txtDocumento" runat="server" Enabled="false" Width="170px"></asp:TextBox></td>
            <td>Fecha de Nacimiento :</td>
            <td><asp:TextBox ID="txtNacimiento" runat="server" Enabled="false" Width="170px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4"><b><em> Datos Del Turno </em></b></td>
        </tr>
        <tr>
            <td colspan="2">Seleccionar Abogado :</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlAbogados" runat="server" 
                    DataSourceID="ObjectDataSourceAbogados" 
                    DataTextField="ApellidoNombre" 
                    DataValueField="Id" Height="23px" Width="239px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSourceAbogados" runat="server"
                    TypeName="BussinessLayer.Controller"
                    SelectMethod="buscarAbogados" 
                    OldValuesParameterFormatString="original_{0}">            
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblNombre" Name="pNombre" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblApellido" Name="pApellido" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblDocumento" Name="pDocumento" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2"><span >Descripcion del Requiriente :</span><br />
                <br />
                <span style="font-style: italic">
                    Se debe cargar una breve descripcion<br />
                    del motivo de la visita del cliente
                </span>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtDescripcion" runat="server" Height="93px" TextMode="MultiLine" Width="313px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnAceptar" runat="server" Text="Cargar" Width="100px" Height="30px" onclick="btnAceptar_Click" />&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100px" Height="30px" onclick="btnLimpiar_Click" />
            </td>
        </tr>
    </table>
    <br />

</asp:Content>