<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdministrarJuzgados.aspx.cs" Inherits="AdministrarJuzgados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Administracion de Juzgados y Secretarías </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="True" 
        Width="100%">
        <asp:Label ID="lblJuzgadoId" runat="server" Visible="False" Text="0"></asp:Label>&nbsp;
        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />
    Esta Pagina le Permite Administrar los Juzgados y las Secretarías que se utilizaran en el sistema<br />

    <br />
    <table align="center" style="width: 79%;">
        <tr>
            <td><b> Juzgados </b></td>
            <td><b> Secretarías </b></td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td> Nombre :</td>
                        <td><asp:TextBox ID="txtNombreJuzgado" runat="server" Width="280px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> Juez :</td>
                        <td><asp:TextBox ID="txtJuez" runat="server" Width="280px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> Direccion :</td>
                        <td><asp:TextBox ID="txtDireccion" runat="server" Width="280px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> Telefono :</td>
                        <td><asp:TextBox ID="txtTelefono" runat="server" Width="280px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"> 
                            <asp:Button ID="btnCargarJuzgado" runat="server" Text="Cargar" Width="100px" Height="30px" onclick="btnCargarJuzgado_Click" />&nbsp;
                            <asp:Button ID="btnLimpiarJuzgado" runat="server" Text="Limpiar" Width="100px" Height="30px" onclick="btnLimpiarJuzgado_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td> Nombre : </td>
                        <td><asp:TextBox ID="txtNombreSecretaria" runat="server" Width="280px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> Secretario : </td>
                        <td><asp:TextBox ID="txtSecretario" runat="server" Width="280px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnCargarSecretaria" runat="server" Text="Cargar" Width="100px" Height="30px" onclick="btnCargarSecretaria_Click" />&nbsp;
                            <asp:Button ID="btnLimpiarSecretaria" runat="server" Text="Limpiar" Width="100px" Height="30px" onclick="btnLimpiarSecretaria_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridViewJuzgados" runat="server" 
                    AutoGenerateColumns="False" 
                    CellPadding="4" 
                    DataSourceID="ObjectDataSourceJuzgados" 
                    ForeColor="#333333" 
                    GridLines="None"
                    EmptyDataText="No se Encontraon Juzgados" 
                    EmptyDataRowStyle-HorizontalAlign="Center"
                    OnRowDeleting="GridViewJuzgados_RowDeleting" 
                    OnRowDeleted="GridViewJuzgados_RowDeleted" 
                    OnRowCommand="GridViewJuzgados_RowCommand" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                            SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                            DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Juez" HeaderText="Juez" SortExpression="Juez" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
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
                <asp:ObjectDataSource ID="ObjectDataSourceJuzgados" runat="server" 
                    DeleteMethod="eliminarJuzgado" 
                    SelectMethod="traerJuzgados" 
                    TypeName="BussinessLayer.Controller">
                    <DeleteParameters>
                        <asp:Parameter Name="pId" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </td>
            <td align="center">
                <asp:GridView ID="GridViewSecretarias" runat="server" 
                    AutoGenerateColumns="False" 
                    CellPadding="4" 
                    EmptyDataText="No Se Encontraron Secretarías Asociadas"
                    EmptyDataRowStyle-HorizontalAlign="Center"
                    ForeColor="#333333" 
                    GridLines="None" 
                    OnRowDeleted="GridViewSecretarias_RowDeleted" 
                    OnRowDeleting="GridViewSecretarias_RowDeleting" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                            SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                            DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Secretario" HeaderText="Secretario" SortExpression="Secretario" />
                        <asp:BoundField DataField="Juzgado" HeaderText="Juzgado" SortExpression="Juzgado" Visible="false" />
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
                <asp:ObjectDataSource ID="ObjectDataSourceSecretarias" runat="server"
                    DeleteMethod="eliminarSecretaria" 
                    SelectMethod="traerSecretarias" 
                    TypeName="BussinessLayer.Controller">
                    <DeleteParameters>
                        <asp:Parameter Name="pId" Type="Int32" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblJuzgadoId" Name="pJuzgado" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <br />

</asp:Content>