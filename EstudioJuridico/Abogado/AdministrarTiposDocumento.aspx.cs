using System;
using System.Drawing;
using Entities;
using BussinessLayer;

public partial class AgregarTiposDocumento : System.Web.UI.Page
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
            TipoDocumento oTipoDocumento = new TipoDocumento();

            oTipoDocumento.Descripcion = txtDescripcion.Text;

            Controller.guardarTipoDocumento(oTipoDocumento, "Insert");

            Clean();

            lblError.Visible = true;
            lblError.ForeColor = Color.Green;
            lblError.Text = "La descripcion del Tipo de Documento se cargo con exito";

            GridViewTipoDocumento.DataBind();
        }
        catch(Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "No se pudo cargar la descripcion del Tipo de Documento";
        }
    }

    //EVENTOS GRIDVIEWTIPODOCUMENTO
    protected void GridViewTipoDocumento_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        ObjectDataSourceTipoDocumento.DeleteParameters["pId"].DefaultValue = e.Values["Id"].ToString();
    }
    protected void GridViewTipoDocumento_RowDeleted(object sender, System.Web.UI.WebControls.GridViewDeletedEventArgs e)
    {
        lblError.Visible = true;

        if (e.Exception == null)
        {
            lblError.ForeColor = Color.Green;
            lblError.Text = "El Tipo de Documento ha sido borrado exitosamente";
        }
        else
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "No se pudo borrar el Tipo de Documento";
            e.ExceptionHandled = true;
        }
    }
    protected void GridViewTipoDocumento_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        TipoDocumento oTipoDocumento = new TipoDocumento();

        oTipoDocumento.Id = int.Parse(e.OldValues["Id"].ToString());
        oTipoDocumento.Descripcion = e.NewValues["Descripcion"].ToString();

        e.NewValues.Clear();
        e.NewValues.Add("pTipoDocumento", oTipoDocumento);
        e.NewValues.Add("pOperacion", "Update");
    }
}