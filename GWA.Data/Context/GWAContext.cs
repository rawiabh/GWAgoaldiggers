using Ds.Data.Conventions;
using GWA.Data.Configurations;
using GWA.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Data.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
   public class GWAContext :DbContext
    {
        public GWAContext()
              : base("GWADB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());

            //modelBuilder.Conventions.Add(new DatetimeConvention());

            //modelBuilder.Conventions.Add(new KeyConvention());
        }

        DbSet<User> users { get; set; }
      public  DbSet<Product> products { get; set; }
        DbSet<Auction> auctions { get; set; }
        DbSet<Token> tokens { get; set; }
        public DbSet<Category> category { get; set; }
        DbSet<Notification> notifications { get; set; }
        DbSet<Bid> bids { get; set; }
        DbSet<Payment> payments { get; set; }
        DbSet<Session> sessions { get; set; }
        DbSet<ShoppingCart> shoppingCarts { get; set; }
        //DbSet<Subscription> subscription { get; set; }
        DbSet<Command> commands { get; set; }
    }
}
