using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Domaine.Entities
{
    public class Address
    {
        public int NumStreet { get; set; }
        public String Street { get; set; }

        public String Town { get; set; }

        public int PostalCode { get; set; }

        public String Country { get; set; }
    }
}
