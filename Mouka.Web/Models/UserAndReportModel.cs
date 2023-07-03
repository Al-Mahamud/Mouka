using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mouka.Web.Models
{
    public class UserAndReportModel
    {
        public int Id { get; set; }
        public string ReportByName { get; set; }

        public string  ReportForName { get; set; }

        public int ReportForId { get; set; }
        public string Report { get; set; }
        public int ReportId { get; set; }
        public DateTime ReportDate { get; set; }


    }
}