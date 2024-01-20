using MakeUp.Data.Context;
using MakeUp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUp.Tools
{
    public class DataInitializer : CreateDatabaseIfNotExists<MyAppContext>
    {
        protected override void Seed(MyAppContext context)
        {
            context.Users.Add(new User
            {
                Username = "admin",
                Password = "admin",
               
            });

            base.Seed(context);
           
        }
    }
}
