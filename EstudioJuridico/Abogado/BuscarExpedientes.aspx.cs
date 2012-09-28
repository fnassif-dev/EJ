using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuscarExpedientes : System.Web.UI.Page
{
    //METODOS ADICIONALES
    public void Clean()
    {
        txtCliente.Text = string.Empty;
        txtAbogado.Text = string.Empty;
        txtFechaInicio.Text = string.Empty;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Clean();
        }
    }

    //EVENTOS CLICK DE BUTTONS
    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Clean();
    }
}