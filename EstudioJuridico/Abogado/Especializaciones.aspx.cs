using System;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class Especializaciones : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    Abogado oAbogadoSession = null;

    //METODOS ADICIONALES
    public void Clean()
    {
        txtDescripcion.Text = string.Empty;
        txtFecha.Text = string.Empty;

        lblError.Visible = false;
        lblError.Text = string.Empty;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Abogado"] != null)
        {   
            oAbogadoSession = (Abogado)Session["Abogado"];

            lblAbogadoId.Text = oAbogadoSession.Id.ToString();
            txtNombreAbogado.Text = oAbogadoSession.Apellido.ToUpper() + ", " + oAbogadoSession.Nombre;
            txtDireccionAbogado.Text = oAbogadoSession.Direccion;
            txtDocumentoAbogado.Text = oAbogadoSession.Documento.ToString();
            txtTelefonoAbogado.Text = oAbogadoSession.Telefono;
            
            lnkAbogado.Text = "Cambiar Abogado";

            Session.Abandon();
        }
        else
        {
            lnkAbogado.Text = "Seleccionar Abogado";
        }
    }
    
    //EVENTOS CLICK DE BUTTONS
    protected void btnCargar_Click(object sender, EventArgs e)
    {
        try
        {
            Abogado oAbogado = new Abogado();
            oAbogado.Id = Convert.ToInt32(lblAbogadoId.Text);
            
            Especializacion oEspecializacion = new Especializacion();

            oEspecializacion.Abogado = oAbogado;
            oEspecializacion.Descripcion = txtDescripcion.Text;
            oEspecializacion.Fecha = txtFecha.Text;

            Controller.agregarEspecializacion(oEspecializacion);

            Clean();

            lblError.Visible = true;
            lblError.ForeColor = Color.Green;
            lblError.Text = "Especializacion Cargaa con Exito";
        }
        catch (Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Se produjo un error al cargar la Especializacion. Por favor, intentelo nuevamente";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Clean();
    }
    protected void lnkAbogado_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Abogado/BuscarAbogados.aspx");
    }
    protected void lnkVerEspecializaciones_Click(object sender, EventArgs e)
    {
        GridViewEspecializaciones.DataSourceID = "ObjectDataSourceEspecializaciones";
        GridViewEspecializaciones.DataBind();
    }
}