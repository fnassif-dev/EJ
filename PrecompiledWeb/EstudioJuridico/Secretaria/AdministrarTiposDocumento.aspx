<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="AgregarTiposDocumento, App_Web_3achn1v4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Administracion de Tipos de Documento </h1>
    <hr style="width: 977px" />
    <br />
    Esta Pagina le Permite Administrar los Tipos de Documento que se utilizaran en el sistema<br />
    &nbsp;
    <table style="width: 68%;" align="center">
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <table style="width: 379px" align="center">
                <tr>
                    <td> Nuevo Tipo de Documento : </td>
                    <td><asp:TextBox ID="txtDescripcion" runat="server" Width="179px"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rqfvTipoDocumento" runat="server" 
                            ControlToValidate="txtDescripcion" 
                            ErrorMessage="*" 
                            ForeColor="Red"
                            Text="*" 
                            ToolTip="La Descripcion del Tipo de Documento es Obligatoria">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="100px" Height="30px" onclick="btnAgregar_Click" />
                    </td>
                </tr>
            </table>        
            <br />
            <br />
        </td>
        <td align="left">
            <asp:GridView ID="GridViewTipoDocumento" runat="server" 
                AutoGenerateColumns="False" 
                CellPadding="4" 
                DataSourceID="ObjectDataSourceTipoDocumento" 
                ForeColor="#333333" 
                GridLines="None" 
                onrowdeleted="GridViewTipoDocumento_RowDeleted" 
                onrowdeleting="GridViewTipoDocumento_RowDeleting" 
                onrowupdating="GridViewTipoDocumento_RowUpdating">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Image" 
                        EditText="Editar" EditImageUrl="~/Images/GridViewButtons/application_edit.png"
                        UpdateImageUrl="~/Images/GridViewButtons/accept.png" UpdateText="Aceptar"
                        CancelText="Cancelar" CancelImageUrl="~/Images/GridViewButtons/cross.png"/>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                        DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="true" />
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
            <asp:ObjectDataSource ID="ObjectDataSourceTipoDocumento" runat="server" 
                DeleteMethod="eliminarTipoDocumento" 
                SelectMethod="traerTiposDocumento" 
                TypeName="BussinessLayer.Controller" 
                UpdateMethod="guardarTipoDocumento">
                <DeleteParameters>
                    <asp:Parameter Name="pId" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="pTipoDocumento" Type="Object" />
                    <asp:Parameter Name="pOperacion" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    </table>        
    
<br />

</asp:Content>