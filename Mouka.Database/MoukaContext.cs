using Mauka.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouka.Database
{
    public class MoukaContext :DbContext ,IDisposable
    {
        public MoukaContext() :base("MoukaConnection")
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}
