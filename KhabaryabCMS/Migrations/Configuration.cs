namespace KhabaryabCMS.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KhabaryabCMS.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "KhabaryabCMS.DatabaseContext";
        }

        protected override void Seed(KhabaryabCMS.DatabaseContext context)
        {
            if (context.Admins.Count() == 0)
            {
                Admin admin = new Admin();
                admin.Username = "Admin";
                admin.FullName = "ادمین سایت";
                admin.Email = "Admin@Khabaryab.ir";
                admin.Password = "09017848766";
                context.Entry(admin).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
