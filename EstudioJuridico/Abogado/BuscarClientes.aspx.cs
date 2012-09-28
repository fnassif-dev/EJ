using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class BuscarClientes : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    Cliente oCliente = null;
    
    //METODOS ADICIONALES
    public void CleanSearch()
    {
        lblNombre.Text = string.Empty;
        lblApellido.Text = string.Empty;
        lblDocumento.Text = string.Empty;
        lblError.Text = string.Empty;

        PanelOpciones.Visible = false;
    }
    public void Clean()
    {
        txtBuscarNombre.Text = string.Empty;
        txtBuscarApellido.Text = string.Empty;
        txtBuscarDocumento.Text = string.Empty;

        GridViewClientes.SelectedIndex = -1;
        GridViewClientes.Visible = false;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Clean();
            CleanSearch();
        }
    }

    //EVENTOS CLICK DE BUTTONS
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CleanSearch();
        
        if (txtBuscarNombre.Text.Trim() != string.Empty)
            lblNombre.Text = txtBuscarNombre.Text;
        else if (txtBuscarApellido.Text.Trim() != string.Empty)
            lblApellido.Text = txtBuscarApellido.Text;
        else if (txtBuscarDocumento.Text.Trim() != string.Empty)
            lblDocumento.Text = txtBuscarDocumento.Text;
        
        GridViewClientes.Visible = true;

        GridViewClientes.DataSourceID = "ObjectDataSourceClientes";
        GridViewClientes.DataBind();
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Clean();
        CleanSearch();
        txtBuscarNombre.Focus();
    }
    protected void lnkModificarCliente_Click(object sender, EventArgs e)
    {
        TipoDocumento oTipoDocumento = new TipoDocumento();
        oTipoDocumento.Descripcion = ((Label)GridViewClientes.SelectedRow.FindControl("TipoDocumento")).Text;

        EstadoCivil oEstadoCivil = new EstadoCivil();
        oEstadoCivil.Descripcion = ((Label)GridViewClientes.SelectedRow.FindControl("EstadoCivil")).Text;

        Provincia oProvincia = new Provincia();
        oProvincia.Descripcion = ((Label)GridViewClientes.SelectedRow.FindControl("Provincia")).Text;

        Ciudad oCiudad = new Ciudad();
        oCiudad.Descripcion = ((Label)GridViewClientes.SelectedRow.FindControl("Ciudad")).Text;

        oCliente = new Cliente();

        oCliente.Id = int.Parse(GridViewClientes.SelectedRow.Cells[2].Text);
        oCliente.Nombre = GridViewClientes.SelectedRow.Cells[3].Text;
        oCliente.Apellido = GridViewClientes.SelectedRow.Cells[4].Text;
        oCliente.TipoDocumento = oTipoDocumento;
        oCliente.Documento = int.Parse(GridViewClientes.SelectedRow.Cells[6].Text);
        oCliente.FechaNacimiento = DateTime.Parse(GridViewClientes.SelectedRow.Cells[7].Text);
        oCliente.EstadoCivil = oEstadoCivil;
        oCliente.Ocupacion = GridViewClientes.SelectedRow.Cells[9].Text;
        oCliente.Sexo = GridViewClientes.SelectedRow.Cells[10].Text;
        oCliente.Nacionalidad = GridViewClientes.SelectedRow.Cells[11].Text;
        oCliente.Provincia = oProvincia;
        oCliente.Ciudad = oCiudad;
        oCliente.Direccion = GridViewClientes.SelectedRow.Cells[14].Text;
        oCliente.Telefono = GridViewClientes.SelectedRow.Cells[15].Text;
        oCliente.Celular = GridViewClientes.SelectedRow.Cells[16].Text;
        oCliente.Observaciones = GridViewClientes.SelectedRow.Cells[17].Text;

        Session["Cliente"] = oCliente;

        Response.Redirect("~/NuevoCliente.aspx");
    }
    protected void lnkNuevaConsulta_Click(object sender, EventArgs e)
    {
        TipoDocumento oTipoDocumento = new TipoDocumento();
        oTipoDocumento.Descripcion = ((Label)GridViewClientes.SelectedRow.FindControl("TipoDocumento")).Text;

        EstadoCivil oEstadoCivil = new EstadoCivil();
        oEstadoCivil.Descripcion = ((Label)GridViewClientes.SelectedRow.FindControl("EstadoCivil")).Text;

        Provincia oProvincia = new Provincia();
        oProvincia.Descripcion = ((Label)GridViewClientes.SelectedRow.FindControl("Provincia")).Text;

        Ciudad oCiudad = new Ciudad();
        oCiudad.Descripcion = ((Label)GridViewClientes.SelectedRow.FindControl("Ciudad")).Text;

        oCliente = new Cliente();

        oCliente.Id = int.Parse(GridViewClientes.SelectedRow.Cells[2].Text);
        oCliente.Nombre = GridViewClientes.SelectedRow.Cells[3].Text;
        oCliente.Apellido = GridViewClientes.SelectedRow.Cells[4].Text;
        oCliente.TipoDocumento = oTipoDocumento;
        oCliente.Documento = int.Parse(GridViewClientes.SelectedRow.Cells[6].Text);
        oCliente.FechaNacimiento = DateTime.Parse(GridViewClientes.SelectedRow.Cells[7].Text);
        oCliente.EstadoCivil = oEstadoCivil;
        oCliente.Ocupacion = GridViewClientes.SelectedRow.Cells[9].Text;
        oCliente.Sexo = GridViewClientes.SelectedRow.Cells[10].Text;
        oCliente.Nacionalidad = GridViewClientes.SelectedRow.Cells[11].Text;
        oCliente.Provincia = oProvincia;
        oCliente.Ciudad = oCiudad;
        oCliente.Direccion = GridViewClientes.SelectedRow.Cells[14].Text;
        oCliente.Telefono = GridViewClientes.SelectedRow.Cells[15].Text;
        oCliente.Celular = GridViewClientes.SelectedRow.Cells[16].Text;
        oCliente.Observaciones = GridViewClientes.SelectedRow.Cells[17].Text;

        Session["Cliente"] = oCliente;

        Response.Redirect("~/NuevaConsulta.aspx");
    }
    protected void lnkBuscarConsultas_Click(object sender, EventArgs e)
    {
        Session["NombreCliente"] = GridViewClientes.SelectedRow.Cells[3].Text;

        Response.Redirect("~/BuscarConsultas.aspx");
    }

    //EVENTOS DE GridViewClientes
    protected void GridViewClientes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        ObjectDataSourceClientes.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewClientes_RowDeleted(object sender, System.Web.UI.WebControls.GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            lblError.Text = "Cliente Eliminado";
            lblError.ForeColor = Color.Green;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.InsufficientPrivilegeException))
        {
            lblError.Text = "No Tiene Los Permisos Suficientes Para Eliminar El Cliente";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.ClienteConExpedientes))
        {
            lblError.Text = "No Se Puede Eliminar El Cliente Seleccionado Ya Que Posee Expedientes Iniciados";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else
        {
            lblError.Text = "Se Ha Producido Un Error Inesperado";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
    }
    protected void GridViewClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        PanelOpciones.Visible = true;
    }
}