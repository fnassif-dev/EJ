using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(Session["Exception"] != null)
            {
                Exception oException = (Exception) Session["Exception"];

                lblError.Text = oException.Message;
                lblError2.Text = oException.StackTrace;
                lblError3.Text = oException.Source;
            }

            
        }
 
    }
}