using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Domaine.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public virtual ICollection<Product> CategoryProducts { get; set; }
    }
}
