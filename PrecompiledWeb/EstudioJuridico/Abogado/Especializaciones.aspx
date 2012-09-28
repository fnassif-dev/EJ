<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Especializaciones, App_Web_kxlmikau" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Agregar Especializaciones de Abogados </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Width="100%">
        <asp:Label ID="lblAbogadoId" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </asp:Panel>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />   

    <table align="center" style="width: 68%;">
        <tr>
            <td colspan="4"><b> Datos Personales del Abogado</b></td>
        </tr>
        <tr>
            <td> Nombre :</td>
            <td><asp:TextBox ID="txtNombreAbogado" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
            <td> Documento :</td>
            <td><asp:TextBox ID="txtDocumentoAbogado" runat="server" Width="200px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Direccion :</td>
            <td><asp:TextBox ID="txtDireccionAbogado" runat="server" Width="280px" Enabled="false"></asp:TextBox></td>
            <td> Telefono :</td>
            <td><asp:TextBox ID="txtTelefonoAbogado" runat="server" Width="200px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4"> 
                <asp:LinkButton ID="lnkAbogado" runat="server" onclick="lnkAbogado_Click">Cambiar Abogado</asp:LinkButton>
            </td>
        </tr>
        <tr><td colspan="4" class="style1"></td></tr>
        <tr>
            <td colspan="4"><b> Datos de la Especializacion del Abogado </b></td>
        </tr>
        <tr>
            <td colspan="2"> Descripcion Especializacion :<br />
                <br />
                <i>(Se debe cargar una breve descripcion de la Especializacion<br />realizada con el abogado seleccionado)</i>
            </td>
            <td colspan="2"> 
                <asp:TextBox ID="txtDescripcion" runat="server" Height="91px" TextMode="MultiLine" Width="318px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2"> Fecha en que lo realizo :</td>
            <td colspan="2"> 
                <asp:TextBox ID="txtFecha" runat="server" Height="22px" Width="240px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtFecha">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnCargar" runat="server" Width="100px" Text="Cargar" onclick="btnCargar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Width="100px" Text="Cancelar" onclick="btnCancelar_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:LinkButton ID="lnkVerEspecializaciones" runat="server" 
        onclick="lnkVerEspecializaciones_Click"> Ver Las Especializaciones del Abogado </asp:LinkButton>
    <br />
    <br />
    <div align="center">
        <asp:GridView ID="GridViewEspecializaciones" runat="server" 
            AutoGenerateColumns="False" 
            CellPadding="4"  
            ForeColor="#333333" 
            GridLines="None" Width="917px" AllowPaging="True" PageSize="20">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                    SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                    DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
                <asp:TemplateField HeaderText="Abogado" SortExpression="Abogado">
                    <ItemTemplate>
                        <asp:Label ID="lblAbogado" runat="server" Text='<%# Eval("Abogado.ApellidoNombre")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
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
        <asp:ObjectDataSource ID="ObjectDataSourceEspecializaciones" runat="server" 
            TypeName="BussinessLayer.Controller"
            SelectMethod="buscarEspecializaciones" >
            <SelectParameters>
                <asp:ControlParameter ControlID="lblAbogadoId" Name="pId" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>        
    </div>

</asp:Content>