using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class Abogado_NuevoExpediente : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    Consulta oConsultaSession = null;
    Expediente oExpedienteSession = null;
    string pOperacion;
    
    //METODOS ADICIONALES
    public void Clean()
    {
        ddlJuzgados.SelectedIndex = -1;
        ddlSecretarias.SelectedIndex = -1;
        txtCaratula.Text = string.Empty;
        txtActores.Text = string.Empty;
        txtDescripcionExpediente.Text = string.Empty;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Consulta"] != null || Session["Expediente"] != null)
            {
                if (Session["Expediente"] != null)
                {
                    oExpedienteSession = (Expediente)Session["Expediente"];

                    lblConsultaId.Text = oExpedienteSession.Consulta.Id.ToString();
                    txtNombreCliente.Text = oExpedienteSession.Consulta.Cliente.Nombre;
                    txtAbogadoConsulta.Text = oExpedienteSession.Consulta.Abogado.Nombre;
                    txtFechaConsulta.Text = oExpedienteSession.Consulta.Fecha.ToString();
                    txtTemaConsulta.Text = oExpedienteSession.Consulta.TemaConsulta.Descripcion;
                    txtDescripcionConsulta.Text = oExpedienteSession.Consulta.Descripcion;

                    lblExpedienteId.Text = oExpedienteSession.Id.ToString();
                    txtCaratula.Text = oExpedienteSession.Caratula;
                    txtActores.Text = oExpedienteSession.Actores;
                    txtDescripcionExpediente.Text = oExpedienteSession.Descripcion;
                    txtFechaInicio.Text = oExpedienteSession.FechaInicio.ToShortDateString();
                }
                else
                {
                    oConsultaSession = (Consulta)Session["Consulta"];

                    lblConsultaId.Text = oConsultaSession.Id.ToString();
                    txtNombreCliente.Text = oConsultaSession.Cliente.Nombre;
                    txtAbogadoConsulta.Text = oConsultaSession.Abogado.Nombre;
                    txtFechaConsulta.Text = oConsultaSession.Fecha.ToString();
                    txtTemaConsulta.Text = oConsultaSession.TemaConsulta.Descripcion;
                    txtDescripcionConsulta.Text = oConsultaSession.Descripcion;

                    txtFechaInicio.Text = DateTime.Now.ToShortDateString();
                }
            }

            Session.Abandon();
        }
    }

    //EVENTOS CLICK
    protected void btnCargar_Click(object sender, EventArgs e)
    {
        if (lblExpedienteId.Text != string.Empty)
        {
            pOperacion = "Update";
        }
        else
        {
            pOperacion = "Insert";
            lblExpedienteId.Text = "0";
        }
        
        try
        {
            Consulta oConsulta = Controller.consultaPorId(Convert.ToInt32(lblConsultaId.Text));
            oConsulta.Estado = 2;
            //oConsulta.Id = Convert.ToInt32(lblConsultaId.Text);

            Juzgado oJuzgado = new Juzgado();
            oJuzgado.Id = Convert.ToInt32(ddlJuzgados.SelectedValue);

            Secretaria oSecretaria = new Secretaria();
            oSecretaria.Id = Convert.ToInt32(ddlSecretarias.SelectedValue);

            Expediente oExpediente = new Expediente();
            oExpediente.Id = Convert.ToInt32(lblExpedienteId.Text);
            oExpediente.Caratula = txtCaratula.Text;
            oExpediente.Descripcion = txtDescripcionExpediente.Text;
            oExpediente.Actores = txtActores.Text;
            oExpediente.Consulta = oConsulta;
            oExpediente.Juzgado = oJuzgado;
            oExpediente.Secretaria = oSecretaria;
            oExpediente.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);

            Controller.guardarExpediente(oExpediente, pOperacion);

            Controller.guardarConsulta(oConsulta, "Update");

            Clean();

            lblError.Visible = true;
            lblError.ForeColor = Color.Green;
            lblError.Text = "Los Datos Del Expediente Se Han Cargado Exitosamente";
        }
        catch (Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Ocurrio Un Error Al Cargar El Expediente";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Clean();
    }
    protected void lnkCambiarConsulta_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Secretaria/BuscarConsultas.aspx");
    }
}