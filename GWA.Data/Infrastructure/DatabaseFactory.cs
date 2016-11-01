using GWA.Data.Context;
using GWA.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Data.Infrastructure
{
  public  class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private GWAContext dataContext;
        public GWAContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new GWAContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }
}
