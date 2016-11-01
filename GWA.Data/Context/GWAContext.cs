using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Data.Context
{
   public class GWAContext :DbContext
    {
        public GWAContext()
              : base("")
        {

        }

    }
}
