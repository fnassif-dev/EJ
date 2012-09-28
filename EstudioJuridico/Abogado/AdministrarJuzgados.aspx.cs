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
    public void Clean()
    {
        txtNombreJuzgado.Text = string.Empty;
        txtJuez.Text = string.Empty;
        txtDireccion.Text = string.Empty;
        txtTelefono.Text = string.Empty;

        txtNombreSecretaria.Text = string.Empty;
        txtSecretario.Text = string.Empty;
    }
    public void BlockJuzgado(bool x)
    {
        txtNombreJuzgado.Enabled = x;
        txtJuez.Enabled = x;
        txtDireccion.Enabled = x;
        txtTelefono.Enabled = x;
    }
    public void BlockSecretarias(bool x)
    {
        txtNombreSecretaria.Enabled = x;
        txtSecretario.Enabled = x;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        BlockSecretarias(true);
    }

    //EVENTOS CLICK
    protected void btnCargarJuzgado_Click(object sender, EventArgs e)
    {
        try
        {
            Juzgado oJuzgado = new Juzgado();


        }
        catch(Exception)
        {
            Panel1.Visible = true;
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Ocurrio Un Error Al Cargar Los Datos Del Juzgado";
        }
    }
    protected void btnLimpiarJuzgado_Click(object sender, EventArgs e)
    {
        Clean();
    }
    protected void btnCargarSecretaria_Click(object sender, EventArgs e)
    {
        try
        {
            Secretaria oSecretaria = new Secretaria();


        }
        catch (Exception)
        {
            Panel1.Visible = true;
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Ocurrio Un Error Al Cargar Los Datos Del Juzgado";
        }
    }
    protected void btnLimpiarSecretaria_Click(object sender, EventArgs e)
    {
        Clean();
    }

    //EVENTOS GRIDVIEWJUZGADOS
    protected void GridViewJuzgados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridViewJuzgados_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void GridViewJuzgados_SelectedIndexChanged(object sender, EventArgs e)
    {
        BlockSecretarias(false);
    }
}