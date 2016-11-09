using GWA.Data.Infrastructure;
using GWA.Domaine.Entities;
using GWA.Service.Pattern;

namespace GWA.Service.ShoppingCarts
{
    public class ShoppingCartService : Service<Domaine.Entities.ShoppingCart>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public const string CartSessionKey = "CartId";

        public ShoppingCartService()
           : base(ut)
        {
        }
        public static ShoppingCart GetCart(Buyer CurrentBuyer)
        {
            ShoppingCart CurrentCart = CurrentBuyer.ShoppingCart;
            if (CurrentCart == null)
            {
                CurrentCart = new ShoppingCart();
                CurrentBuyer.ShoppingCart = CurrentCart;
                // CurrentCart.Buyer = CurrentBuyer;
            }
            ut.Commit();
            return CurrentCart;
        }



        public void AddToCart(ShoppingCart CurrentCart, int productId)
        {
            Command command = ut
       .getRepository<Command>()
       .Get(c => c.ShoppingCartId == CurrentCart.Id && c.ProductId == productId);
            Product p = ut
                .getRepository<Product>()
                .GetById(productId);

            if (command == null)
            {
                command = new Command()
                {
                    Product = p,
                    ShoppingCart = CurrentCart,
                    ProductId = productId,
                    Quantity = 1,
                    ShoppingCartId = CurrentCart.Id,

                };
                ut.getRepository<Command>().Add(command);
            }
            else
            {
                command.Quantity++;
            }

            ut.Commit();
        }
        public double RemoveFromCart(ShoppingCart CurrentCart, int id)
        {
            Command command = null;
            double counts = 0;
            foreach (Command c in CurrentCart.Commands)
            {
                if (c.ProductId == id)
                    command = c;
            }


            if (command.Quantity > 1)
            {
                command.Quantity--;
                counts = command.Quantity;
            }
            else
                ut.getRepository<Command>().Delete(command);



            ut.Commit();
            return counts;
        }


        public void EmptyCart(ShoppingCart CurrentCart)
        {
            foreach (Command c in CurrentCart.Commands)
            {
                ut.getRepository<Command>().Delete(c);

            }
            // Save changes
            ut.Commit();
        }

        public int GetCount(ShoppingCart CurrentCart)
        {
            return CurrentCart.Commands.Count;

        }
        public double GetTotal(ShoppingCart CurrentCart)
        {
            double total = 0;
            foreach (Command c in CurrentCart.Commands)
            {
                total += c.TotalPrice;
            }
            return total;

        }




    }
}
