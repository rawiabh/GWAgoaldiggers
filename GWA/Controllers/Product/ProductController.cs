using GWA.Domaine.Entities;
using GWA.Models.Product;
using GWA.Service.Categories;
using GWA.Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GWA.Helpers;
using System.IO;

namespace GWA.Controllers.Products
{
    public class ProductController : Controller
    {
        ProductService ps = null;
        CategoryService cs = null;
        public ProductController()
        {
            ps = new ProductService();
            cs = new CategoryService();
        }
        // GET: Product
        public ActionResult Index()
        {
            var prod = ps.GetAll();
            List<ProductViewModel> pvm = new List<ProductViewModel>();
            foreach (var item in prod)
            {
                pvm.Add(
                    new ProductViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CreationDate= item.CreationDate,
                        CategoryId = item.IdCategory,
                        CurrentPrice = item.CurrentPrice,
                        reference = item.reference,
                        status = item.status,
                        UpdateDate = new DateTime(),
                        ImageUrl = item.ImageUrl
                    });
            }
            return View(pvm);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product p = new Product();
            p = ps.GetById(id);

            ProductViewModel pvm = new ProductViewModel
            {
                CategoryId = p.IdCategory,
                CreationDate = p.CreationDate,
                CurrentPrice = p.CurrentPrice,
                IdUser = 1,
                Name = p.Name,
                reference = p.reference,
                status = p.status,
                UpdateDate = new DateTime(),
                ImageUrl = p.ImageUrl

            };
            return View(pvm);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var pvm = new ProductViewModel();
            List<Category> Categories = cs.GetAll().ToList() ;
            pvm.Category = Categories.ToSelectListItems();

            return View(pvm);
          
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel pvm, HttpPostedFileBase Image)
        {
            pvm.ImageUrl = Image.FileName;
            Product t = new Product
            {
                IdCategory = pvm.CategoryId,
                CreationDate = new DateTime(),
                CurrentPrice = pvm.CurrentPrice,
                IdUser = 1,
                Name = pvm.Name,
                reference= pvm.reference,
                status = pvm.status,
                UpdateDate = new DateTime()
                
                
            };
            ps.Add(t);
            ps.Commit();

            // Sauvgarde de l'image

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = new Product();
            p = ps.GetById(id);

            ProductViewModel pvm = new ProductViewModel
            {
                CategoryId = p.IdCategory,
                CreationDate = p.CreationDate,
                CurrentPrice = p.CurrentPrice,
                IdUser = 1,
                Name = p.Name,
                reference = p.reference,
                status = p.status,
                UpdateDate = new DateTime(), 
                ImageUrl = p.ImageUrl

            };
            List<Category> Categories = cs.GetAll().ToList();
            pvm.Category = Categories.ToSelectListItems();
            return View(pvm);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductViewModel pvm , HttpPostedFileBase Image)
        {
            Product p = new Product();
            p = ps.GetById(id);
            p.ImageUrl = Image.FileName;
            p.IdCategory = pvm.CategoryId;
            p.CreationDate = pvm.CreationDate;
            p.CurrentPrice = pvm.CurrentPrice;
            p.Name = pvm.Name;
            p.reference = pvm.reference;
            p.status = pvm.status;
            p.UpdateDate = pvm.UpdateDate;

            


            ps.Update(p);
            ps.Commit();
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");

        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
