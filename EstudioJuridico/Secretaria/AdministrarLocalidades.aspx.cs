using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class AdministrarLocalidades : System.Web.UI.Page
{
    //METODOS ADICIONALES
    public void CleanProvincias()
    {
        txtProvincia.Text = string.Empty;
    }
    public void CleanCiudades()
    {
        txtCiudad.Text = string.Empty;
    }
    public void EnableProvincias(bool x)
    {
        txtProvincia.Enabled = x;

        btnCargarProvincia.Enabled = x;
    }
    public void EnableCiudades(bool x)
    {
        txtCiudad.Enabled = x;

        btnCargarCiudades.Enabled = x;
        btnLimpiarCiudades.Enabled = x;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        EnableCiudades(false);
    }

    //EVENTOS CLICK
    protected void btnCargarProvincia_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch(Exception)
        {

        }
    }
    protected void btnLimpiarProvincia_Click(object sender, EventArgs e)
    {
        CleanProvincias();
        CleanCiudades();
        lblError.Text = string.Empty;
        GridViewCiudades.Visible = false;
    }
    protected void btnCargarCiudades_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception)
        {

        }
    }
    protected void btnLimpiarCiudades_Click(object sender, EventArgs e)
    {
        CleanCiudades();
    }

    //EVENTOS GRIDVIEWPROVINCIAS
    protected void GridViewProvincias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewCiudades.Visible = true;
        GridViewCiudades.DataSourceID = "ObjectDataSourceCiudades";
        GridViewCiudades.DataBind();

        CleanProvincias();
        EnableProvincias(false);
        EnableCiudades(true);

        if (e.CommandName == "Select")
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            lblProvinciaId.Text = GridViewProvincias.Rows[rowIndex].Cells[2].Text;
            txtProvincia.Text = HttpUtility.HtmlDecode(GridViewProvincias.Rows[rowIndex].Cells[3].Text);

            GridViewCiudades.DataBind();
        }
    }
    protected void GridViewProvincias_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjectDataSourceProvincias.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewProvincias_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            lblError.Visible = true;
            lblError.Text = "Provincia Eliminada";
            lblError.ForeColor = Color.Green;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.InsufficientPrivilegeException))
        {
            lblError.Visible = true;
            lblError.Text = "No Tiene Los Permisos Suficientes Para Eliminar La Provincia";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.ClienteConExpedientes))
        {
            lblError.Visible = true;
            lblError.Text = "No Se Puede Eliminar La Provincia Seleccionada Ya Que Posee Ciudades Asociadas A La Misma";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Se Ha Producido Un Error Inesperado";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
    }

    //EVENTOS GRIDVIEWCIUDADES
    protected void GridViewCiudades_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjectDataSourceCiudades.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewCiudades_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            lblError.Visible = true;
            lblError.Text = "Ciudad Eliminada";
            lblError.ForeColor = Color.Green;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.InsufficientPrivilegeException))
        {
            lblError.Visible = true;
            lblError.Text = "No Tiene Los Permisos Suficientes Para Eliminar La Ciudad";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.ClienteConExpedientes))
        {
            lblError.Visible = true;
            lblError.Text = "No Se Puede Eliminar La Ciudad Seleccionada Ya Que Existen Clientes / Abogados Asociados A La Misma";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Se Ha Producido Un Error Inesperado";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
    }
}