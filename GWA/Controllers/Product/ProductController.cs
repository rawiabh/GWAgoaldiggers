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
using System.Net;
using PagedList;


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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var prod = ps.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                prod = prod.Where(s => s.Name.Contains(searchString)
                                       || s.reference.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    prod = prod.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    prod = prod.OrderBy(s => s.CreationDate);
                    break;
                case "date_desc":
                    prod = prod.OrderByDescending(s => s.CreationDate);
                    break;
                default:
                    prod = prod.OrderBy(s => s.Name);
                    break;
            }


            List<ProductViewModel> pvm = new List<ProductViewModel>();
            foreach (var item in prod)
            {
                pvm.Add(
                    new ProductViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CreationDate = item.CreationDate,
                        CategoryId = item.IdCategory,
                        CurrentPrice = item.CurrentPrice,
                        reference = item.reference,
                        status = item.status,
                        UpdateDate = new DateTime(),
                        ImageUrl = item.ImageUrl,
                        IdUser = item.IdUser
                    });
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(pvm.ToPagedList(pageNumber, pageSize));

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
            List<GWA.Domaine.Entities.Category> Categories = cs.GetAll().ToList();
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
                IdUser = pvm.IdUser,
                Name = pvm.Name,
                reference = pvm.reference,
                status = pvm.status,
                UpdateDate = new DateTime(),
                ImageUrl = pvm.ImageUrl


            };
            ps.Add(t);
            ps.Commit();

            // Sauvgarde de l'image

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = new Product();
            p = ps.GetById((long)id);

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
            List<GWA.Domaine.Entities.Category> Categories = cs.GetAll().ToList();
            pvm.Category = Categories.ToSelectListItems();
            return View(pvm);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductViewModel pvm, HttpPostedFileBase Image)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = ps.GetById((long)id);
            if (p == null)
            {
                return HttpNotFound();
            }
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

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product p = ps.GetById((long)id);
            ps.Delete(p);
            ps.Commit();
            return RedirectToAction("Index");
        } }}
