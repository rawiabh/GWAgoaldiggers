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
    }
}
