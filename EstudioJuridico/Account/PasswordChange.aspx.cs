using System;

public partial class Account_PasswordChange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //EVENTOS DE CHANGE PASSWORD
    protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Principal.aspx");
    }
}