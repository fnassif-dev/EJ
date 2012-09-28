using System;
using System.Drawing;
using System.Web.UI;
using Entities;
using BussinessLayer;

public partial class BuscarAbogados : System.Web.UI.Page
{
    //VARIABLES GLOBALES
    Abogado oAbogado = null;
    
    //METODOS ADICIONALES
    public void CleanSearch()
    {
        lblNombre.Text = string.Empty;
        lblApellido.Text = string.Empty;
        lblDocumento.Text = string.Empty;
        lblError.Text = string.Empty;
    }
    public void Clean()
    {
        txtBuscarNombre.Text = string.Empty;
        txtBuscarApellido.Text = string.Empty;
        txtBuscarDocumento.Text = string.Empty;        

        PanelOpciones.Visible = false;

        GridViewAbogados.SelectedIndex = -1;
        GridViewAbogados.Visible = false;
    }

    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Clean();
            CleanSearch();
            txtBuscarNombre.Focus();
        }
    }

    //EVENTOS CLICK
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CleanSearch();
        
        if (txtBuscarNombre.Text.Trim() != string.Empty)
            lblNombre.Text = txtBuscarNombre.Text;
        else if (txtBuscarApellido.Text.Trim() != string.Empty)
            lblApellido.Text = txtBuscarApellido.Text;
        else if (txtBuscarDocumento.Text.Trim() != string.Empty)
            lblDocumento.Text = txtBuscarDocumento.Text;

        GridViewAbogados.Visible = true;

        GridViewAbogados.DataSourceID = "ObjectDataSourceAbogados";
        GridViewAbogados.DataBind();
         
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Clean();
        CleanSearch();
        txtBuscarNombre.Focus();
    }
    protected void lnkModificarAbogado_Click(object sender, EventArgs e)
    {
        oAbogado = new Abogado();

        oAbogado.Id = int.Parse(GridViewAbogados.SelectedRow.Cells[3].Text);
        oAbogado.Nombre = GridViewAbogados.SelectedRow.Cells[4].Text;
        oAbogado.Apellido = GridViewAbogados.SelectedRow.Cells[5].Text;
        //oAbogado.TipoDocumento.Descripcion = GridViewAbogados.SelectedRow.Cells[6].Text;
        oAbogado.Documento = int.Parse(GridViewAbogados.SelectedRow.Cells[7].Text);
        //oAbogado.EstadoCivil.Descripcion = GridViewAbogados.SelectedRow.Cells[8].Text;
        //oAbogado.Provincia.Descripcion = GridViewAbogados.SelectedRow.Cells[9].Text;
        //oAbogado.Ciudad.Descripcion = GridViewAbogados.SelectedRow.Cells[10].Text;
        oAbogado.Direccion = GridViewAbogados.SelectedRow.Cells[11].Text;
        oAbogado.Telefono = GridViewAbogados.SelectedRow.Cells[12].Text;
        oAbogado.Celular = GridViewAbogados.SelectedRow.Cells[13].Text;

        Session["Abogado"] = oAbogado;

        Response.Redirect("~/NuevoAbogado.aspx");
    }
    protected void lnkAgregarEspecializaciones_Click(object sender, EventArgs e)
    {
        oAbogado = new Abogado();

        oAbogado.Id = int.Parse(GridViewAbogados.SelectedRow.Cells[3].Text);
        oAbogado.Nombre = GridViewAbogados.SelectedRow.Cells[4].Text;
        oAbogado.Apellido = GridViewAbogados.SelectedRow.Cells[5].Text;
        //oAbogado.TipoDocumento.Descripcion = GridViewAbogados.SelectedRow.Cells[6].Text;
        oAbogado.Documento = int.Parse(GridViewAbogados.SelectedRow.Cells[7].Text);
        //oAbogado.EstadoCivil.Descripcion = GridViewAbogados.SelectedRow.Cells[8].Text;
        //oAbogado.Provincia.Descripcion = GridViewAbogados.SelectedRow.Cells[9].Text;
        //oAbogado.Ciudad.Descripcion = GridViewAbogados.SelectedRow.Cells[10].Text;
        oAbogado.Direccion = GridViewAbogados.SelectedRow.Cells[11].Text;
        oAbogado.Telefono = GridViewAbogados.SelectedRow.Cells[12].Text;
        oAbogado.Celular = GridViewAbogados.SelectedRow.Cells[13].Text;

        Session["Abogado"] = oAbogado;

        Response.Redirect("~/Abogado/Especializaciones.aspx");
    }

    //EVENTOS DEL GridViewAbogados
    protected void GridViewAbogados_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        ObjectDataSourceAbogados.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewAbogados_RowDeleted(object sender, System.Web.UI.WebControls.GridViewDeletedEventArgs e)
    {
        lblError.Visible = true;
        
        if (e.Exception == null)
        {
            lblError.Text = "Abogado Eliminado";
            lblError.ForeColor = Color.Green;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.InsufficientPrivilegeException))
        {
            lblError.Text = "No Tiene Los Permisos Suficientes Para Eliminar El Abogado";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.AbogadoConExpedietesIniciados))
        {
            lblError.Text = "No Se Puede Eliminar El Abogado Seleccionado Ya Que Posee Expedientes Iniciados";
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
    protected void GridViewAbogados_SelectedIndexChanged(object sender, EventArgs e)
    {
        PanelOpciones.Visible = true;
    }
}