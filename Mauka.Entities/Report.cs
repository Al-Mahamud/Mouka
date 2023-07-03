using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauka.Entities
{
    public class Report:BaseEntity
    {
        public int SubmittedUserId { get; set; }
        public int ReportOnUserId { get; set; }
        public string report { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReportTime { get; set; }
    }
}
