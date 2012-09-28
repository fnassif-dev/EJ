using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BussinessLayer;

public partial class AdministrarEstadosCiviles : System.Web.UI.Page
{
    //METODOS ADICIONALES
    public void Clean()
    {
        txtDescripcion.Text = string.Empty;

        lblError.Visible = false;
    }
    
    //EVENTO PAGE LOAD 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Clean();
            txtDescripcion.Focus();
        }
    }

    //EVENTOS CLICK
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            EstadoCivil oEstadoCivil = new EstadoCivil();

            oEstadoCivil.Descripcion = txtDescripcion.Text;

            Controller.guardarEstadoCivil(oEstadoCivil, "Insertar");

            Clean();

            lblError.Visible = true;
            lblError.ForeColor = Color.Green;
            lblError.Text = "La Descripcion Del Estado Civil Se Cargo Con Exito";

            GridViewEstadoCivil.DataBind();
        }
        catch(Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "No Se Pudo Cargar La Descripcion Del Estado Civil";
        }
    }

    //EVENTOS DEL GridViewEstadoCivil
    protected void GridViewEstadoCivil_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjectDataSourceEstadoCivil.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewEstadoCivil_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        lblError.Visible = true;

        if (e.Exception == null)
        {
            lblError.ForeColor = Color.Green;
            lblError.Text = "El Estado Civil Ha Sido Borrado Exitosamente";
        }
        else
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "No Se Pudo Borrar El Estado Civil";
            e.ExceptionHandled = true;
        }
    }
    protected void GridViewEstadoCivil_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        EstadoCivil oEstadoCivil = new EstadoCivil();

        oEstadoCivil.Id = int.Parse(e.OldValues["Id"].ToString());
        oEstadoCivil.Descripcion = e.NewValues["Descripcion"].ToString();

        e.NewValues.Clear();

        e.NewValues.Add("pEstadoCivil", oEstadoCivil);
        e.NewValues.Add("pOperacion", "Update");
    }
}