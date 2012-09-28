<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Informes_Informes, App_Web_mfbv5olc" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Informes </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Width="100%">
        <asp:Label ID="lblFechaInferior" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblFechaSuperior" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblEstado" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    Informe de Consultas Segun Se Estado<br />
    <table align="center" style="width: 47%;">
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            </td>
            <td> &nbsp; </td>
        </tr>
        <tr>
            <td>
                Fecha Inferior :</td>
            <td>
                <asp:TextBox ID="txtFechaInferior" runat="server" Width="250px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaInferior_CalendarExtender" runat="server" 
                    Enabled="True" 
                    Format="dd/MM/yyyy"
                    TargetControlID="txtFechaInferior" />

            </td>
            <td>
                <asp:RequiredFieldValidator ID="qfvFechaInferior" runat="server" 
                    ControlToValidate="txtFechaInferior"
                    ForeColor="Red" 
                    ErrorMessage="*"
                    ToolTip="*"
                    Text="*">
                </asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>
                Fecha Superior :</td>
            <td>
                <asp:TextBox ID="txtFechaSuperior" runat="server" Width="250px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaSuperior_CalendarExtender" runat="server" 
                    Enabled="True" 
                    Format="dd/MM/yyyy"
                    TargetControlID="txtFechaSuperior" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvFechaSuperior" runat="server" 
                    ControlToValidate="txtFechaSuperior" 
                    ForeColor="Red"
                    ErrorMessage="*"
                    ToolTip="*"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                Ingrese El Estado de la Consulta</td>
            <td>
                <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqfvEstado" runat="server" 
                    ControlToValidate="txtEstado" 
                    ErrorMessage="*"
                    ForeColor="Red" 
                    ToolTip="*"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3"> &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnCargar" runat="server" Text="Cargar Informe" onclick="btnCargar_Click" />&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" Width="126px" />
            </td>
        </tr>
    </table>
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" 
        Width="100%" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        InteractiveDeviceInfos="(Colección)" 
        WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Informes\rptConsultasPorEstado.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSourceConsultasPorEstado" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSourceConsultasPorEstado" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        TypeName="dsConsultasPorEstadoTableAdapters.sp_ConsultasPorEstadoTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblFechaInferior" Name="Fecha1" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="lblFechaSuperior" Name="Fecha2" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="lblEstado" DefaultValue="1" Name="Estado" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>    

</asp:Content>