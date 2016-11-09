using GWA.Data.Infrastructure;
using GWA.Domaine.Entities;
using GWA.Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Service.UserService.Service
{
    class ServiceUser : Service<User>
    {
        private static IUnitOfWork utwk = new UnitOfWork(new DatabaseFactory());

        public ServiceUser() : base(utwk)
        {

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
