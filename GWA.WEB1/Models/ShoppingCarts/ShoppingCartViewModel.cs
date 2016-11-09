using GWA.Domaine.Entities;
using System.Collections.Generic;

namespace GWA.WEB1.Models.ShoppingCarts
{
    public class ShoppingCartViewModel
    {
        public List<Command> CartItems { get; set; }
        public double CartTotal { get; set; }
    }
}