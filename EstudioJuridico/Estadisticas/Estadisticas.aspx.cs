using System;
using System.Web.UI;
using System.Drawing;
using Microsoft.Reporting.WebForms;

public partial class Estadisticas_Estadisticas : System.Web.UI.Page
{
    //METODOS ADICIONALES
    public void Clean()
    {
        rbtConsultasPorAbogados.Checked = true;

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
    protected void btnReporte_Click(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;
        lblError.Visible = false;

        lblFechaInferior.Text = txtFechaInferior.Text;
        lblFechaSuperior.Text = txtFechaSuperior.Text;
        
        if (rbtConsultasPorAbogados.Checked == true)
        {
            ReportViewer1.LocalReport.ReportPath = "Estadisticas/rdtConsultasPorAbogado.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rdsConsultasPorAbogados = new ReportDataSource();
            rdsConsultasPorAbogados.Name = "DataSet1";
            rdsConsultasPorAbogados.DataSourceId = "ObjectDataSourceConsultasPorAbogado";

            ReportViewer1.LocalReport.DataSources.Add(rdsConsultasPorAbogados);

            ObjectDataSourceConsultasPorAbogado.SelectMethod = "GetData";

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
        else if (rbtExpedientesPorAbogados.Checked == true)
        {
            ReportViewer1.LocalReport.ReportPath = "Estadisticas/rptExpedientesPorAbogado.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rdsExpedientesPorAbogados = new ReportDataSource();
            rdsExpedientesPorAbogados.Name = "DataSet1";
            rdsExpedientesPorAbogados.DataSourceId = "ObjectDataSourceExpedientesPorAbogado";

            ReportViewer1.LocalReport.DataSources.Add(rdsExpedientesPorAbogados);

            ObjectDataSourceExpedientesPorAbogado.SelectMethod = "GetData";

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
        else if (rbtClientesAtendidosAusentes.Checked == true)
        {
            ReportViewer1.LocalReport.ReportPath = "Estadisticas/rptClientesAusentesAtendidos.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rdsClientesAtendidosAusentes = new ReportDataSource();
            rdsClientesAtendidosAusentes.Name = "DataSet1";
            rdsClientesAtendidosAusentes.DataSourceId = "ObjectDataSourceClientesAusentesAtendidos";

            ReportViewer1.LocalReport.DataSources.Add(rdsClientesAtendidosAusentes);

            ObjectDataSourceClientesAusentesAtendidos.SelectMethod = "GetData";

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
        else if (rbtConsultasSegunMotivo.Checked == true)
        {
            ReportViewer1.LocalReport.ReportPath = "Estadisticas/rptConsultasSegunMotivo.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rdsConsultasSegunMotivo = new ReportDataSource();
            rdsConsultasSegunMotivo.Name = "DataSet1";
            rdsConsultasSegunMotivo.DataSourceId = "ObjectDataSourceConsultasSegunMotivo";

            ReportViewer1.LocalReport.DataSources.Add(rdsConsultasSegunMotivo);

            ObjectDataSourceConsultasSegunMotivo.SelectMethod = "GetData";

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
        else if (rbtExpedientesCerradosPorJuzgado.Checked == true)
        {
            ReportViewer1.LocalReport.ReportPath = "Estadisticas/rptExpedientesCerradosPorJuzgado.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rdsExpedientesCerradosPorJuzgado = new ReportDataSource();
            rdsExpedientesCerradosPorJuzgado.Name = "DataSet1";
            rdsExpedientesCerradosPorJuzgado.DataSourceId = "ObjectDataSourceExpedientesCerradosPorJuzgado";

            ReportViewer1.LocalReport.DataSources.Add(rdsExpedientesCerradosPorJuzgado);

            ObjectDataSourceExpedientesCerradosPorJuzgado.SelectMethod = "GetData";

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
        else
        {
            Clean();
            
            lblError.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = "Debe Seleccionar Una Opcion Como Origen Del Informe";
        }
    }

    //EVENTOS TEXTBOX
    protected void txtFechaInferior_TextChanged(object sender, EventArgs e)
    {
        DateTime fechaInferior = Convert.ToDateTime(txtFechaInferior.Text);
        DateTime fechaSuperior = Convert.ToDateTime(txtFechaSuperior.Text);

        if (fechaInferior > fechaSuperior)
        {
            txtFechaInferior.Text = DateTime.Now.ToShortDateString();
        }
    }
}