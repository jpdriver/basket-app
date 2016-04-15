using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasketApp.DAL;
using BasketApp.Models;

namespace BasketApp.Controllers
{
    public class BasketsController : Controller
    {
        private BasketAppContext db = new BasketAppContext();

        // GET: BasketList
        public ActionResult BasketList()
        {
            return View(db.Baskets.ToList());
        }

        // GET: Baskets/BasketDetails/5
        public ActionResult BasketDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }

        // GET: Baskets/CreateBasket
        public ActionResult CreateBasket()
        {
            return View();
        }

        // POST: Baskets/CreateBasket
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBasket([Bind(Include = "BasketID")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                db.Baskets.Add(basket);
                db.SaveChanges();
                return RedirectToAction("BasketList");
            }

            return View(basket);
        }

        // GET: Baskets/EditBasket/5
        public ActionResult EditBasket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }

        // POST: Baskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BasketID")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basket);
        }

        // GET: Baskets/DeleteBasket/5
        public ActionResult DeleteBasket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }

        // POST: Baskets/DeleteBasket/5
        [HttpPost, ActionName("DeleteBasket")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBasketConfirmed(int id)
        {
            Basket basket = db.Baskets.Find(id);
            db.Baskets.Remove(basket);
            db.SaveChanges();
            return RedirectToAction("BasketList");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
