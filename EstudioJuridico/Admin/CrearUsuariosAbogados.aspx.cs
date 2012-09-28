using System;
using System.Web.Security;

public partial class Account_CreateAccount : System.Web.UI.Page
{
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //EVENTOS DE CREATE USER WIZARD
    protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(CreateUser.UserName, "Abogado");
    }
    protected void CreateUserWizard_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Administrador.aspx");
    }
}