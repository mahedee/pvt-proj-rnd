using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.RdlcReport.Models
{
    public class ReportParameterVM
    {
        public virtual Designation Designation { get; set; }
        public string ReportFileName { get; set; }
        public string ReportPath { get; set; }
    }
}