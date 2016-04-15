using BasketApp.DAL;
using BasketApp.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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

        // POST: Baskets/AddButter
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddButter([Bind(Include = "BasketID")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                // ItemID assumed from values seeded in BasketAppInitializer
                var butter = db.Items.Where(w => w.ItemID == 1).FirstOrDefault();
                AddItem(basket, butter);
            }
            return RedirectToAction("BasketDetails/" + basket.BasketID);
        }

        // POST: Baskets/AddMilk
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMilk([Bind(Include = "BasketID")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                // ItemID assumed from values seeded in BasketAppInitializer
                var milk = db.Items.Where(w => w.ItemID == 2).FirstOrDefault();
                AddItem(basket, milk);
            }
            return RedirectToAction("BasketDetails/" + basket.BasketID);
        }

        // POST: Baskets/AddBread
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBread([Bind(Include = "BasketID")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                // ItemID assumed from values seeded in BasketAppInitializer
                var bread = db.Items.Where(w => w.ItemID == 3).FirstOrDefault();
                AddItem(basket, bread);
            }
            return RedirectToAction("BasketDetails/" + basket.BasketID);
        }

        private void AddItem(Basket basket, Item item)
        {
            basket = db.Baskets.Find(basket.BasketID);
            // create a new BasketItem linking the BasketID with the ItemID
            basket.BasketItems.Add(new BasketItem { BasketID = basket.BasketID, ItemID = item.ItemID });
            db.Entry(basket).State = EntityState.Modified;
            db.SaveChanges();
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
