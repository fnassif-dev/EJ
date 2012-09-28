<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="BuscarExpedientes, App_Web_3achn1v4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Buscador de Expedientes </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="False" 
        Width="100%">
        <asp:Label ID="lblJuzgado" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblAbogado" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblFecha" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />

    <table align="center" style="width: 445px" border="1">
        <tr>
            <td> Abogado :</td>
            <td><asp:TextBox ID="txtAbogado" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Juzgado :</td>
            <td><asp:TextBox ID="txtJuzgado" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fecha Inicio :</td>
            <td><asp:TextBox ID="txtFechaInicio" runat="server" Width="206px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="chkExpedientesCerrados" runat="server" 
                    Text="Buscar Expedientes Cerrados" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" onclick="btnBuscar_Click" />&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100px" onclick="btnLimpiar_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />

    <asp:Panel ID="PanelOpciones" runat="server" Visible="false">
        <asp:LinkButton ID="lnkModificarExpediente" runat="server" onclick="lnkModificarExpediente_Click" > Modificar Expediente </asp:LinkButton>&nbsp; | &nbsp;
        <asp:LinkButton ID="lnkAgregarEscritos" runat="server" onclick="lnkAgregarEscritos_Click" > Agregar Escritos </asp:LinkButton>&nbsp; | &nbsp;
        <asp:LinkButton ID="lnkVerEscritos" runat="server" onclick="lnkVerEscritos_Click" > Ver Escritos Del Expediente </asp:LinkButton>
    </asp:Panel>
    <br />

    <div align="center">
        <asp:GridView ID="GridViewExpedientes" runat="server" 
            CellPadding="4" 
            ForeColor="#333333" 
            GridLines="None" 
            AutoGenerateColumns="False" 
            EmptyDataText="No Se Encontraron Expedientes" 
            onrowdeleted="GridViewExpedientes_RowDeleted" 
            onrowdeleting="GridViewExpedientes_RowDeleting" 
            onselectedindexchanged="GridViewExpedientes_SelectedIndexChanged" 
            AllowPaging="True" PageSize="20">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Image" 
                    SelectText="Seleccionar" SelectImageUrl="~/Images/GridViewButtons/select.png"/>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                    DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                <asp:BoundField DataField="Id" HeaderText="Nro Expediente" SortExpression="Id" />
                <asp:BoundField DataField="Caratula" HeaderText="Caratula" SortExpression="Caratula" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Actores" HeaderText="Actores" SortExpression="Actores" />
                <asp:TemplateField HeaderText="Juzgado" SortExpression="Juzgado">
                    <ItemTemplate>
                        <asp:Label ID="Juzgado" runat="server" Text='<%# Eval("Juzgado.Nombre") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Secretaria" SortExpression="Secretaria">
                    <ItemTemplate>
                        <asp:Label ID="Secretaria" runat="server" Text='<%# Eval("Secretaria.Nombre") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FechaInicio" HeaderText="FechaInicio" SortExpression="FechaInicio" />
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
        <asp:ObjectDataSource ID="ObjectDataSourceExpedientes" runat="server" 
            DeleteMethod="eliminarExpediente" 
            SelectMethod="buscarExpedientes" 
            TypeName="BussinessLayer.Controller">
            <DeleteParameters>
                <asp:Parameter Name="pId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lblAbogado" Name="pAbogado" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblJuzgado" Name="pJuzgado" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceExpedientesCerrados" runat="server"            
            SelectMethod="buscarExpedientesCerrados" 
            TypeName="BussinessLayer.Controller">            
            <SelectParameters>
                <asp:ControlParameter ControlID="lblAbogado" Name="pAbogado" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblJuzgado" Name="pJuzgado" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <br />

</asp:Content>

