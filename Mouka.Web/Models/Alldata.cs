using Mauka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mouka.Web.Models
{
    public class Alldata
    {
        public string UserName { get; set; }
        public string UserDescription { get; set; }
        public int UserId { get; set; }
        public DateTime UserTime { get; set; }
        public string UserURL { get; set; }
        public string UserLocation { get; set; }

        public string PhoneNumber { get; set; }
        public string Category { get; set; }

        public List<Product> Products { get; set; }

    }
}