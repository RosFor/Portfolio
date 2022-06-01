namespace CarDealership.UI.Migrations
{
    using CarDealership.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(CarDealership.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Load the user and role managers with our custom models
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // have we loaded roles already?
            if (roleMgr.RoleExists("Admin"))
                return;

            // create the admin role
            roleMgr.Create(new IdentityRole() { Name = "Admin" });
            roleMgr.Create(new IdentityRole() { Name = "Sales" });
            roleMgr.Create(new IdentityRole() { Name = "Disabled" });

            // create the default user
            var adminUser = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "admin@guildcars.com"
            };

            var salesUser = new ApplicationUser()
            {
                UserName = "Sales",
                Email = "sales@guildcars.com"
            };
            var disabledUser = new ApplicationUser()
            {
                UserName = "Disabled",
                Email = "disabled@guildcars.com"
            };

            // create the user with the manager class
            userMgr.Create(adminUser, "Testing.123");
            userMgr.Create(salesUser, "Testing.123?");
            userMgr.Create(disabledUser, "Testing.1234");

            // add the user to the admin role
            userMgr.AddToRole(adminUser.Id, "Admin");
            userMgr.AddToRole(salesUser.Id, "Sales");
            userMgr.AddToRole(disabledUser.Id, "Disabled");
        }
    }
}
