<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NuevoAbogado.aspx.cs" Inherits="NuevoAbogado" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2> Nuevo Abogado </h2> 
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="False" 
        Width="100%">
        <asp:Label ID="lblIdAbogado" runat="server" Visible="False"></asp:Label>
        &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </asp:Panel>
    <br />
    
    <table align="center" style="width: 53%; height: 56px;">
        <tr>
            <td> Nombre : </td>
            <td><asp:TextBox ID="txtNombre" runat="server" Width="236px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rqfvNombre" runat="server" 
                    ErrorMessage="El Nombre es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtNombre" 
                    ToolTip="El Apellido es requerido"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Apellido : </td>
            <td><asp:TextBox ID="txtApellido" runat="server" Width="236px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rqfvApellido" runat="server" 
                    ErrorMessage="El Apellido es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtApellido" 
                    ToolTip="El Apellido es requerido"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Tipo Documento : </td>
            <td>
                <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="230px" 
                    DataSourceID="SqlDataSourceTipoDocumento" 
                    DataTextField="Descripcion" 
                    DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceTipoDocumento" runat="server" 
                    ConnectionString="Data Source=TURCO-PC\SQLEXPRESS;Initial Catalog=EstudioJuridico;User ID=Turco;Password=31020252" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Id], [Descripcion] FROM [TipoDocumento]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td> Documento : </td>
            <td><asp:TextBox ID="txtDocumento" runat="server" Width="236px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rqfvDocumento" runat="server" 
                    ErrorMessage="El Documento es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtDocumento" 
                    ToolTip="El Documento es requerido"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Fecha de Nacimiento :</td>
            <td><asp:TextBox ID="txtFechaNacimiento" runat="server"  Width="236px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaNacimiento_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtFechaNacimiento">
                </asp:CalendarExtender>
                &nbsp;
                <asp:RequiredFieldValidator ID="rqfvFechaNacimiento" runat="server" 
                    ErrorMessage="La Fecha de Nacimiento es Requerida" 
                    ForeColor="Red" 
                    ControlToValidate="txtFechaNacimiento" 
                    ToolTip="La Fecha de Nacimiento es Requerida"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Estado Civil :</td>
            <td>
                <asp:DropDownList ID="ddlEstadoCivil" runat="server" Width="230px" 
                    DataSourceID="SqlDataSourceEstadoCivil" 
                    DataTextField="Descripcion" 
                    DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceEstadoCivil" runat="server" 
                    ConnectionString="Data Source=TURCO-PC\SQLEXPRESS;Initial Catalog=EstudioJuridico;User ID=Turco;Password=31020252" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Id], [Descripcion] FROM [EstadoCivil]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td> Provincia : </td>
            <td>
                <asp:DropDownList ID="ddlProvincias" runat="server" 
                    Width="230px"  
                    DataSourceID="SqlDataSourceProvincias" 
                    DataTextField="Descripcion" 
                    DataValueField="Id"
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceProvincias" runat="server" 
                    ConnectionString="Data Source=TURCO-PC\SQLEXPRESS;Initial Catalog=EstudioJuridico;User ID=Turco;Password=31020252" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Id], [Descripcion] FROM [Provincias]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td> Ciudad : </td>
            <td>
                <asp:DropDownList ID="ddlCiudades" runat="server" Width="230px" 
                    DataSourceID="SqlDataSourceCiudades" 
                    DataTextField="Descripcion" 
                    DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceCiudades" runat="server" 
                    ConnectionString="Data Source=TURCO-PC\SQLEXPRESS;Initial Catalog=EstudioJuridico;User ID=Turco;Password=31020252" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Id], [Descripcion], [Provincia] FROM [Ciudades] WHERE ([Provincia]=@ProvinciaId)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlProvincias" DefaultValue="1" Name="ProvinciaId"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td> Dirección : </td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server" Width="236px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rqfvDireccion" runat="server" 
                    ErrorMessage="La Dirección es requerida" 
                    ForeColor="Red" 
                    ControlToValidate="txtDireccion" 
                    ToolTip="La Dirección es requerida"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Telefono : </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" Width="236px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rqfvTelefono" runat="server" 
                    ErrorMessage="El Telefono es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtTelefono" 
                    ToolTip="El Domicilio es requerido"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Celular : </td>
            <td>
                <asp:TextBox ID="txtCelular" runat="server" Width="236px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rqfvCelular" runat="server" 
                    ErrorMessage="El Celular es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtCelular" 
                    ToolTip="El Domicilio es requerido"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2"> 
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" />
            </td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <br />

</asp:Content>