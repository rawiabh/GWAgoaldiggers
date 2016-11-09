using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Domaine.Entities
{
    public class Command
    {
        public int Id { get; set; }
        public double Quantity { get; set; } = 0;
        public bool Status { get; set; } = false;
        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        private double _TotalPrice;

        public double TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = Product.CurrentPrice * Quantity; }
        }


    }
}
