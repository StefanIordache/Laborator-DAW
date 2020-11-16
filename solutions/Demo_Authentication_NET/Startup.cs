using Demo_Authentication_NET.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo_Authentication_NET.Startup))]
namespace Demo_Authentication_NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedUserRolesAndAdministrator();
        }

        // HELPERS

        private void SeedUserRolesAndAdministrator()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("User"))
            {
                var newRole = new IdentityRole();
                newRole.Name = "User";
                roleManager.Create(newRole);
            }

            if (!roleManager.RoleExists("Administrator"))
            {
                var newRole = new IdentityRole();
                newRole.Name = "Administrator";
                roleManager.Create(newRole);

                var newUser = new ApplicationUser();
                newUser.UserName = "admin@test.com";
                newUser.Email = "admin@test.com";

                var result = userManager.Create(newUser, "Pa55word!");
                if (result.Succeeded)
                {
                    userManager.AddToRole(newUser.Id, "Administrator");
                }
            }

            if (!roleManager.RoleExists("Developer"))
            {
                var newRole = new IdentityRole();
                newRole.Name = "Developer";
                roleManager.Create(newRole);

                var newUser = new ApplicationUser();
                newUser.UserName = "developer@test.com";
                newUser.Email = "developer@test.com";

                var result = userManager.Create(newUser, "Pa55word!");
                if (result.Succeeded)
                {
                    userManager.AddToRole(newUser.Id, "Developer");
                    userManager.AddToRole(newUser.Id, "Administrator");
                }
            }
        }
    }


}
