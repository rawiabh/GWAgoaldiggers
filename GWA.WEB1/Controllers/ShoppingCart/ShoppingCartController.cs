using GWA.Data.Context;
using GWA.Domaine.Entities;
using GWA.Service.Products;
using GWA.Service.ShoppingCarts;
using GWA.WEB1.Models.ShoppingCarts;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GWA.WEB1.Controllers.ShoppingCarts
{
    public class ShoppingCartController : Controller
    {
        GWAContext context = new GWAContext();


        //private ApplicationDbContext AppContext;
        //UserManager<ApplicationUser> UserManager = null;
        //ApplicationUser  CurrentUser;


        ShoppingCartService scs = null;
        ProductService ps = null;
        Domaine.Entities.ShoppingCart cart;
        public ShoppingCartController()
        {
            //AppContext = new ApplicationDbContext();
            //UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(AppContext));
            //CurrentUser = UserManager.FindById(User.Identity.GetUserId());


            string UserId = User.Identity.GetUserId();
            Buyer CurrentBuyer = (Buyer)context.Users.Find(UserId);
            scs = new ShoppingCartService();
            cart = ShoppingCartService.GetCart(CurrentBuyer);
            ps = new ProductService();
        }


        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var viewModel = new ShoppingCartViewModel
            {
                CartTotal = scs.GetTotal(cart)
            };
            // Return the view
            return View(viewModel);
        }


        // GET
        public ActionResult AddToCart(int id, int productId)
        {
            scs.AddToCart(cart, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var p = ps.GetById(id);
            // Remove from cart
            double itemCount = scs.RemoveFromCart(cart, id);

            // confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(p.Name) +
                    " has been removed from your shopping cart.",
                CartCount = scs.GetCount(cart),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);

        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            ViewData["CartCount"] = scs.GetCount(cart);
            return PartialView("CartSummary");
        }
    }
}

