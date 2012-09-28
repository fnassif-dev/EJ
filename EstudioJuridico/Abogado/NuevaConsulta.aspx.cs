using System;
using System.Drawing;
using System.Web.Security;
using Entities;
using BussinessLayer;

public partial class NuevaConsulta : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    Cliente oClienteSession = null;
    Consulta oConsultaSession = null;
    Abogado oAbogadoLogueado = null;
    string pOperacion;

    //METODOS ADICIONALES
    public void Clean()
    {
        ddlTemaConsulta.SelectedIndex = 0;
        ddlEstado.SelectedIndex = 0;
        txtDescripcion.Text = string.Empty;

        lblError.Visible = false;
        lblError.Text = string.Empty;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlTemaConsulta.DataBind();
        if (!Page.IsPostBack)
        {
            if (Session["Cliente"] != null || Session["Consulta"] != null)
            {
                if (Session["Consulta"] != null)
                {
                    oConsultaSession = (Consulta)Session["Consulta"];

                    lblConsultaId.Text = oConsultaSession.Id.ToString();
                    lblClienteId.Text = oConsultaSession.Cliente.Id.ToString(); ;
                    txtNombreCliente.Text = oConsultaSession.Cliente.Apellido.ToUpper() + ", " + oConsultaSession.Cliente.Nombre;
                    txtNacimientoCliente.Text = oConsultaSession.Cliente.FechaNacimiento.Date.ToString();
                    txtDireccioncliente.Text = oConsultaSession.Cliente.Direccion;
                    txtTelefonoCliente.Text = oConsultaSession.Cliente.Telefono;

                    ddlTemaConsulta.Items.FindByText(oConsultaSession.TemaConsulta.Descripcion).Selected = true;
                    ddlEstado.SelectedIndex = oConsultaSession.Estado - 1;
                    txtDescripcion.Text = oConsultaSession.Descripcion;
                }
                else
                {
                    oClienteSession = (Cliente)Session["Cliente"];

                    lblClienteId.Text = oClienteSession.Id.ToString();
                    txtNombreCliente.Text = oClienteSession.Apellido.ToUpper() + ", " + oClienteSession.Nombre;
                    txtNacimientoCliente.Text = oClienteSession.FechaNacimiento.Date.ToString();
                    txtDireccioncliente.Text = oClienteSession.Direccion;
                    txtTelefonoCliente.Text = oClienteSession.Telefono;
                }
            }

            if (Session["AbogadoLogueado"] != null)
            {
                oAbogadoLogueado = (Abogado)Session["AbogadoLogueado"];
            }
        }
        //Session.Abandon();
    }

    //EVENTOS CLICK
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtNombreCliente.Text))
        {
            if (lblConsultaId.Text != string.Empty)
            {
                pOperacion = "Update";
            }
            else
            {
                pOperacion = "Insert";
                lblConsultaId.Text = "0";
                
            }
            
            try
            {
                Cliente oCliente = Controller.traerClientePorId(Convert.ToInt32(lblClienteId.Text));
                Abogado oAbogado = Controller.abogadoLogueado(Membership.GetUser().ProviderUserKey.ToString());

                TemaConsulta oTemaConsulta = new TemaConsulta();
                oTemaConsulta.Id = ddlTemaConsulta.SelectedIndex + 1;
                oTemaConsulta.Descripcion = ddlTemaConsulta.SelectedItem.Text;

                Consulta oConsulta = new Consulta();
                oConsulta.Id = Convert.ToInt32(lblConsultaId.Text);
                oConsulta.Cliente = oCliente;
                oConsulta.Abogado = oAbogado;
                oConsulta.TemaConsulta = oTemaConsulta;
                oConsulta.Estado = ddlEstado.SelectedIndex + 1;
                oConsulta.Descripcion = txtDescripcion.Text;
                oConsulta.Fecha = DateTime.Now;

                Controller.guardarConsulta(oConsulta, pOperacion);

                Clean();

                lblError.Visible = true;
                lblError.ForeColor = Color.Green;
                lblError.Text = "La Consulta Se Ha Cargado Exitosamente";

                if (chkGenerarExpediente.Checked == true)
                {
                    Session["Consulta"] = oConsulta;

                    Response.Redirect("~/Abogado/NuevoExpediente.aspx");
                }
            }
            catch (Exception)
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
                lblError.Text = "Ha Ocurrido Un Error Al Cargar La Consulta";
            }
        }
        else
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "No Se Ha Cargado El Cliente Correspondiente A La Consulta";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Clean();
    }
    protected void lnkCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Secretaria/BuscarClientes.aspx");
    }
}