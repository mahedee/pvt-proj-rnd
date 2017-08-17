using Microsoft.Reporting.WebForms;
using MVC.RdlcReport.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC.RdlcReport.Views.Shared
{
    public partial class ReportViewer : System.Web.Mvc.ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ERPDBContext objERPDBContext = new ERPDBContext();
                DataTable dt = objERPDBContext.GetReportDS("",3);
                //WebApplication1.Models.AssetDBContext db = new WebApplication1.Models.AssetDBContext();
                //System.Collections.Generic.List<WebApplication1.Models.Employee> employees = null;
                //employees = db.Employees.ToList();
                //List<MVCReportViwer.Customer> customers = null;
                // using (MVCReportViwer.MyDatabaseEntities dc = new MVCReportViwer.MyDatabaseEntities())
                // {
                //     customers = dc.Customers.OrderBy(a => a.CustomerID).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/rpt_employee_info.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                //ReportDataSource rdc = new ReportDataSource("EmployeeDS", employees);
                ReportDataSource rdc = new ReportDataSource("ReportDataSet", dt);
                    //("ERPDBDataSet", ds);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();
                // }
            }
        }
    }
}