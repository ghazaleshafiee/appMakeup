using MakeUp.Data.Entities;
using MakeUp.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUp.Data.Context
{
    public class MyAppContext : DbContext
    {
       
        public MyAppContext() : base("name=myAppConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }
         
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
