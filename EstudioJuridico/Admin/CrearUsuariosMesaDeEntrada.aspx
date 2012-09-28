<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CrearUsuariosMesaDeEntrada.aspx.cs" Inherits="Admin_CrearUsuariosMesaDeEntrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Pagina de Creacion de Usuarios Para Mesa de Entrada </h1>
    <hr style="width: 977px" />
    <br />
    <div align="center">
        <asp:CreateUserWizard ID="CreateUserWizardMesaDeEntrada" runat="server"
            Width="514px"
            LoginCreatedUser="False" 
            OnContinueButtonClick="CreateUserWizardMesaDeEntrada_ContinueButtonClick" 
            OnCreatedUser="CreateUserWizardMesaDeEntrada_CreatedUser" >
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
    <br />

</asp:Content>