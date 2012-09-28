<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Abogado_VerTurnos, App_Web_kxlmikau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Ver Turnos Asignados </h1>
    <hr style="width: 977px" />
    <asp:Panel ID="Panel1" runat="server" Height="22px" 
        HorizontalAlign="Center" 
        Visible="False" 
        Width="100%">
        <asp:Label ID="lblAbogadoId" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblNombre" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblApellido" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="lblDocumento" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <br />
    <div align="center">
        <asp:GridView ID="GridViewTurnos" runat="server" 
            CellPadding="4" 
            DataSourceID="ObjectDataSourceTurnos" 
            ForeColor="#333333" 
            GridLines="None" 
            AutoGenerateColumns="False" 
            onrowupdating="GridViewTurnos_RowUpdating" 
            EmptyDataText="No Hay Turnos Asignados" AllowPaging="True" PageSize="15" 
            Width="916px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True" ButtonType="Image" 
                    EditText="Editar" EditImageUrl="~/Images/GridViewButtons/application_edit.png"
                    UpdateImageUrl="~/Images/GridViewButtons/accept.png" UpdateText="Aceptar"
                    CancelText="Cancelar" CancelImageUrl="~/Images/GridViewButtons/cross.png"/>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" 
                    DeleteImageUrl="~/Images/GridViewButtons/delete.png" DeleteText="Eliminar"/>
                <asp:BoundField DataField="Id" HeaderText="Nro de Turno" SortExpression="Id" ReadOnly="true" /> 
                <asp:BoundField DataField="FechaTurno" HeaderText="FechaTurno" SortExpression="FechaTurno" ReadOnly="true" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" ReadOnly="true" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" ReadOnly="true" />
                <asp:CheckBoxField DataField="Ausente" HeaderText="Ausente" SortExpression="Ausente" />
                <asp:CheckBoxField DataField="Atendido" HeaderText="Atendido" SortExpression="Atendido" />
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
        <asp:ObjectDataSource ID="ObjectDataSourceTurnos" runat="server"
            DeleteMethod="eliminarTurno" 
            SelectMethod="traerTurnos"
            UpdateMethod="guardarTurno" 
            TypeName="BussinessLayer.Controller" 
            OldValuesParameterFormatString="original_{0}" >
            <DeleteParameters>
                <asp:Parameter Name="pId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lblAbogadoId" Name="pId" PropertyName="Text" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="pTurno" Type="Object" />
                <asp:Parameter Name="pOperacion" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    <br />

</asp:Content>