namespace BugTracker23.Migrations
{
    using BugTracker23.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker23.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugTracker23.Models.ApplicationDbContext context)
        {
            #region Roles
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                roleManager.Create(new IdentityRole { Name = "Administrator" });
            }

            if (!context.Roles.Any(r => r.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Project Manager" });
            }
            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }
            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }
            #endregion

            //Write some code that creates a user
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));


            #region Seeded Users
            if (!context.Users.Any(u => u.Email == "douglas.campbell@wellstar360.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "douglas.campbell@wellstar360.com",
                    UserName = "douglas.campbell@wellstar360.com",
                    FirstName = "Douglas",
                    LastName = "Campbell",
                    DisplayName = "Doug"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("douglas.campbell@wellstar360.com").Id;
                userManager.AddToRole(userId, "Administrator");
            }

            if (!context.Users.Any(u => u.Email == "jessica.sanders@wellstar360.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "jessica.sanders@wellstar360.com",
                    UserName = "jessica.sanders@wellstar360.com",
                    FirstName = "Jessica",
                    LastName = "Sanders",
                    DisplayName = "Jessica"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("jessica.sanders@wellstar360.com").Id;
                userManager.AddToRole(userId, "Project Manager");
            }
            if (!context.Users.Any(u => u.Email == "jasontwichell@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "jasontwichell@coderfoundry.com",
                    UserName = "jasontwichell@coderfoundry.com",
                    FirstName = "Jason",
                    LastName = "Twichell",
                    DisplayName = "The Prof"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("jasontwichell@coderfoundry.com").Id;
                userManager.AddToRole(userId, "Project Manager");
            }
            if (!context.Users.Any(u => u.Email == "walter.lewis@wellstar360.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "walter.lewis@wellstar360.com",
                    UserName = "walter.lewis@wellstar360.com",
                    FirstName = "Walter",
                    LastName = "Lewis",
                    DisplayName = "Walter L"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("walter.lewis@wellstar360.com").Id;
                userManager.AddToRole(userId, "Developer");
            }

            if (!context.Users.Any(u => u.Email == "lisa.baker@wellstar360.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "lisa.baker@wellstar360.com",
                    UserName = "lisa.baker@wellstar360.com",
                    FirstName = "Lisa",
                    LastName = "Baker",
                    DisplayName = "Lisa B"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("lisa.baker@wellstar360.com").Id;
                userManager.AddToRole(userId, "Developer");
            }
            if (!context.Users.Any(u => u.Email == "andrewrussell@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "andrewrussell@coderfoundry.com",
                    UserName = "andrewrussell@coderfoundry.com",
                    FirstName = "Andrew",
                    LastName = "Russell",
                    DisplayName = "Drew R"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("andrewrussell@coderfoundry.com").Id;
                userManager.AddToRole(userId, "Developer");
            }
            if (!context.Users.Any(u => u.Email == "julie.lawrence@longevityformula.us"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "julie.lawrence@longevityformula.us",
                    UserName = "julie.lawrence@longevityformula.us",
                    FirstName = "Julie",
                    LastName = "Lawrence",
                    DisplayName = "Julie L"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("julie.lawrence@longevityformula.us").Id;
                userManager.AddToRole(userId, "Submitter");
            }

            if (!context.Users.Any(u => u.Email == "jill.smith@gamiboss.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "jill.smith@gamiboss.com",
                    UserName = "jill.smith@gamiboss.com",
                    FirstName = "Jill",
                    LastName = "Smith",
                    DisplayName = "Jill S"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("jill.smith@gamiboss.com").Id;
                userManager.AddToRole(userId, "Submitter");
            }
            if (!context.Users.Any(u => u.Email == "luna.stella@gamiboss.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "luna.stella@gamiboss.com",
                    UserName = "luna.stella@gamiboss.com",
                    FirstName = "Luna",
                    LastName = "Stella",
                    DisplayName = "Luna S"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("luna.stella@gamiboss.com").Id;
                userManager.AddToRole(userId, "Submitter");
            }

            if (!context.Users.Any(u => u.Email == "madelyn.nellie@longevityformula.us"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "madelyn.nellie@longevityformula.us",
                    UserName = "madelyn.nellie@longevityformula.us",
                    FirstName = "Madelyn",
                    LastName = "Nellie",
                    DisplayName = "Madelyn N"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("madelyn.nellie@longevityformula.us").Id;
                userManager.AddToRole(userId, "Submitter");
            }

            if (!context.Users.Any(u => u.Email == "margaret.mia@officecloud.us"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "margaret.mia@officecloud.us",
                    UserName = "margaret.mia@officecloud.us",
                    FirstName = "Margaret",
                    LastName = "Mia",
                    DisplayName = "Margaret M"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("margaret.mia@officecloud.us").Id;
                userManager.AddToRole(userId, "Submitter");
            }
            if (!context.Users.Any(u => u.Email == "mateo.gabriel@officecloud.us"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "mateo.gabriel@officecloud.us",
                    UserName = "mateo.gabriel@officecloud.us",
                    FirstName = "Mateo",
                    LastName = "Gabriel",
                    DisplayName = "Mateo G"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("mateo.gabriel@officecloud.us").Id;
                userManager.AddToRole(userId, "Submitter");
            }
            if (!context.Users.Any(u => u.Email == "maverick.cooper@gamiboss.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "maverick.cooper@gamiboss.com",
                    UserName = "maverick.cooper@gamiboss.com",
                    FirstName = "Maverick",
                    LastName = "Cooper",
                    DisplayName = "Maverick C"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("maverick.cooper@gamiboss.com").Id;
                userManager.AddToRole(userId, "Submitter");
            }

            if (!context.Users.Any(u => u.Email == "neville.griffin@churchcloud.us"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "neville.griffin@churchcloud.us",
                    UserName = "neville.griffin@churchcloud.us",
                    FirstName = "Neville",
                    LastName = "Griffin",
                    DisplayName = "Neville G"
                }, "Wellne$$23");
                var userId = userManager.FindByEmail("neville.griffin@churchcloud.us").Id;
                userManager.AddToRole(userId, "Submitter");
            }
            if (!context.Users.Any(u => u.Email == "nicolina.victoria@churchcloud.us"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "nicolina.victoria@churchcloud.us",
                    UserName = "nicolina.victoria@churchcloud.us",
                    FirstName = "Nicolina",
                    LastName = "Victoria",
                    DisplayName = "Nicolina V"
                }, "Wellne$$23");
                
                var userId = userManager.FindByEmail("nicolina.victoria@churchcloud.us").Id;
                userManager.AddToRole(userId, "Submitter");
            }

            if (!context.Users.Any(u => u.Email == "timothy.welch@officecloud.us"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "timothy.welch@officecloud.us",
                    UserName = "timothy.welch@officecloud.us",
                    FirstName = "Timothy",
                    LastName = "Welch",
                    DisplayName = "Jon G"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("timothy.welch@officecloud.us").Id;
                userManager.AddToRole(userId, "Submitter");
            }
            if (!context.Users.Any(u => u.Email == "trent.watson@wellstar360.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "trent.watson@wellstar360.com",
                    UserName = "trent.watson@wellstar360.com",
                    FirstName = "Trent",
                    LastName = "Watson",
                    DisplayName = "Trent W"
                }, "Wellne$$23");

                var userId = userManager.FindByEmail("trent.watson@wellstar360.com").Id;
                userManager.AddToRole(userId, "Submitter");
            }
            #endregion

            
            context.SaveChanges();
            #region TicketType Seed
            context.TicketTypes.AddOrUpdate(
                tt => tt.Name,
                new TicketType() { Name = "Software" },
                new TicketType() { Name = "Hardware" },
                new TicketType() { Name = "UI" },
                new TicketType() { Name = "Defect" },
                new TicketType() { Name = "Feature Request" },
                new TicketType() { Name = "Other" }
                );
            #endregion

            #region Ticket Priority Seed
            context.TicketPriorities.AddOrUpdate(
                tt => tt.Name,
                new TicketPriority() { Name = "Low" },
                new TicketPriority() { Name = "Medium" },
                new TicketPriority() { Name = "High" },
                new TicketPriority() { Name = "Defect" },
                new TicketPriority() { Name = "On Hold" },
                new TicketPriority() { Name = "Other" }
                );
            #endregion
            #region Ticket Status Seed
            context.TicketStatus.AddOrUpdate(
                tt => tt.Name,
                new TicketStatus() { Name = "Open" },
                new TicketStatus() { Name = "Assigned" },
                new TicketStatus() { Name = "Resolved" },
                new TicketStatus() { Name = "Reopened" },
                new TicketStatus() { Name = "Archived" },
                new TicketStatus() { Name = "Other" }
                );
            #endregion

            #region Project Seed
            context.Projects.AddOrUpdate(
                p => p.Name,
                new Project() { Name = "Seed 1", Created = DateTime.Now.AddDays(-60), IsArchived = true },
                new Project() { Name = "Seed 2", Created = DateTime.Now.AddDays(-45), IsArchived = true },
                new Project() { Name = "Seed 3", Created = DateTime.Now.AddDays(-30), IsArchived = true },
                new Project() { Name = "Seed 4", Created = DateTime.Now.AddDays(-15), IsArchived = true },
                new Project() { Name = "Seed 5", Created = DateTime.Now.AddDays(-7), IsArchived = true }
                );
            #endregion

        }
    }
}