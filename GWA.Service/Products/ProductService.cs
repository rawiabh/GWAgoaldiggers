using GWA.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using GWA.Service.UserService.Service;
using GWA.Service.Pattern;
using GWA.Data.Infrastructure;
using GWA.Data.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

        ServiceUser us = new ServiceUser();


        //public User getBestSeller()
        //{
        //    var u = (from p in dbf.DataContext.products
        //             where p.status == true
        //             orderby p.IdUser
        //             select p).Take(1);
        //    Product prod = u.First();
        //    User user = us.GetById(prod.User.);

        //    return user;
        //}

        public IEnumerable<Product> NewProducts()
        {
            var u = (from p in dbf.DataContext.products
                     where p.CreationDate.Day == DateTime.Now.Day &
                        p.CreationDate.Year == DateTime.Now.Year &
                        p.CreationDate.Month == DateTime.Now.Month
                     select p);

            return u;
        }

        public IEnumerable<Product> selledProduct()
        {
            var u = (from p in dbf.DataContext.products
                     where p.status == true
                     select p);

            return u;
        }

        public IEnumerable<Product> availableProduct()
        {
            var u = (from p in dbf.DataContext.products
                     where p.status == false
                     select p);

            return u;
        }

        public IEnumerable<Product> onAuctionRightNow()
        {
            //var u = (from p in dbf.DataContext.products
            //         where p.isOnAuction == true
            //         select p);

            return null;
        }

        //static à changer 
        public IEnumerable<Product> myProducts(string id)
        {
            
            var u = (from p in dbf.DataContext.products
                     where p.User.Id == id
                     select p);

            return null;
        }
    }
}
