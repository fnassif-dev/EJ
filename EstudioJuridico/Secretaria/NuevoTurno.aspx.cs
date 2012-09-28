using System;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class Secretaria_NuevoTurno : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    Cliente oClienteSession = null;

    //METODOS ADICIONALES
    public void Clean()
    {
        txtApellido.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtDocumento.Text = string.Empty;
        txtNacimiento.Text = string.Empty;
    }

    //EVENTOPAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Cliente"] != null)
        {
            oClienteSession = (Cliente)Session["Cliente"];

            txtApellido.Text = oClienteSession.Apellido;
            txtNombre.Text = oClienteSession.Nombre;
            txtDocumento.Text = oClienteSession.Documento.ToString();
            txtNacimiento.Text = oClienteSession.FechaNacimiento.ToString();
        }
    }

    //EVENTOS CLICK
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            Cliente oCliente = new Cliente();
            oCliente = oClienteSession;

            Abogado oAbgado = new Abogado();
            oAbgado.Id = Convert.ToInt32(ddlAbogados.SelectedItem.Value);

            Turno oTurno = new Turno();
            oTurno.Cliente = oCliente;
            oTurno.Abogado = oAbgado;
            oTurno.FechaTurno = DateTime.Now;
            oTurno.Descripcion = txtDescripcion.Text;

            Controller.guardarTurno(oTurno, "Insert");

            lblError.Visible = true;
            lblError.ForeColor = Color.Green;
            lblError.Text = "Se Ha Cargado Correctamente El Turno";
        }
        catch(Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Ocurrio Un Problema Al Cargar El Turno";
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Clean();
    }
}