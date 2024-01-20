namespace MakeUp.Migrations
{
    using MakeUp.Data.Entities;
    using MakeUp.Tools;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MakeUp.Data.Context.MyAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "CodeFirstSample.Data.Context.AppDbContext";
        }

        protected override void Seed(MakeUp.Data.Context.MyAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var user = new User { Username = "admin", Password = "admin" };
             context.Users.AddOrUpdate(user);
        }
    }
}
