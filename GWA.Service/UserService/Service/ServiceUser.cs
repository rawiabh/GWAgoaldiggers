using GWA.Data.Infrastructure;
using GWA.Domaine.Entities;
using GWA.Service.Pattern;
using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWA.Data.Context;

namespace GWA.Service.UserService.Service
{
   public class ServiceUser : Service<User>
    {
        private static IUnitOfWork utwk = new UnitOfWork(new DatabaseFactory());

        public ServiceUser() : base(utwk)
        {

        }
        GWAContext context = new GWAContext();
        public List<string> GetUserRoles(string username)
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            List<string> ListOfRoleNames = new List<string>();
            var ListOfRoleIds = UserManager.FindByName(username).Roles.Select(x => x.RoleId).ToList();
            //foreach (string id in ListOfRoleIds)
            //{
            //    string rolename = RoleManager.FindById(id).Name;
            //    ListOfRoleNames.Add(rolename);


            //}

            return ListOfRoleNames;
        }

        //public IEnumerable<User> GetUserByRole(string Role)
        //{
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    var userStore = new Mock<IUserStore<ApplicationUser>>();
        //    var userManager = new UserManager(userStore.Object);
        //    return utwk.getRepository<User>().GetAll().Where(c => c == Role).ToList();
        //}


        //public IEnumerable<User> GetUserAuction(int idAuction)
        //{
        //    return utwk.getRepository<User>().GetAll().Where(k => k.actions.Where(c => c.Id == idAuction).ToList() != null).ToList();
        //}


        //public int numberUserAuction(int idAuction)
        //{
        //    return utwk.getRepository<User>().GetAll().Where(k => k.actions.Where(c => c.Id == idAuction).ToList() != null).ToList().Count();
        //}

        //public void participateUserAuction(int idAuction, int idBayer)
        //{
        //    Subscription sub = new Subscription();
        //    sub.DateOfSubscription = DateTime.Now;
        //    //sub.IdAuction = idAuction;
        //    //sub.IdBayer = idBayer;
        //    //utwk.getRepository<Subscription>().Add(sub);

        //}


    }
}
