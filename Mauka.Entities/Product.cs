using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauka.Entities
{
    public class Product :BaseEntity
    {
       
        public string City { get; set; }

        public User User { get; set; }

        public Category Category { get; set; }
        public string ImageURL { get; set; }
        public int Price { get; set; }
        public string PhoneNumber { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public DateTime postTime { get; set; }




    }
}
