using GWA.Data.Context;
using GWA.Domaine.Entities;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System;
using System.Threading.Tasks;


namespace IdentitySample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();

        }
        private void createRolesandUsers()
        {

            GWAContext context = new GWAContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            //if (!roleManager.RoleExists("Manager"))
            //{

            //    // first we create Admin rool   
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Manager";
            //    roleManager.Create(role);

            //    //Here we create a Admin super user who will maintain the website                  

            //    var user = new ApplicationUser();
            //    user.UserName = "shanu";
            //    user.Email = "syedshanumcain@gmail.com";

            //    string userPWD = "A@Z200711";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Admin   
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Manager");

            //    }
            //}

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Seller"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Seller";
                roleManager.Create(role);

            }
        }

    }
}