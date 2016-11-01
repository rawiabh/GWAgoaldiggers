using GWA.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Data.Infrastructure
{
   public interface IDatabaseFactory : IDisposable
    {
        GWAContext DataContext { get; }
       
    }
}
