using System;
using System.Web.UI;
using System.Drawing;
using Microsoft.Reporting.WebForms;

public partial class Informes_InformePrueba : System.Web.UI.Page
{   
    //METODOS ADICIONALES
    public void CleanSearch()
    {
        rbtAbogados.Checked = false;
        rbtClientes.Checked = false;

        lblError.Visible = false;
        lblNombre.Visible = false;
        lblApellido.Visible = false;
        lblDocumento.Visible = false;

        ReportViewer1.Visible = false;
    }
    
    //EVENTO PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CleanSearch();
        }
    }

    //EVENTOS CLICK
    protected void btnReporte_Click(object sender, EventArgs e)
    {
        if (rbtAbogados.Checked == true)
        {
            ReportViewer1.LocalReport.ReportPath = "Informes/Report.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rdsAbogados = new ReportDataSource();
            rdsAbogados.Name = "BuscarAbogados";
            rdsAbogados.DataSourceId = "ObjectDataSourceAbogados";

            ReportViewer1.LocalReport.DataSources.Add(rdsAbogados);

            ObjectDataSourceAbogados.SelectMethod = "GetData";
            
            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
        else if (rbtClientes.Checked == true)
        {
            ReportViewer1.LocalReport.ReportPath = "Informes/Report2.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rdsClientes = new ReportDataSource();
            rdsClientes.Name = "BuscarClientes";
            rdsClientes.DataSourceId = "ObjectDataSourceClientes";

            ReportViewer1.LocalReport.DataSources.Add(rdsClientes);

            ObjectDataSourceClientes.SelectMethod = "GetData";

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
        else if (rbtExpedientesCerrados.Checked == true)
        {
            ReportViewer1.LocalReport.ReportPath = "Informes/Report2.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rdsExpedientesCerrados = new ReportDataSource();
            rdsExpedientesCerrados.Name = "BuscarExpedientesCerrados";
            rdsExpedientesCerrados.DataSourceId = "ObjectDataSourceExpedientesCerrados";

            ReportViewer1.LocalReport.DataSources.Add(rdsExpedientesCerrados);

            ObjectDataSourceClientes.SelectMethod = "GetData";

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        CleanSearch();
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = false;
    }
}