﻿using BasketApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BasketApp.BL
{
    public class BasketCalculations
    {
        public void CalculateDiscount(ICollection<BasketItem> basketItems)
        {
            if (basketItems != null)
            {
                // group the BasketItems by ItemID and return a list of { ItemID, List<BasketItem> }
                var basketItemsGrouped = basketItems.GroupBy(g => g.Item.ItemID).Select(s => new { ItemID = s.Key, BasketItems = s.ToList() });

                // init lists for each item type
                // means calculations are not affected by missing types
                var butter = new List<BasketItem>();
                var milk = new List<BasketItem>();
                var bread = new List<BasketItem>();

                // get each separate list by ItemID (assumed to correspond to Butter / Milk / Bread based on values seeded in BasketAppInitializer)
                if (basketItemsGrouped.Where(w => w.ItemID == 1).Any())
                {
                    butter = basketItemsGrouped.Where(w => w.ItemID == 1).FirstOrDefault().BasketItems;
                }
                if (basketItemsGrouped.Where(w => w.ItemID == 2).Any())
                {
                    milk = basketItemsGrouped.Where(w => w.ItemID == 2).FirstOrDefault().BasketItems;
                }
                if (basketItemsGrouped.Where(w => w.ItemID == 3).Any())
                {
                    bread = basketItemsGrouped.Where(w => w.ItemID == 3).FirstOrDefault().BasketItems;
                }

                // OFFER 1:
                // Buy 2 Butter and get a Bread at 50% off 
                // TODO

                // OFFER 2:
                // Buy 3 Milk and get the 4th milk for free
                // TODO
            }
        }
    }
}