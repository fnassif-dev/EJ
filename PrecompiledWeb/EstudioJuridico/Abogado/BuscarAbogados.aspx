<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="BuscarAbogados, App_Web_rupjzldv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2> Buscar Abogados </h2>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="False" 
        Width="100%">
        <asp:Label ID="lblNombre" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblApellido" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblDocumento" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />
    
    <table align="center" border="1" style="width: 445px">
        <tr>
            <td> Nombre :</td>
            <td><asp:TextBox ID="txtBuscarNombre" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td> Apellido :</td>
            <td><asp:TextBox ID="txtBuscarApellido" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Docuemtno:</td>
            <td><asp:TextBox ID="txtBuscarDocumento" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" Height="30px" onclick="btnBuscar_Click" />&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100px" Height="30px" onclick="btnLimpiar_Click" />
            </td>            
        </tr>
    </table>

    <br />

    <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
    <br />

    <asp:Panel ID="PanelOpciones" runat="server" Visible="false">
        <asp:LinkButton ID="lnkModificarAbogado" runat="server" onclick="lnkModificarAbogado_Click"> Modificar Abogado </asp:LinkButton>&nbsp; | &nbsp;
        <asp:LinkButton ID="lnkAgregarEspecializaciones" runat="server" onclick="lnkAgregarEspecializaciones_Click"> Administrar Especializaciones </asp:LinkButton>
    </asp:Panel>

    <br />
    <div align="center">
        <asp:GridView ID="GridViewAbogados" runat="server"
            AllowPaging="True" 
            AutoGenerateColumns="False" 
            CellPadding="4"              
            EmptyDataText="No Se Encontraron Abogados"
            EmptyDataRowStyle-HorizontalAlign="Center"
            Width="100%"
            PageSize="15"
            ForeColor="#333333" 
            GridLines="None"
            HorizontalAlign="Center"
            RowStyle-HorizontalAlign="Center"
            onRowDeleted="GridViewAbogados_RowDeleted" 
            onRowDeleting="GridViewAbogados_RowDeleting" 
            onSelectedIndexChanged="GridViewAbogados_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="White" />
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
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                    SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                <asp:CommandField ShowEditButton="True" ButtonType="Image" 
                    EditText="Editar" EditImageUrl="~/Images/GridViewButtons/application_edit.png"
                    UpdateImageUrl="~/Images/GridViewButtons/accept.png" UpdateText="Aceptar"
                    CancelText="Cancelar" CancelImageUrl="~/Images/GridViewButtons/cross.png"/>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                    DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" ReadOnly="true" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" ReadOnly="true" />
                <asp:TemplateField HeaderText="TipoDocumento" SortExpression="TipoDocumento">
                    <ItemTemplate>
                        <asp:Label ID="TipoDocumento" runat="server" Text='<%# Eval("TipoDocumento.Descripcion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Documento" HeaderText="Documento" SortExpression="Documento" />
                <asp:TemplateField HeaderText="EstadoCivil" SortExpression="EstadoCivil">
                    <ItemTemplate>
                        <asp:Label ID="EstadoCivil" runat="server" Text='<%# Eval("EstadoCivil.Descripcion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Provincia" SortExpression="Provincia">
                    <ItemTemplate>
                        <asp:Label ID="Provincia" runat="server" Text='<%# Eval("Provincia.Descripcion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ciudad" SortExpression="Ciudad">
                    <ItemTemplate>
                        <asp:Label ID="Ciudad" runat="server" Text='<%# Eval("Ciudad.Descripcion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Celular" HeaderText="Celular" SortExpression="Celular" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceAbogados" runat="server" 
            TypeName="BussinessLayer.Controller"
            DeleteMethod="eliminarAbogado" 
            SelectMethod="buscarAbogados">
            <DeleteParameters>
                <asp:Parameter Name="pId" Type="Int32" DefaultValue="0" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lblNombre" Name="pNombre" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblApellido" Name="pApellido" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblDocumento" Name="pDocumento" PropertyName="Text" Type="Int32" DefaultValue="0" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>

    <br />

</asp:Content>