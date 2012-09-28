using System;
using Entities;

public partial class Abogado_VerEscritos : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    Expediente oExpedienteSession = null;

    //METODOS ADICIONALES
    public void Clean()
    {

    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Expediente"] != null)
        {
            oExpedienteSession = (Expediente)Session["Expediente"];

            lblExpedienteId.Text = oExpedienteSession.Id.ToString();
            txtNumeroExpediente.Text = oExpedienteSession.Id.ToString();
            txtFechaInicio.Text = oExpedienteSession.FechaInicio.ToString();
            txtCaratula.Text = oExpedienteSession.Caratula;
        }
    }
}