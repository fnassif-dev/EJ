<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Estadisticas_Estadisticas, App_Web_0uu0qewh" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 103px;
        }
        .style2
        {
            width: 287px;
        }
        .style3
        {
            width: 257px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblFechaInferior" runat="server" Visible="false" ></asp:Label>&nbsp;
                <asp:Label ID="lblFechaSuperior" runat="server" Visible="false" ></asp:Label>&nbsp;
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table style="width: 64%;">
                    <tr>
                        <td colspan="4"><em><strong>Selecciones el Tipo de Informe que desea realizar :</strong></em></td>
                    </tr>
                    <tr>
                        <td colspan="4"> &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="style1"> &nbsp;</td>
                        <td style="text-align: center" class="style3"> Indicar El Rango de Fechas :</td>
                        <td style="text-align: center" class="style2"> 
                            Fecha Inferior :&nbsp;
                            <asp:TextBox ID="txtFechaInferior" runat="server" ontextchanged="txtFechaInferior_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="txtFechaInferior_CalendarExtender" runat="server" 
                                Enabled="True" 
                                TargetControlID="txtFechaInferior" 
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            <br />
                            Fecha Superior :&nbsp;
                            <asp:TextBox ID="txtFechaSuperior" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtFechaSuperior_CalendarExtender" runat="server" 
                                Enabled="True" 
                                TargetControlID="txtFechaSuperior"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                        <td style="text-align: center"> 
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4"> &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" colspan="2"> Consultas Atendidas Por Abogado :</td>
                        <td style="text-align: left" colspan="2">
                            <asp:RadioButton ID="rbtConsultasPorAbogados" runat="server" GroupName="Busqueda" Text="Seleccionar" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" colspan="2"> Expedientes Iniciados Por Abogado :</td>
                        <td style="text-align: left" colspan="2">
                            <asp:RadioButton ID="rbtExpedientesPorAbogados" runat="server" GroupName="Busqueda" Text="Seleccionar" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" colspan="2"> Clientes Atendidos y Ausentes </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RadioButton ID="rbtClientesAtendidosAusentes" runat="server" GroupName="Busqueda" Text="Seleccionar" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" colspan="2"> Consultas Segun Su Motivo :</td>
                        <td style="text-align: left" colspan="2">
                            <asp:RadioButton ID="rbtConsultasSegunMotivo" runat="server" GroupName="Busqueda" 
                                Text="Seleccionar" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" colspan="2"> Expedientes Cerrados Por Juzgado :</td>
                        <td style="text-align: left" colspan="2">
                            <asp:RadioButton ID="rbtExpedientesCerradosPorJuzgado" runat="server" GroupName="Busqueda" Text="Seleccionar" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" colspan="2"> &nbsp;</td>
                        <td style="text-align: left" colspan="2"> &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: right"> &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnReporte" runat="server" Text="Crear Informe" Width="120px" OnClick="btnReporte_Click" />&nbsp;                            
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Estadisticas\rdtConsultasPorAbogado.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSourceConsultasPorAbogado" Name="DataSet1" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSourceExpedientesPorAbogado" Name="ExpedientesPorAbogado" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <asp:ObjectDataSource ID="ObjectDataSourceConsultasPorAbogado" runat="server" 
        OldValuesParameterFormatString="original_{0}"        
        TypeName="dsConsultasPorAbogadoTableAdapters.sp_ConsultasPorAbogadoTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblFechaInferior" Name="Fecha1" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="lblFechaSuperior" Name="Fecha2" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceExpedientesPorAbogado" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        TypeName="dsExpedientesPorAbogadoTableAdapters.sp_ExpedientesPorAbogadoTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblFechaInferior" Name="Fecha1" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="lblFechaSuperior" Name="Fecha2" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceClientesAusentesAtendidos" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        TypeName="dsClientesAusentesAtendidosTableAdapters.sp_ClientesAusentesAtendidosTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblFechaInferior" Name="Fecha1" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="lblFechaSuperior" Name="Fecha2" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceConsultasSegunMotivo" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        TypeName="dsConsultasSegunMotivoTableAdapters.sp_ConsultasSegunMotivoTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblFechaInferior" Name="Fecha1" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="lblFechaSuperior" Name="Fecha2" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceExpedientesCerradosPorJuzgado" 
        runat="server" OldValuesParameterFormatString="original_{0}" 
        TypeName="dsExpedientesCerradosPorJuzgadoTableAdapters.sp_ExpedientesCerradosPorJuzgadoTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblFechaInferior" Name="Fecha1" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="lblFechaSuperior" Name="Fecha2" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>    

</asp:Content>