using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace pmf_2
{
    public class help_app
    {
        private bool see_admin();
        {
        //var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var userManager = new ApplicationUserManager();
        var roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
        const string name = "admin@example.com";
        const string password = "Admin@123456";
        const string roleName = "Admin";

        //Create Role Admin if it does not exist
        var role = roleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new IdentityRole(roleName);
                    var roleresult = roleManager.Create(role);
                }

        var user = userManager.FindByName(name);
                if (user == null)
                {
                    user = new ApplicationUser { UserName = name, Email = name
                };
        var result = userManager.Create(user, password);
        result = userManager.SetLockoutEnabled(user.Id, false);
                }

        // Add user admin to Role Admin if not already added
        var rolesForUser = userManager.GetRoles(user.Id);
                if (!rolesForUser.Contains(role.Name))
                {
                    var result = userManager.AddToRole(user.Id, role.Name);
                }
                return true;
            }        
    }
}