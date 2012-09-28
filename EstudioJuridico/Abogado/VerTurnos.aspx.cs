using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using Entities;
using BussinessLayer;

public partial class Abogado_VerTurnos : System.Web.UI.Page
{
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Abogado oAbogado = Controller.abogadoLogueado(Membership.GetUser().ProviderUserKey.ToString());

            lblAbogadoId.Text = oAbogado.Id.ToString();
        }
    }

    //EVENTOS GRISVIEWTURNOS
    protected void GridViewTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Turno oTurno = new Turno();

        oTurno.Id = int.Parse(e.OldValues["Id"].ToString());
        oTurno.Ausente = Convert.ToBoolean(e.NewValues["Ausente"].ToString());
        oTurno.Atendido = Convert.ToBoolean(e.NewValues["Atendido"].ToString());

        e.NewValues.Clear();
        e.NewValues.Add("pTurno", oTurno);
        e.NewValues.Add("pOperacion", "Update");
    }
}