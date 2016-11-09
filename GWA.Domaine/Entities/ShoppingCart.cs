using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Domaine.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int Count { get; set; }
       // public Buyer Buyer { get; set; }
        public virtual ICollection<Command> Commands { get; set; }

    }
}
