using System;
using Entities;
using BussinessLayer;

public partial class Account_Login : System.Web.UI.Page
{
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        Login1.Focus();
    }

    //EVENTOS DE LOGIN
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        string userName = Login1.UserName;
        
        if (userName != "Admin")
        {
            Abogado oAbogado = (Abogado)Controller.abogadoUserName(userName);

            if (oAbogado == null)
            {
                Response.Redirect("~/Abogado/NuevoAbogado.aspx");
            }
            else
            {
                Response.Redirect("~/Principal.aspx");
            }  
        }
        else if (userName == "Admin")
        {
            Response.Redirect("~/Admin/Administrador.aspx");
        }
    }
}