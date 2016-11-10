using GWA.Data.Infrastructure;
using GWA.Domaine.Entities;
using GWA.Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Service.Categories
{
    public class CategoryService : Service<Category>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public CategoryService()
           : base(ut)
        {
        }

        Data.Infrastructure.RepositoryBase<Product> rp;

        public IEnumerable<Product> getProductByCategory(String nom)
        { var u =
       (from p in dbf.DataContext.products where p.Category.Name == nom select p);
            return u;
        }

        //second try
        public IEnumerable<Product> getProductByCategory()
        {
            var u =
         (from p in dbf.DataContext.products.OrderBy(m=>m.IdCategory) select p);
            return u;
        }
        public IEnumerable<Product> getProductsByCategory()
        {
            var u =
         from p in dbf.DataContext.products orderby p.Category.Name select p;
            //return RC.Tables.OrderBy(m => m.numero).ToList();
            return u;
        }
        
  //public Product getHighestProductPriceineachCategory()
  //      {
  //          // return dbf.DataContext.products.Where(b => b.CurrentPrice == max(dbf.DataContext.products..First();
  //          var mm = dbf.DataContext.products.Max(b => b.CurrentPrice);
  //          return (dbf.DataContext.products.OrderBy(m=>m.IdCategory).Where(b => b.CurrentPrice == mm).First());      

  //      }

    
        public Product getHighestProductPriceineachCategory()
        {
            var u = (from p in dbf.DataContext.products
                    
                     orderby p.CurrentPrice
                     select p).Take(1);
            Product prod = u.First();
        

            return prod;
        }

        public Product getLowestProductPriceineachCategory()
        {
           // return dbf.DataContext.products.Where(b => b.CurrentPrice == dbf.DataContext.products.Max(CurrentPrice);
            var mm = dbf.DataContext.products.Min(b => b.CurrentPrice);
           return (dbf.DataContext.products.OrderBy(m => m.IdCategory).Where(b => b.CurrentPrice == mm).First());

        }
   //public Category getMostActiveCategory()
   //     {
   //         //var mm = dbf.DataContext.products.OrderBy(m => m.IdCategory).Count();
   //         // var mm = dbf.DataContext.category.OrderBy(m => m.Id).Count(m => m.CategoryProducts);
   //         var mm = dàbf.DataContext.category.OrderBy(m => m.Id);

   //         foreach (item in mm) {
   //             Count(item.CategoryProducts);
   //         }

   //     }


    }

        //public IEnumerable<Product> getProductByCategory()
        //{
        //    var u =(from p in dbf.DataContext)


        }

        //    public List<Product> getProductsByCategory(String Name)
        //    {


        //        var prod = rp.GetAll();

        //        if (!String.IsNullOrEmpty(Name))
        //       {
        //           prod = prod.Where(s => s.Name.Contains(Name)
        //                                  );
        //        }
        //    //    var cat = rp.GetAll();
        //        List<Product> LP = new List<Product>();
        //        foreach (var item in prod)
        //        {
        //            cvm.Add(
        //                new CategoryViewModel
        //                {
        //                    Id = item.Id,
        //                   Name = item.Name,
        //                    Description = item.Description,
        //                  ImageUrl = item.ImageUrl
        //                });
        //        }




        //    //}
