using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Data.Conventions
{
    public class DatetimeConvention : Convention
    {
        public DatetimeConvention()
        {
            this.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

        }
    }
}
