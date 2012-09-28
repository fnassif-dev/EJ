using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class BuscarExpedientes : System.Web.UI.Page
{
    //METODOS ADICIONALES
    public void Clean()
    {
        txtJuzgado.Text = string.Empty;
        txtAbogado.Text = string.Empty;
        txtFechaInicio.Text = string.Empty;

        PanelOpciones.Visible = false;

        GridViewExpedientes.SelectedIndex = -1;
        GridViewExpedientes.Visible = false;
    }
    public void CleanSearch()
    {
        lblAbogado.Text = string.Empty;
        lblJuzgado.Text = string.Empty;
        lblFecha.Text = string.Empty;
    }    
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Clean();
        }
    }

    //EVENTOS CLICK DE BUTTONS
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CleanSearch();

        if (txtAbogado.Text.Trim() != string.Empty)
            lblAbogado.Text = txtAbogado.Text;
        else if (txtJuzgado.Text.Trim() != string.Empty)
            lblJuzgado.Text = txtJuzgado.Text;
        else if (txtFechaInicio.Text.Trim() != string.Empty)
            lblFecha.Text = txtFechaInicio.Text;

        if (chkExpedientesCerrados.Checked == true)
        {
            GridViewExpedientes.Visible = true;

            GridViewExpedientes.DataSourceID = "ObjectDataSourceExpedientesCerrados";
            GridViewExpedientes.DataBind();
        }
        else
        {
            GridViewExpedientes.Visible = true;

            GridViewExpedientes.DataSourceID = "ObjectDataSourceExpedientes";
            GridViewExpedientes.DataBind();
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Clean();
    }

    //EVENTOS CLICK
    protected void lnkModificarExpediente_Click(object sender, EventArgs e)
    {
        Juzgado oJuzgado = new Juzgado();
        oJuzgado.Nombre = ((Label)GridViewExpedientes.SelectedRow.FindControl("Juzgado")).Text;

        Secretaria oSecretaria = new Secretaria();
        oSecretaria.Nombre = ((Label)GridViewExpedientes.SelectedRow.FindControl("Secretaria")).Text;

        Expediente oExpediente = new Expediente();

        oExpediente.Id = int.Parse(GridViewExpedientes.SelectedRow.Cells[2].Text);
        oExpediente.Caratula = GridViewExpedientes.SelectedRow.Cells[3].Text;
        oExpediente.Descripcion = GridViewExpedientes.SelectedRow.Cells[4].Text;
        oExpediente.Actores = GridViewExpedientes.SelectedRow.Cells[5].Text;
        oExpediente.Consulta = Controller.traerConsultaAsociada(oExpediente.Id);
        oExpediente.Juzgado = oJuzgado;
        oExpediente.Secretaria = oSecretaria;
        oExpediente.FechaInicio = Convert.ToDateTime(GridViewExpedientes.SelectedRow.Cells[8].Text);

        Session["Expediente"] = oExpediente;
        
        Response.Redirect("~/Abogado/NuevoExpediente.aspx");
    }
    protected void lnkAgregarEscritos_Click(object sender, EventArgs e)
    {        
        Juzgado oJuzgado = new Juzgado();
        oJuzgado.Nombre = ((Label)GridViewExpedientes.SelectedRow.FindControl("Juzgado")).Text;

        Secretaria oSecretaria = new Secretaria();
        oSecretaria.Nombre = ((Label)GridViewExpedientes.SelectedRow.FindControl("Secretaria")).Text;
        
        Expediente oExpediente = new Expediente();

        oExpediente.Id = int.Parse(GridViewExpedientes.SelectedRow.Cells[2].Text);
        oExpediente.Caratula = GridViewExpedientes.SelectedRow.Cells[3].Text;
        oExpediente.Descripcion = GridViewExpedientes.SelectedRow.Cells[4].Text;
        oExpediente.Actores = GridViewExpedientes.SelectedRow.Cells[5].Text;
        oExpediente.Consulta = Controller.traerConsultaAsociada(oExpediente.Id);
        oExpediente.Juzgado = oJuzgado;
        oExpediente.Secretaria = oSecretaria;
        oExpediente.FechaInicio = Convert.ToDateTime(GridViewExpedientes.SelectedRow.Cells[8].Text);

        Session["Expediente"] = oExpediente;
        
        Response.Redirect("~/Abogado/Escritos.aspx");
    }
    protected void lnkVerEscritos_Click(object sender, EventArgs e)
    {
        Juzgado oJuzgado = new Juzgado();
        oJuzgado.Nombre = ((Label)GridViewExpedientes.SelectedRow.FindControl("Juzgado")).Text;

        Secretaria oSecretaria = new Secretaria();
        oSecretaria.Nombre = ((Label)GridViewExpedientes.SelectedRow.FindControl("Secretaria")).Text;

        Expediente oExpediente = new Expediente();

        oExpediente.Id = int.Parse(GridViewExpedientes.SelectedRow.Cells[2].Text);
        oExpediente.Caratula = GridViewExpedientes.SelectedRow.Cells[3].Text;
        oExpediente.Descripcion = GridViewExpedientes.SelectedRow.Cells[4].Text;
        oExpediente.Actores = GridViewExpedientes.SelectedRow.Cells[5].Text;
        oExpediente.Juzgado = oJuzgado;
        oExpediente.Secretaria = oSecretaria;
        oExpediente.FechaInicio = Convert.ToDateTime(GridViewExpedientes.SelectedRow.Cells[8].Text);

        Session["Expediente"] = oExpediente;

        Response.Redirect("~/Abogado/VerEscritos.aspx");
    }

    //EVENTOS GRIDVIEWEXPEDIENTES
    protected void GridViewExpedientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjectDataSourceExpedientes.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewExpedientes_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            lblError.Text = "Expediente Eliminado";
            lblError.ForeColor = Color.Green;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.InsufficientPrivilegeException))
        {
            lblError.Text = "No Tiene Los Permisos Suficientes Para Eliminar El Expediente";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.ClienteConExpedientes))
        {
            lblError.Text = "No Se Puede Eliminar El Expediente Seleccionado Ya Que Aun Se Encuentra Abierto";
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
    protected void GridViewExpedientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        PanelOpciones.Visible = true;
    }
}