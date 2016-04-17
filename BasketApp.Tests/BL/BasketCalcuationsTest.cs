using BasketApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BasketApp.Tests.BL
{
    [TestClass]
    public class BasketCalcuationsTest
    {
        [TestMethod]
        public void Basic_GrossTotal()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(2.95, basket.Total);
        }

        [TestMethod]
        public void Total_for_2_Bread_2_Butter()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(3.10, basket.Total);
        }

        [TestMethod]
        public void Total_for_4_Milk()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(3.45, basket.Total);
        }

        [TestMethod]
        public void Total_for_2_Butter_1_Bread_8_Milk()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 3, Product = "Bread", Price = 1.0 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(9.00, basket.Total);
        }
    }
}
