using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Data.Conventions
{
    public class KeyConvention : Convention
    {
        public KeyConvention()
        {

            this.Properties<int>()

              .Where(p => p.Name.StartsWith("Id")
                  )

              .Configure(p => p.IsKey());
        }
    }
}
