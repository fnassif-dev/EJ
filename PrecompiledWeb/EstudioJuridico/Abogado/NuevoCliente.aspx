<%@ page title="Prueba de ABM Cliente" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Clientes, App_Web_rupjzldv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2> Nuevo Cliente </h2>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="False" 
        Width="100%">
        <asp:Label ID="lblIdCliente" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br /> 
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <br />
    
    <table align="center" style="width: 53%; height: 56px;" border="1">
        <tr>
            <td> Nombre :</td>
            <td><asp:TextBox ID="txtNombre" runat="server" Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator 
                    ID="rqfvNombre" runat="server" 
                    ErrorMessage="El Nombre es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtNombre"
                    Text="*" 
                    ToolTip="El Apellido es requerido">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Apellido :</td>
            <td><asp:TextBox ID="txtApellido" runat="server" Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvNombre0" runat="server" 
                    ErrorMessage="El Apellido es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtApellido" 
                    Text="*"
                    ToolTip="El Apellido es requerido">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Tipo Documento :</td>
            <td>
                <asp:DropDownList ID="ddlTipoDocumento" runat="server" 
                    Width="230px" 
                    DataSourceID="SqlDataSourceTipoDoc" 
                    DataTextField="Descripcion" 
                    DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceTipoDoc" runat="server" 
                    ConnectionString="Data Source=TURCO-PC\SQLEXPRESS;Initial Catalog=EstudioJuridico;User ID=Turco;Password=31020252" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Id], [Descripcion] FROM [TipoDocumento]">
                </asp:SqlDataSource>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td> Documento :</td>
            <td><asp:TextBox ID="txtDocumento" runat="server" Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvDocumento" runat="server" 
                    ErrorMessage="El Documento es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtDocumento"
                    Text="*" 
                    ToolTip="El Documento es requerido">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Fecha de Nacimiento :</td>
            <td><asp:TextBox ID="txtFechaNacimiento" runat="server"  Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvFechaNacimeiento" runat="server" 
                    ErrorMessage="La Fecha de Nacimiento es requerida" 
                    ForeColor="Red"
                    Text="*" 
                    ControlToValidate="txtFechaNacimiento"
                    ToolTip="La Fecha de Nacimiento es requerida" 
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revFechaNacimiento" runat="server" 
                    ErrorMessage="La Fecha no tiene el formato correcto" 
                    ForeColor="Red"
                    Text="*" 
                    ToolTip="La Fecha no tiene el formato correcto" 
                    ControlToValidate="txtFechaNacimiento" 
                    ValidationExpression="\d{2}/\d{2}/\d{4}" 
                    Display="Dynamic">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td> Estado Civil :</td>
            <td>
                <asp:DropDownList ID="ddlEstadoCivil" runat="server" 
                    Width="230px" 
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
            <td>
            </td>
        </tr>
        <tr>
            <td> Ocupacion :</td>
            <td><asp:TextBox ID="txtOcupacion" runat="server" Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvOcupacion" runat="server" 
                    ErrorMessage="La Ocupacion es requerida" 
                    ForeColor="Red" 
                    ControlToValidate="txtOcupacion"
                    Text="*"
                    ToolTip="La Ocupacion es requerida">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Sexo :</td>
            <td>
                <asp:RadioButton ID="rdtMasculino" runat="server" Checked="True" GroupName="Sexo" Text="Masculino" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdtFemenino" runat="server" GroupName="Sexo" Text="Femenino" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td> Nacionalidad :</td>
            <td><asp:TextBox ID="txtNacionalidad" runat="server" Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvNacionalidad" runat="server" 
                    ErrorMessage="La Nacionalidad es requerida" 
                    ForeColor="Red" 
                    ControlToValidate="txtNacionalidad" 
                    Text="*"
                    ToolTip="La Nacionalidad es requerida">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Provincia :</td>
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
            <td>
            </td>
        </tr>
        <tr>
            <td class="style1"> Ciudad :</td>
            <td class="style1">
                <asp:DropDownList ID="ddlCiudades" runat="server" 
                    Width="230px" 
                    DataSourceID="SqlDataSourceCiudades" 
                    DataTextField="Descripcion" 
                    DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceCiudades" runat="server" 
                    ConnectionString="Data Source=TURCO-PC\SQLEXPRESS;Initial Catalog=EstudioJuridico;User ID=Turco;Password=31020252" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Id], [Descripcion], [Provincia] FROM [Ciudades] WHERE ([Provincia] = @ProvinciaId)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlProvincias" DefaultValue="1" Name="ProvinciaId"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="style1">
            </td>
        </tr>
        <tr>
            <td> Dirección :</td>
            <td><asp:TextBox ID="txtDireccion" runat="server" Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvDireccion" runat="server" 
                    ErrorMessage="La Dirección es requerida" 
                    ForeColor="Red" 
                    ControlToValidate="txtDireccion" 
                    Text="*"
                    ToolTip="La Dirección es requerida">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Telefono :</td>
            <td><asp:TextBox ID="txtTelefono" runat="server" Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvTelefono" runat="server" 
                    ErrorMessage="El Telefono es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtTelefono" 
                    Text="*"
                    ToolTip="El Domicilio es requerido">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Celular :</td>
            <td><asp:TextBox ID="txtCelular" runat="server" Width="236px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvCelular" runat="server" 
                    ErrorMessage="El Celular es requerido" 
                    ForeColor="Red" 
                    ControlToValidate="txtCelular" 
                    Text="*"
                    ToolTip="El Domicilio es requerido">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Observaciones :</td>
            <td><asp:TextBox ID="txtObservaciones" runat="server" Height="70px" TextMode="MultiLine" Width="246px"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" />
            </td>
        </tr>
    </table>
    
<br />
    
</asp:Content>