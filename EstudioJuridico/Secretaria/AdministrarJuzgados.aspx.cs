using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class AdministrarJuzgados : System.Web.UI.Page
{
    //METODOS ADICIONALES
    public void CleanJuzgados()
    {
        txtNombreJuzgado.Text = string.Empty;
        txtJuez.Text = string.Empty;
        txtDireccion.Text = string.Empty;
        txtTelefono.Text = string.Empty;

        lblError.Text = string.Empty;
    }
    public void CleanSecretarias()
    {
        txtNombreSecretaria.Text = string.Empty;
        txtSecretario.Text = string.Empty;

        lblError.Text = string.Empty;
    }
    public void EnableJuzgados(bool x)
    {
        txtNombreJuzgado.Enabled = x;
        txtJuez.Enabled = x;
        txtDireccion.Enabled = x;
        txtTelefono.Enabled = x;

        btnCargarJuzgado.Enabled = x;
    }
    public void EnableSecretarias(bool x)
    {
        txtNombreSecretaria.Enabled = x;
        txtSecretario.Enabled = x;

        btnCargarSecretaria.Enabled = x;
        btnLimpiarSecretaria.Enabled = x;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        EnableSecretarias(false);
    }

    //EVENTOS CLICK
    protected void btnCargarJuzgado_Click(object sender, EventArgs e)
    {
        try
        {
            Juzgado oJuzgado = new Juzgado();

            oJuzgado.Nombre = txtNombreJuzgado.Text;
            oJuzgado.Juez = txtJuez.Text;
            oJuzgado.Direccion = txtDireccion.Text;
            oJuzgado.Telefono = Convert.ToInt32(txtTelefono.Text);

            Controller.guardarJuzgado(oJuzgado, "Insert");

            lblError.Visible = true;
            lblError.ForeColor = Color.Green;
            lblError.Text = "Los Datos Del Juzgado Se Cargaron Exitosamente";

            GridViewJuzgados.DataBind();
        }
        catch(Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Ocurrio Un Error Al Cargar Los Datos Del Juzgado";
        }
    }
    protected void btnLimpiarJuzgado_Click(object sender, EventArgs e)
    {
        CleanJuzgados();
        CleanSecretarias();
        EnableJuzgados(true);
        EnableSecretarias(false);
        GridViewJuzgados.SelectedIndex = -1;
        lblJuzgadoId.Text = "0";
    }
    protected void btnCargarSecretaria_Click(object sender, EventArgs e)
    {
        try
        {
            Secretaria oSecretaria = new Secretaria();

            oSecretaria.Nombre = txtNombreSecretaria.Text;
            oSecretaria.Secretario = txtSecretario.Text;
            oSecretaria.Juzgado = Convert.ToInt32(lblJuzgadoId.Text);

            Controller.guardarSecretaria(oSecretaria, "Insert");

            lblError.Visible = true;
            lblError.ForeColor = Color.Green;
            lblError.Text = "Los Datos De La Secretaría Se Cargaron Exitosamente";

            GridViewSecretarias.DataBind();
        }
        catch (Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Ocurrio Un Error Al Cargar Los Datos De La Secretaria";
        }
    }
    protected void btnLimpiarSecretaria_Click(object sender, EventArgs e)
    {
        CleanSecretarias();
    }

    //EVENTOS GRIDVIEWJUZGADOS
    protected void GridViewJuzgados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjectDataSourceJuzgados.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewJuzgados_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            lblError.Visible = true;
            lblError.Text = "Juzgado Eliminada";
            lblError.ForeColor = Color.Green;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.InsufficientPrivilegeException))
        {
            lblError.Visible = true;
            lblError.Text = "No Tiene Los Permisos Suficientes Para Eliminar El Juzgado";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.JuzgadoConSecretariasException))
        {
            lblError.Visible = true;
            lblError.Text = "No Se Puede Eliminar El Juzgado Seleccionado Ya Que Posee Secretarias Asociadas";
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
    protected void GridViewJuzgados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewSecretarias.DataSourceID = "ObjectDataSourceSecretarias";
        GridViewSecretarias.DataBind();
        
        CleanJuzgados();
        EnableJuzgados(false);
        EnableSecretarias(true);

        if (e.CommandName == "Select")
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            lblJuzgadoId.Text = GridViewJuzgados.Rows[rowIndex].Cells[2].Text;
            txtNombreJuzgado.Text = HttpUtility.HtmlDecode(GridViewJuzgados.Rows[rowIndex].Cells[3].Text);
            txtJuez.Text = GridViewJuzgados.Rows[rowIndex].Cells[4].Text;
            txtDireccion.Text = GridViewJuzgados.Rows[rowIndex].Cells[5].Text;
            txtTelefono.Text = GridViewJuzgados.Rows[rowIndex].Cells[6].Text;

            GridViewSecretarias.DataBind();
        }
    }

    //EVENTOS GRIDVIEWSECRETARIAS
    protected void GridViewSecretarias_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjectDataSourceSecretarias.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewSecretarias_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            lblError.Visible = true;
            lblError.Text = "Secretaria Eliminada";
            lblError.ForeColor = Color.Green;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.InsufficientPrivilegeException))
        {
            lblError.Visible = true;
            lblError.Text = "No Tiene Los Permisos Suficientes Para Eliminar La Secretaria";
            lblError.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else if (e.Exception.InnerException.GetType() == typeof(Controller.ClienteConExpedientes))
        {
            lblError.Visible = true;
            lblError.Text = "No Se Puede Eliminar La Secretaria Seleccionada Ya Que Posee Expedientes Asociadas A La Misma";
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