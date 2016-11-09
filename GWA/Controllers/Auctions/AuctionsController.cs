using GWA.Domaine.Entities;
using GWA.Service.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GWA.Controllers.Auctions
{
    public class AuctionsController : Controller
    {
        AuctionService auctionservice = null;
        public AuctionsController()
        {
            auctionservice = new AuctionService();
 }


        // GET: Auctions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Auctions/Details/5
        public ActionResult Details(int id)
        {
            Auction auction = new Auction();
            auction = auctionservice.GetById(id);

            Auction pvm = new Auction
            {
                Description = auction.Description,
                Title = auction.Title,
                AuctionValue = auction.AuctionValue,
                AuctionTimer = auction.AuctionTimer,
                StartDate = auction.StartDate,
                EndtDate = auction.EndtDate,
                TimeLeft = auction.TimeLeft,

            };
            return View(pvm);
        }
        public ActionResult ListeDemandesaddauction()
        {
            List<Auction> auctions = auctionservice.getdemandtoaddauction().ToList();
            return View(auctions);
        }
        public ActionResult Listeauctions(string searchString)
        {
            var auc = auctionservice.getauctions();
            List<Auction> auctions = new List<Auction>();
            auctions = auc.ToList();
    
            if (!String.IsNullOrEmpty(searchString))
            {
                auctions = auc.Where(a=> a.Title.Contains(searchString)).ToList();
            }
            return View(auctions);
        }
        // GET: Auctions/Create
        public ActionResult Create()
        {
            var pvm = new Auction();
            return View(pvm);
        }

        // POST: Auctions/Create
        [HttpPost]
        public ActionResult Create(Auction pvm)
        {
            Auction auction = new Auction
            {
                Description = pvm.Description,
                Title = pvm.Title,
                AuctionValue = pvm.AuctionValue,
                AuctionTimer = pvm.AuctionTimer,
                StartDate = pvm.StartDate,
                EndtDate = pvm.EndtDate,
                TimeLeft = DateTime.Today - pvm.StartDate,
                IdProduct = pvm.IdProduct
     };
            auctionservice.Add(auction);
            auctionservice.Commit();
            return View(pvm);
        }
        public ActionResult Createdemand()
        {
            var pvm = new Auction();
            return View(pvm);
        }

        // POST: Auctions/Create
        [HttpPost]
        public ActionResult Createdemand(Auction pvm)
        {
            Auction auction = new Auction
            {
                Description = pvm.Description,
                Title = pvm.Title,
                AuctionValue = pvm.AuctionValue,
                AuctionTimer = pvm.AuctionTimer,
                StartDate = pvm.StartDate,
                IdProduct=pvm.IdProduct,
                EndtDate = pvm.EndtDate,
                Style=pvm.Style,
                TimeLeft = DateTime.Today - pvm.StartDate,
            };
            auctionservice.Add(auction);
            auctionservice.Commit();
           
             
            return View(pvm);
        }

        // GET: Auctions/Edit/5
        public ActionResult Edit(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Auction p = new Auction();
                p = auctionservice.GetById((long)id);

                Auction avm = new Auction
                {
                    Description = p.Description,
                    Title = p.Title,
                    AuctionValue = p.AuctionValue,
                    AuctionTimer = p.AuctionTimer,
                    StartDate = p.StartDate,
                    EndtDate = p.EndtDate,
                    validator = p.validator,
                    TimeLeft = p.EndtDate - p.StartDate,
                    IdProduct=p.IdProduct,
                };

                return View(avm);
            }

        }

        // POST: Auctions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Auction pvm)
        {
            Auction auction = new Auction();
            auction = auctionservice.GetById(id);
            auction.Description = pvm.Description;
            auction.Title = pvm.Title;
            auction.AuctionValue = pvm.AuctionValue;
            auction.AuctionTimer = pvm.AuctionTimer;
            auction.StartDate = pvm.StartDate;
            auction.IdProduct = pvm.IdProduct;
            auction.EndtDate = pvm.EndtDate;
            auction.validator = pvm.validator;
            auction.Style = pvm.Style;
            auction.TimeLeft = pvm.EndtDate - pvm.StartDate;
            auctionservice.Update(auction);
            auctionservice.Commit();
            return RedirectToAction("Listeauctions");

        }

        // GET: Auctions/Delete/5
        public ActionResult Delete(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Auction p = new Auction();
                p = auctionservice.GetById((long)id);

                Auction avm = new Auction
                {
                    Description = p.Description,
                    Title = p.Title,
                    AuctionValue = p.AuctionValue,
                    AuctionTimer = p.AuctionTimer,
                    StartDate = p.StartDate,
                    EndtDate = p.EndtDate,
                    TimeLeft = p.EndtDate - p.StartDate,
                };

                return View(avm);
            }

        }
        // POST: Auctions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        { Auction auction = auctionservice.GetById(id);
            auctionservice.Delete(auction);
            auctionservice.Commit();        
            return RedirectToAction("Listeauctions");
        }
        // GET: Auctions/Delete/5
        public ActionResult Deletedemand(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Auction p = new Auction();
                p = auctionservice.GetById((long)id);

                Auction avm = new Auction
                {
                    Description = p.Description,
                    Title = p.Title,
                    AuctionValue = p.AuctionValue,
                    AuctionTimer = p.AuctionTimer,
                    StartDate = p.StartDate,
                    EndtDate = p.EndtDate,
                    TimeLeft = p.EndtDate - p.StartDate,
                };

                return View(avm);
            }

        }
        // POST: Auctions/Delete/5
        [HttpPost]
        public ActionResult Deletedemand(int id, FormCollection collection)
        {
            Auction auction = auctionservice.GetById(id);
            auctionservice.Delete(auction);
            auctionservice.Commit();
            return RedirectToAction("ListeDemandesaddauction");
        }
    }
}