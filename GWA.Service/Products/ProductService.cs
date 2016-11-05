using GWA.Domaine.Entities;
using GWA.Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWA.Data.Infrastructure;

namespace GWA.Service.Products
{
   public  class ProductService : Service<Product>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ProductService()
           : base(ut)
        {
        }
    }
}
