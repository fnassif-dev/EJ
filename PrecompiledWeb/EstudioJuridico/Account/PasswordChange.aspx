<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_PasswordChange, App_Web_zch4vhvq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Pagina de Modificacion de Contraseña </h1>
    <hr style="width: 977px" />
    <br />
    <div align="center">
        <asp:ChangePassword ID="ChangePassword1" runat="server" 
            oncontinuebuttonclick="ChangePassword1_ContinueButtonClick">
        </asp:ChangePassword>
    </div>

</asp:Content>