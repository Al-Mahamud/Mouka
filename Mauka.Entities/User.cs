using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauka.Entities
{
    public class User :BaseEntity
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string ImageURL { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        public  List<Product> Products { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
