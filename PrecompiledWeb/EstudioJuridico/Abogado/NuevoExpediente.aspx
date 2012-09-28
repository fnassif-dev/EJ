<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Abogado_NuevoExpediente, App_Web_kxlmikau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Inicio de Expediente </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Width="100%">
        <asp:Label ID="lblConsultaId" runat="server" Visible="false"></asp:Label>&nbsp;
        <asp:Label ID="lblExpedienteId" runat="server" Visible="false"></asp:Label>&nbsp;        
        <asp:Label ID="lblJuzgadoId" runat="server" Visible="false"></asp:Label>&nbsp;
        <asp:Label ID="lblClienteId" runat="server" Visible="false"></asp:Label>&nbsp;
        <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
    </asp:Panel>
    <br />
    <table align="center" style="width: 845px; height: 73px">
         <tr>
            <td colspan="4"><b> Datos de la Consulta </b></td>
        </tr>
        <tr>
            <td> Cliente :</td>
            <td><asp:TextBox ID="txtNombreCliente" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
            <td> Fecha :</td>
            <td><asp:TextBox ID="txtFechaConsulta" runat="server" Width="229px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Abogado : </td>
            <td><asp:TextBox ID="txtAbogadoConsulta" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
            <td> Tema de Consulta : </td>
            <td><asp:TextBox ID="txtTemaConsulta" runat="server" Width="229px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Descripcion :</td>
            <td colspan="3"><asp:TextBox ID="txtDescripcionConsulta" runat="server" Height="50px" TextMode="MultiLine" Width="685px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4"><asp:LinkButton ID="lnkCambiarConsulta" runat="server" onclick="lnkCambiarConsulta_Click"> Cambiar Consulta </asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="4"> &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4"><b> Datos del Nuevo Expediente </b></td>
        </tr>
        <tr>
            <td>Juzgado :</td>
            <td>
                <asp:DropDownList ID="ddlJuzgados" runat="server" 
                    Width="245px"
                    DataSourceID="ObjectDataSourceJuzgados" 
                    DataTextField="Nombre" 
                    DataValueField="Id" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSourceJuzgados" runat="server" 
                    SelectMethod="traerJuzgados" 
                    TypeName="BussinessLayer.Controller">
                </asp:ObjectDataSource>
            </td>
            <td>Secretaria :</td>
            <td>
                <asp:DropDownList ID="ddlSecretarias" runat="server" 
                    Width="245px"
                    DataSourceID="ObjectDataSourceSecretarias" 
                    DataTextField="Nombre" 
                    DataValueField="Id">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSourceSecretarias" runat="server" 
                    SelectMethod="traerSecretarias" 
                    TypeName="BussinessLayer.Controller">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlJuzgados" Name="pJuzgado" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>Caratula :</td>
            <td colspan="3"><asp:TextBox ID="txtCaratula" runat="server" Height="22px" Width="691px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Actores :</td>
            <td colspan="3"><asp:TextBox ID="txtActores" runat="server" Height="40px" TextMode="MultiLine" Width="691px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Descripcion :</td>
            <td colspan="3">
                <asp:TextBox ID="txtDescripcionExpediente" runat="server" Height="40px" 
                    TextMode="MultiLine" Width="691px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>Fecha Inicio :</td>
            <td><asp:TextBox ID="txtFechaInicio" runat="server" Enabled="False" Width="258px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnCargar" runat="server" Text="Cargar" Width="100px" Height="30px" onclick="btnCargar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="100px" Height="30px" onclick="btnCancelar_Click" />
            </td>
        </tr>
        </table>
    <br />

</asp:Content>