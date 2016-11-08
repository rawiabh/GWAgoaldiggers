using Ds.Data.Conventions;
using GWA.Data.Configurations;
using GWA.Domaine.Entities;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GWA.Domaine;

namespace GWA.Data.Context
{
    //public class ApplicationUser : IdentityUser
    //{
      
    //    public string RegisterEmail { get; set; }
    //    public string RegisterUserName { get; set; }

    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Country { get; set; }
    //    public DateTime JoinDate { get; set; }
    //    public DateTime EmailLinkDate { get; set; }
    //    public DateTime LAstLoginDate { get; set; }
    //    public string HomeTown { get; set; }
    //    public System.DateTime? BirthDate { get; set; }
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
   public class GWAContext : IdentityDbContext<User>//:DbContext
    {
        public GWAContext()
              : base("GWADB", throwIfV1Schema: false)
        {

        }
      
        //static GWAContext()
        //{
        //    // Set the database intializer which is run once during application start
        //    // This seeds the database with admin user credentials and admin role
        //   // Database.SetInitializer<GWAContext>(new ApplicationDbInitializer());
        //}

        public static GWAContext Create()
        {
            return new GWAContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());

            //modelBuilder.Conventions.Add(new DatetimeConvention());

            //modelBuilder.Conventions.Add(new KeyConvention());
         
        }

      
       // DbSet<User> usersAuction { get; set; }
        DbSet<Product> products { get; set; }
        DbSet<Auction> auctions { get; set; }
        DbSet<Token> tokens { get; set; }
        DbSet<Category> category { get; set; }
        DbSet<Notification> notifications { get; set; }
        DbSet<Bid> bids { get; set; }
        DbSet<Payment> payments { get; set; }
        DbSet<Session> sessions { get; set; }
        DbSet<ShoppingCart> shoppingCarts { get; set; }
        //DbSet<Subscription> subscription { get; set; }
        DbSet<Command> commands { get; set; }
       //DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
    }
}
