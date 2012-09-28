<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RecoveryPassword.aspx.cs" Inherits="Account_RecoveryPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Pagina de Recuperacion de Contraseña </h1>
    <hr style="width: 977px" />
    <br />
    <div align="center">
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
        </asp:PasswordRecovery>
    </div>

</asp:Content>