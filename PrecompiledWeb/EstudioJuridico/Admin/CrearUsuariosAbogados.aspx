<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_CreateAccount, App_Web_rsltxahd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Pagina de Creacion de Usuarios de Abogados </h1>
    <hr style="width: 977px" />
    <br />
    <div align="center">
        <asp:CreateUserWizard ID="CreateUser" runat="server" 
            Width="514px"
            LoginCreatedUser="False"
            OnCreatedUser="CreateUserWizard_CreatedUser"
            OnContinueButtonClick="CreateUserWizard_ContinueButtonClick" >
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>

</asp:Content>