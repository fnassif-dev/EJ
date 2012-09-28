using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class NuevoAbogado : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    string pOperacion;
    Abogado oAbogadoSession = null;
    
    //METODOS ADICIONALES
    public void Clean()
    {
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        ddlTipoDocumento.SelectedIndex = -1;
        txtDocumento.Text = string.Empty;
        txtFechaNacimiento.Text = string.Empty;
        ddlEstadoCivil.SelectedIndex = -1;
        ddlProvincias.SelectedIndex = -1;
        ddlCiudades.SelectedIndex = -1;
        txtDireccion.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCelular.Text = string.Empty;

        lblError.Text = string.Empty;
        lblError.Visible = false;
        lblIdAbogado.Text = string.Empty;
        lblIdAbogado.Visible = false;

        Panel1.Visible = false;
    }

    //EVENTO PAGE_LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Abogado"] != null)
        {
            ddlTipoDocumento.DataBind();
            ddlEstadoCivil.DataBind();
            ddlProvincias.DataBind();
            
            oAbogadoSession = (Abogado)Session["Abogado"];

            lblIdAbogado.Text = oAbogadoSession.Id.ToString();
            txtNombre.Text = oAbogadoSession.Nombre;
            txtApellido.Text = oAbogadoSession.Apellido;
            ddlTipoDocumento.Items.FindByText(oAbogadoSession.TipoDocumento.Descripcion).Selected = true;
            txtDocumento.Text = oAbogadoSession.Documento.ToString();
            txtFechaNacimiento.Text = oAbogadoSession.FechaNacimiento.ToShortDateString();
            ddlEstadoCivil.Items.FindByText(oAbogadoSession.EstadoCivil.Descripcion).Selected = true;
            ddlProvincias.Items.FindByText(oAbogadoSession.Provincia.Descripcion).Selected = true;
            //ddlCiudades.Items.FindByText(oAbogadoSession.Ciudad.Descripcion).Selected = true;
            txtDireccion.Text = oAbogadoSession.Direccion;
            txtTelefono.Text = oAbogadoSession.Telefono;
            txtCelular.Text = oAbogadoSession.Celular;

            pOperacion = "Update";

            Session.Abandon();
        }
        else
        {
            pOperacion = "Insert";
        }
    }
    
    //EVENTOS CLICK BUTTONS
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (lblIdAbogado.Text != string.Empty)
        {
            pOperacion = "Update";
        }
        else
        {
            pOperacion = "Insert";
            lblIdAbogado.Text = "0";
        }
        
        try
        {
            TipoDocumento oTipoDocumento = new TipoDocumento();
            oTipoDocumento.Id = ddlTipoDocumento.SelectedIndex + 1;
            oTipoDocumento.Descripcion = ddlTipoDocumento.SelectedItem.Text;

            EstadoCivil oEstadoCivil = new EstadoCivil();
            oEstadoCivil.Id = ddlEstadoCivil.SelectedIndex + 1;
            oEstadoCivil.Descripcion = ddlEstadoCivil.SelectedItem.Text;

            Provincia oProvincia = new Provincia();
            oProvincia.Id = ddlProvincias.SelectedIndex + 1;
            oProvincia.Descripcion = ddlProvincias.SelectedItem.Text;

            Ciudad oCiudad = new Ciudad();
            oCiudad.Id = Convert.ToInt32(ddlCiudades.SelectedItem.Value);
            oCiudad.Provincia = ddlProvincias.SelectedIndex + 1;
            oCiudad.Descripcion = ddlCiudades.SelectedItem.Text;
            
            Abogado oAbogado = new Abogado();
            if (!string.IsNullOrEmpty(lblIdAbogado.Text))
                oAbogado.Id = Convert.ToInt32(lblIdAbogado.Text);
            oAbogado.Nombre = txtNombre.Text;
            oAbogado.Apellido = txtApellido.Text;
            oAbogado.UserId = Membership.GetUser().ProviderUserKey.ToString();
            oAbogado.TipoDocumento = oTipoDocumento;
            oAbogado.Documento = Convert.ToInt32(txtDocumento.Text);
            oAbogado.FechaNacimiento = (Convert.ToDateTime(txtFechaNacimiento.Text)).Date;
            oAbogado.EstadoCivil = oEstadoCivil;
            oAbogado.Provincia = oProvincia;
            oAbogado.Ciudad = oCiudad;
            oAbogado.Direccion = txtDireccion.Text;
            oAbogado.Telefono = txtTelefono.Text;
            oAbogado.Celular = txtCelular.Text;

            Controller.guardarAbogado(oAbogado, pOperacion);

            Clean();

            Panel1.Visible = true;
            lblError.Visible = true;
            lblError.ForeColor = Color.Blue;
            lblError.Text = "Los Datos Del Abogado Se Guardaron Exitosamente";
        }
        catch (Exception)
        {
            Panel1.Visible = true;
            lblError.Visible = true;
            lblError.Text = "Ocurrio Un Error Al Guardar Los Datos Del Abogado";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Clean();
        txtNombre.Focus();
    }
}