using System;
using System.Web.Security;

public partial class Admin_CrearUsuariosMesaDeEntrada : System.Web.UI.Page
{
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateUserWizardMesaDeEntrada.Focus();
    }

    //EVENTOS CREATE USER WIZZARD
    protected void CreateUserWizardMesaDeEntrada_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(CreateUserWizardMesaDeEntrada.UserName, "MesaDeEntrada");
    }
    protected void CreateUserWizardMesaDeEntrada_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Administrador.aspx");
    }
}