using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TheChromium.Models;

[assembly: OwinStartupAttribute(typeof(TheChromium.Startup))]

namespace TheChromium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Member"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Member";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("VIP"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "VIP";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
                var user = new ApplicationUser();
                user.UserName = "Manager";
                user.Email = "Manager@gmail.com";
                user.PasswordHash = "123456aA!";
                

                var chkUser = userManager.Create(user);


                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Manager");

                }
                context.SaveChanges();
            }



        }
    }
}
  
  