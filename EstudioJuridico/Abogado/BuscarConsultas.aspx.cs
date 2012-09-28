using System;
using System.Web.UI.WebControls;
using System.Drawing;
using BussinessLayer;

public partial class BuscarConsultas : System.Web.UI.Page
{
    //METODOS ADICIONALES
    public void CleanSearch()
    {
        lblCliente.Text = string.Empty;
        lblAbogado.Text = string.Empty;
        lblFecha.Text = string.Empty;
        lblError.Text = string.Empty;
    }
    public void Clean()
    {
        txtBuscarCliente.Text = string.Empty;
        txtBuscarAbogado.Text = string.Empty;
        txtBuscarFecha.Text = string.Empty;

        PanelOpciones.Visible = false;

        GridViewConsultas.SelectedIndex = -1;
        GridViewConsultas.Visible = false;
    }

    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NombreCliente"] != null)
        {
            lblCliente.Text = (string)Session["NombreCliente"];

            GridViewConsultas.DataSourceID = "ObjectDataSourceConsultas";
            GridViewConsultas.DataBind();
        }
    }

    //EVENTOS CLICK
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CleanSearch();

        if (txtBuscarCliente.Text.Trim() != string.Empty)
            lblCliente.Text = txtBuscarCliente.Text;
        else if (txtBuscarAbogado.Text.Trim() != string.Empty)
            lblAbogado.Text = txtBuscarAbogado.Text;
        else if (txtBuscarFecha.Text.Trim() != string.Empty)
            lblFecha.Text = txtBuscarFecha.Text;
        
        GridViewConsultas.Visible = true;

        GridViewConsultas.DataSourceID = "ObjectDataSourceConsultas";
        GridViewConsultas.DataBind();
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        CleanSearch();
        Clean();
        txtBuscarCliente.Focus();
    }
    protected void lnkModificarConsulta_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Abogado/NuevaConsulta.aspx");
    }
    protected void lnkIniciarExpediente_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Abogado/NuevoExpediente.aspx");
    }

    //EVENTOS DE GridViewConsultas
    protected void GridViewConsultas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjectDataSourceConsultas.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewConsultas_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            lblError.Text = "Consulta Eliminada";
            lblError.ForeColor = Color.Green;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.InsufficientPrivilegeException))
        {
            lblError.Text = "No Tiene Los Permisos Suficientes Para Eliminar La Consulta";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.ClienteConExpedientes))
        {
            lblError.Text = "No Se Puede Eliminar La Consulta Seleccionado Ya Que Posee Expedientes Iniciados";
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
    protected void GridViewConsultas_SelectedIndexChanged(object sender, EventArgs e)
    {
        PanelOpciones.Visible = true;
    }
}