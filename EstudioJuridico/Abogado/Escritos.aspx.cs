using System;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class Abogado_Escritos : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    Expediente oExpedienteSession = null;

    //METODOS ADICIONALES
    public void Clean()
    {
        txtEscrito.Text = string.Empty;

        lblError.Text = string.Empty;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Expediente"] != null)
        {
            oExpedienteSession = (Expediente)Session["Expediente"];

            lblExpediente.Text = oExpedienteSession.Id.ToString();
            lblConsulta.Text = oExpedienteSession.Consulta.Id.ToString();
            txtJuzgado.Text = oExpedienteSession.Juzgado.Nombre;
            txtSecretaria.Text = oExpedienteSession.Secretaria.Nombre;
            txtFechaInicio.Text = oExpedienteSession.FechaInicio.ToString();
            txtCaratula.Text = oExpedienteSession.Caratula;
            txtDescripcion.Text = oExpedienteSession.Descripcion;
            txtActores.Text = oExpedienteSession.Actores;
        }
    }

    //EVENTOS CLICK
    protected void btnCargar_Click(object sender, EventArgs e)
    {
        try
        {
            Consulta oConsulta = (Consulta)oExpedienteSession.Consulta;
            oConsulta.Estado = 4;
            
            Escrito oEscrito = new Escrito();
            oEscrito.Expediente = Convert.ToInt32(lblExpediente.Text);
            oEscrito.Descripcion = txtEscrito.Text;
            oEscrito.Fecha = DateTime.Now;

            Controller.agregarEscrito(oEscrito);

            Controller.guardarConsulta(oConsulta, "Update");

            Clean();

            lblError.Visible = true;
            lblError.ForeColor = Color.Green;

            if (chkCerrarExpediente.Checked == true)
            {
                Controller.cerrarExpediente(oExpedienteSession);



                chkCerrarExpediente.Checked = false;

                lblError.Text = "El Expediente Se Ha Cerrado Exitosamente";
            }
            else
            {
                lblError.Text = "El Escrito Se Ha Cargado Exitosamente";
            }
        }
        catch (Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Ocurrio Un Error Al Cargar El Escrito";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Clean();
    }
}