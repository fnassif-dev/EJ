<%@ Application Language="C#" %>
<%@ Import Namespace="System.Diagnostics" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta al iniciarse la aplicación

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Código que se ejecuta cuando se cierra la aplicación

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        try
        {
            Exception objErr = Server.GetLastError().GetBaseException();

            Server.ClearError();

            Session["Exception"] = objErr;

            Response.Redirect("~/Default.aspx");
        }
        catch (Exception)
        {
            
        }
        finally
        {
            Server.Transfer("~/Default.aspx");
        }
        
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando se inicia una nueva sesión

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        // o SQLServer, el evento no se genera.

    }
       
</script>
