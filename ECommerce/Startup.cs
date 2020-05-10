using ECommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommerce.Startup))]
namespace ECommerce
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            IdentityRole adminrole = new IdentityRole();
            if (!roleManager.RoleExists("Admin"))
            {
                adminrole.Name = "Admin";
                roleManager.Create(adminrole);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                var Check = userManager.Create(user,"ASDzxc123$@");
                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            IdentityRole customerrole = new IdentityRole();
            if (!roleManager.RoleExists("Customer"))
            {
                customerrole.Name = "Customer";
                roleManager.Create(customerrole);
                ApplicationUser customeruser = new ApplicationUser();
                customeruser.UserName = "customer";
                customeruser.Email = "customer@gmail.com";
                var customerCheck = userManager.Create(customeruser, "ASDzxc123$@");
                if (customerCheck.Succeeded)
                {
                    userManager.AddToRole(customeruser.Id, "Customer");
                }
            }
            IdentityRole supplierrole = new IdentityRole();
            if (!roleManager.RoleExists("Supplier"))
            {
                supplierrole.Name = "Supplier";
                roleManager.Create(supplierrole);
                ApplicationUser supplieruser = new ApplicationUser();
                supplieruser.UserName = "customer";
                supplieruser.Email = "customer@gmail.com";
                var supplierCheck = userManager.Create(supplieruser, "ASDzxc123$@");
                if (supplierCheck.Succeeded)
                {
                    userManager.AddToRole(supplieruser.Id,"Supplier");
                }
            }
        }
    }
}
