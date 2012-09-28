using System;
using System.Web.UI;
using System.Drawing;
using Microsoft.Reporting.WebForms;

public partial class Informes_Informes : System.Web.UI.Page
{
    //METODOS ADICIONALES
    public void Clean()
    {
        lblEstado.Text = "1";
        txtEstado.Text = "1";

        txtFechaInferior.Text = DateTime.Now.Date.ToShortDateString();
        txtFechaSuperior.Text = DateTime.Now.Date.ToShortDateString();

        ReportViewer1.Visible = false;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Clean();
        }
    }

    //EVENTOS CLICK
    protected void btnCargar_Click(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;
        lblError.Visible = false;

        lblFechaInferior.Text = txtFechaInferior.Text;
        lblFechaSuperior.Text = txtFechaSuperior.Text;
        lblEstado.Text = txtEstado.Text;

        ReportViewer1.LocalReport.ReportPath = "Informes/rptConsultasPorEstado.rdlc";
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource rdsConsultasPorEstado = new ReportDataSource();
        rdsConsultasPorEstado.Name = "DataSet1";
        rdsConsultasPorEstado.DataSourceId = "ObjectDataSourceConsultasPorEstado";

        ReportViewer1.LocalReport.DataSources.Add(rdsConsultasPorEstado);

        ObjectDataSourceConsultasPorEstado.SelectMethod = "GetData";

        ReportViewer1.Visible = true;
        ReportViewer1.LocalReport.Refresh();
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Clean();
    }
}