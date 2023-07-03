using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mouka.Web.Models
{
    public class UserAndProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public DateTime ProductTime { get; set; }
        public string ProductURL { get; set; }
        public string ProductLocation { get; set; }

        public string UserName { get; set; }
        public string UserDescription { get; set; }
        public int UserId { get; set; }
        public DateTime UserTime { get; set; }
        public string UserURL { get; set; }
        public string UserLocation { get; set; }

        public string PhoneNumber { get; set; }






    }
}