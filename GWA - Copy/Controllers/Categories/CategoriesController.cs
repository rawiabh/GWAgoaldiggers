using GWA.Models.Category;
using GWA.Service.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GWA.Domaine.Entities;
using System.IO;
using System.Net;

namespace GWA.Controllers.Categories
{
    public class CategoriesController : Controller
    {
        CategoryService cs = null;
        public CategoriesController()
        {
           
            cs = new CategoryService();
        }
        // GET: Categories
        public ActionResult Index()
        {
            var cat = cs.GetAll();
            List<CategoryViewModel> cvm = new List<CategoryViewModel>();
            foreach (var item in cat)
            {
                cvm.Add(
                    new CategoryViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        ImageUrl = item.ImageUrl
                    });
            }
            return View(cvm);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Category p = new Category();
            p = cs.GetById(id);

            CategoryViewModel cvm = new CategoryViewModel
            {

                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl

            };
            return View(cvm);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            var cvm = new CategoryViewModel();
            return View(cvm);
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel cvm, HttpPostedFileBase Image)
        {
            cvm.ImageUrl = Image.FileName;
            Category c = new Category
            {
                Id = cvm.Id,

                Name = cvm.Name,

                Description = cvm.Description,

                ImageUrl = cvm.ImageUrl

            };
            cs.Add(c);
            cs.Commit();
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");
            
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category c = new Category();
            c = cs.GetById((long)id);
            CategoryViewModel cvm = new CategoryViewModel
            {
                Id = c.Id,

                Name = c.Name,

                Description = c.Description,

                ImageUrl = c.ImageUrl

            };
            return View(cvm);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel cvm, HttpPostedFileBase Image)
        {
            Category c = new Category();
            c = cs.GetById(id);
            c.Description = cvm.Description;
            c.Name = cvm.Name;
            c.ImageUrl = cvm.ImageUrl;
            c.ImageUrl = Image.FileName;
            cs.Update(c);
            cs.Commit();
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category c = cs.GetById((long)id);
            if (c == null)
            {
                return HttpNotFound();
            }
            CategoryViewModel cvm = new CategoryViewModel
            {
                Id = c.Id,

                Name = c.Name,

                Description = c.Description,

                ImageUrl = c.ImageUrl
               
                

            };
            return View(cvm);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            Category c = cs.GetById((long)id);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("Index");

        }
    }
}
