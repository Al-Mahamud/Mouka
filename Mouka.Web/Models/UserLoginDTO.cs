using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mouka.Web.Models
{
    public class UserLoginDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string ImageURL { get; set; }
        // Exclude the Categories property
    }
    


}