using GWA.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Data.Configurations
{
    class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            //one to many
            HasRequired(p => p.User)
               .WithMany(u => u.UserProducts)
               .HasForeignKey(p => p.IdUser)
               .WillCascadeOnDelete(false);

            //one to many
            HasRequired(p => p.Category)
               .WithMany(u => u.CategoryProducts)
               .HasForeignKey(p => p.IdCategory)
               .WillCascadeOnDelete(false);
        }
    }
}
