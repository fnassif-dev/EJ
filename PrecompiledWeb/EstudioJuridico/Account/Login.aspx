﻿<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_Login, App_Web_zch4vhvq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1> Acceso de Usuarios </h1>
    <hr style="width: 977px" />
    <br />
    Debe Iniciar Sesion Para Poder Utilizar El Sistema
    <br />
    <br />
    <div align="center">
        <asp:Login ID="Login1" runat="server" Height="172px" Width="370px" 
            onloggedin="Login1_LoggedIn" 
            PasswordRecoveryText="¿Olvidate tu contraseña?" 
            PasswordRecoveryUrl="~/Account/RecoveryPassword.aspx" >
        </asp:Login>
        <br />
    </div>
        
</asp:Content>