<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InformesListados.aspx.cs" Inherits="Informes_InformePrueba" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblNombre" runat="server" ></asp:Label>&nbsp;
                <asp:Label ID="lblApellido" runat="server" ></asp:Label>&nbsp;
                <asp:Label ID="lblDocumento" runat="server" ></asp:Label>&nbsp;
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table style="width: 51%;">
                    <tr>
                        <td colspan="2"> <em><strong>Selecciones el Tipo de Informe que desea realizar :</strong></em></td>
                    </tr>
                    <tr>
                        <td colspan="2"> &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="style1"> Listado de Abogados :</td>
                        <td style="text-align: left"><asp:RadioButton ID="rbtAbogados" runat="server" GroupName="Busqueda" Text="Seleccionar" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right"> Listado de Clientes :</td>
                        <td style="text-align: left"><asp:RadioButton ID="rbtClientes" runat="server" GroupName="Busqueda" Text="Seleccionar" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right"> Listado de Expedientes Cerrados :</td>
                        <td style="text-align: left"><asp:RadioButton ID="rbtExpedientesCerrados" runat="server" GroupName="Busqueda" Text="Seleccionar" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right"> &nbsp;</td>
                        <td style="text-align: left"> &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right"> &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnReporte" runat="server" Text="Crear Informe" Width="120px" OnClick="btnReporte_Click" />&nbsp;                            
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="120px" OnClick="btnLimpiar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" 
                    Font-Names="Verdana" 
                    Font-Size="8pt" 
                    InteractiveDeviceInfos="(Colección)" 
                    WaitMessageFont-Names="Verdana" 
                    WaitMessageFont-Size="14pt" 
                    Width="100%" 
                    ShowRefreshButton="False">
                    <LocalReport ReportPath="Informes\Report.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSourceAbogados" Name="BuscarAbogados" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSourceClientes" Name="BuscarClientes" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSourceExpedientesCerrados" Name="BuscarExpedientesCerrados" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSourceAbogados" runat="server" 
                    TypeName="dsAbogadosTableAdapters.sp_TraerAbogadosTableAdapter" 
                    OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSourceClientes" runat="server" 
                    TypeName="dsClientesTableAdapters.sp_TraerClientesTableAdapter" 
                    OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSourceExpedientesCerrados" runat="server"                    
                    TypeName="dsExpedientesCerradosTableAdapters.sp_TraerExpedientesCerradosTableAdapter" 
                    OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager></td>
        </tr>
    </table>


</asp:Content>