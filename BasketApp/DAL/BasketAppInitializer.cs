using BasketApp.Models;
using System.Collections.Generic;

namespace BasketApp.DAL
{
    public class BasketAppInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BasketAppContext>
    {
        protected override void Seed(BasketAppContext context)
        {
            var items = new List<Item>
            {
                new Item { Product = "Butter", Price = 0.8 },
                new Item { Product = "Milk", Price = 1.15 },
                new Item { Product="Bread", Price = 1.0 }
            };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();

            var basket = new Basket();
            context.Baskets.Add(basket);
            context.SaveChanges();

            var basketItems = new List<BasketItem>
            {
                new BasketItem { BasketID = 1, ItemID = 1 },
                new BasketItem { BasketID = 1, ItemID = 2 },
                new BasketItem { BasketID = 1, ItemID = 3 }
            };
            basketItems.ForEach(b => context.BasketItems.Add(b));
            context.SaveChanges();
        }
    }
}