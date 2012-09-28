using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class Clientes : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    string pOperacion;
    Cliente oClienteSession = null;
    
    //METODOS ADICIONALES
    public void Clean()
    {
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        ddlTipoDocumento.SelectedIndex = -1;
        txtDocumento.Text = string.Empty;
        txtFechaNacimiento.Text = string.Empty;
        ddlEstadoCivil.SelectedIndex = -1;
        txtOcupacion.Text = string.Empty;
        rdtMasculino.Checked = true;
        txtNacionalidad.Text = string.Empty;
        ddlProvincias.SelectedIndex = -1;
        ddlCiudades.SelectedIndex = -1;
        txtDireccion.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCelular.Text = string.Empty;
        txtObservaciones.Text = string.Empty;
        lblError.Text = string.Empty;
        lblError.Visible = false;
    }
    
    //METODO LOAD
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (Session["Cliente"] != null)
        {
            ddlTipoDocumento.DataBind();
            ddlEstadoCivil.DataBind();
            ddlProvincias.DataBind();
            
            oClienteSession = (Cliente)Session["Cliente"];

            lblIdCliente.Text = oClienteSession.Id.ToString();
            txtNombre.Text = oClienteSession.Nombre;
            txtApellido.Text = oClienteSession.Apellido;
            ddlTipoDocumento.Items.FindByText(oClienteSession.TipoDocumento.Descripcion).Selected = true;
            txtDocumento.Text = oClienteSession.Documento.ToString();
            txtFechaNacimiento.Text = oClienteSession.FechaNacimiento.ToString();
            ddlEstadoCivil.Items.FindByText(oClienteSession.EstadoCivil.Descripcion).Selected = true;
            txtOcupacion.Text = oClienteSession.Ocupacion;
            if (oClienteSession.Sexo == "Masculino")
                rdtMasculino.Checked = true;
            else
                rdtFemenino.Checked = true;
            txtNacionalidad.Text = oClienteSession.Nacionalidad;
            ddlProvincias.Items.FindByText(oClienteSession.Provincia.Descripcion).Selected = true;
            //ddlCiudades.Items.FindByText(oClienteSession.Ciudad.Descripcion).Selected = true;
            txtDireccion.Text = oClienteSession.Direccion;
            txtTelefono.Text = oClienteSession.Telefono;
            txtCelular.Text = oClienteSession.Celular;
            txtObservaciones.Text = oClienteSession.Observaciones;

            Session.Abandon();
        }
    }

    //EVENTOS CLICK BUTTNOS
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (lblIdCliente.Text != string.Empty)
        {
            pOperacion = "Update";
        }
        else
        {
            pOperacion = "Insert";
            lblIdCliente.Text = "0";
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
            
            Cliente oCliente = new Cliente();
            oCliente.Id = Convert.ToInt32(lblIdCliente.Text);
            oCliente.Nombre = txtNombre.Text;
            oCliente.Apellido = txtApellido.Text;
            oCliente.TipoDocumento = oTipoDocumento;
            oCliente.Documento = Convert.ToInt32(txtDocumento.Text);
            oCliente.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            oCliente.EstadoCivil = oEstadoCivil;
            oCliente.Ocupacion = txtOcupacion.Text;
            if (rdtMasculino.Checked == true)
                oCliente.Sexo = "Masculino";
            else
                oCliente.Sexo = "Femenino";
            oCliente.Nacionalidad = txtNacionalidad.Text;
            oCliente.Provincia = oProvincia;
            oCliente.Ciudad = oCiudad;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.Telefono = txtTelefono.Text;
            oCliente.Celular = txtCelular.Text;
            oCliente.Observaciones = txtObservaciones.Text;

            Controller.guardarCliente(oCliente, pOperacion);

            Clean();

            lblError.Visible = true;
            lblError.ForeColor = Color.Blue;
            lblError.Text = "El Cliente Se Guardo Exitosamente";            
        }
        catch (Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Ocurrio Un Error Al Guardar Los Datos Del Cliente";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Clean();
        txtNombre.Focus();
    }
}