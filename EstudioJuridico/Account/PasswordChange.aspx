<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PasswordChange.aspx.cs" Inherits="Account_PasswordChange" %>

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