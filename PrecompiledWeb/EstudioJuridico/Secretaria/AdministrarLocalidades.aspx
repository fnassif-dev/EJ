<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="AdministrarLocalidades, App_Web_3achn1v4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Administracion de Provincias y Ciudades </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="True" 
        Width="100%">
        <asp:Label ID="lblProvinciaId" runat="server" Visible="False" Text="0"></asp:Label>&nbsp;
        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />
    Esta Pagina le Permite Administrar las Provincias y las Ciudades que se utilizaran en el sistema
    <br />
    <br />
    <table align="center" style="width: 79%;">
        <tr>
            <td><b> Provincias</b></td>
            <td><b> Ciudades</b></td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td> Nombre :</td>
                        <td><asp:TextBox ID="txtProvincia" runat="server" Width="280px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"> 
                            <asp:Button ID="btnCargarProvincia" runat="server" Text="Cargar" Width="100px" onclick="btnCargarProvincia_Click" />&nbsp;
                            <asp:Button ID="btnLimpiarProvincia" runat="server" Text="Limpiar" Width="100px" onclick="btnLimpiarProvincia_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td> Nombre : </td>
                        <td><asp:TextBox ID="txtCiudad" runat="server" Width="280px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnCargarCiudades" runat="server" Text="Cargar" Width="100px" onclick="btnCargarCiudades_Click" />&nbsp;
                            <asp:Button ID="btnLimpiarCiudades" runat="server" Text="Limpiar" Width="100px" onclick="btnLimpiarCiudades_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridViewProvincias" runat="server" 
                    AutoGenerateColumns="False" 
                    CellPadding="4" 
                    DataSourceID="ObjectDataSourceProvincias" 
                    ForeColor="#333333" 
                    GridLines="None"
                    EmptyDataText="No se Encontraon Juzgados" 
                    EmptyDataRowStyle-HorizontalAlign="Center" 
                    onrowcommand="GridViewProvincias_RowCommand" 
                    onrowdeleted="GridViewProvincias_RowDeleted" 
                    onrowdeleting="GridViewProvincias_RowDeleting" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                            SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                            DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
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
                <asp:ObjectDataSource ID="ObjectDataSourceProvincias" runat="server" 
                    DeleteMethod="eliminarProvincia" 
                    SelectMethod="traerProvincias" 
                    TypeName="BussinessLayer.Controller" 
                    OldValuesParameterFormatString="original_{0}">
                    <DeleteParameters>
                        <asp:Parameter Name="pId" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </td>
            <td align="center" valign="top">
                <asp:GridView ID="GridViewCiudades" runat="server" 
                    AutoGenerateColumns="False" 
                    CellPadding="4" 
                    EmptyDataText="No Se Encontraron Secretarías Asociadas"
                    EmptyDataRowStyle-HorizontalAlign="Center"
                    ForeColor="#333333" 
                    GridLines="None"
                    onrowdeleted="GridViewCiudades_RowDeleted" 
                    onrowdeleting="GridViewCiudades_RowDeleting" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                            SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                            DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Provincia" HeaderText="Provincia" SortExpression="Provincia" Visible="false" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataRowStyle HorizontalAlign="Center" />
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
                <asp:ObjectDataSource ID="ObjectDataSourceCiudades" runat="server"
                    DeleteMethod="eliminarCiudad" 
                    SelectMethod="traerCiudadesPorProvincia" 
                    TypeName="BussinessLayer.Controller" 
                    OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblProvinciaId" Name="pId" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="pId" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <br />

</asp:Content>