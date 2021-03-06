﻿using BasketApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
        public void Basic_No_Discounts()
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
            Assert.AreEqual(0.00, basket.Discounts);
            Assert.AreEqual(basket.GrossTotal, basket.Total);
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
        public void Discount_for_2_Bread_2_Butter()
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
            Assert.AreEqual(0.5, basket.Discounts);
        }

        // check offer logic still works for totals with increased volumes
        [TestMethod]
        public void Total_for_3_Bread_6_Butter()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(6.3, basket.Total);
        }

        // check offer logic still works for discounts with increased volumes
        [TestMethod]
        public void Discount_for_3_Bread_6_Butter()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(1.5, basket.Discounts);
        }

        // check offer logic still works for totals with uneven volumes
        [TestMethod]
        public void Total_for_6_Bread_3_Butter()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(7.9, basket.Total);
        }

        // check offer logic still works for discounts with uneven volumes
        [TestMethod]
        public void Discount_for_6_Bread_3_Butter()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 1, Product = "Butter", Price = 0.8 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 },
                new Item { ItemID = 3, Product="Bread", Price = 1.0 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(0.5, basket.Discounts);
        }

        [TestMethod]
        public void Total_for_3_Milk()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
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
        public void Discount_for_3_Milk()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(0.00, basket.Discounts);
            Assert.AreEqual(basket.GrossTotal, basket.Total);
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
        public void Discount_for_4_Milk()
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
            Assert.AreEqual(1.15, basket.Discounts);
        }

        // check offer logic still works for totals with increased volumes
        [TestMethod]
        public void Total_for_7_Milk()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(6.9, basket.Total);
        }

        // check offer logic still works for discounts with increased volumes
        [TestMethod]
        public void Discount_for_7_Milk()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(1.15, basket.Discounts);
        }

        // check offer logic still works for totals with increased volumes
        [TestMethod]
        public void Total_for_8_Milk()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(6.9, basket.Total);
        }

        // check offer logic still works for discounts with increased volumes
        [TestMethod]
        public void Discount_for_8_Milk()
        {
            var basket = new Basket { BasketItems = new List<BasketItem>() };
            var items = new List<Item>
            {
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 },
                new Item { ItemID = 2, Product = "Milk", Price = 1.15 }
            };
            foreach (var item in items)
            {
                basket.BasketItems.Add(new BasketItem { Item = item });
            }
            Assert.AreEqual(2.3, basket.Discounts);
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

        [TestMethod]
        public void Discounts_for_2_Butter_1_Bread_8_Milk()
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
            Assert.AreEqual(2.8, basket.Discounts);
        }

        // check we can pinpoint exactly which items discounts were given on
        [TestMethod]
        public void Individual_Discounts_for_2_Butter_1_Bread_8_Milk()
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
            Assert.AreEqual(2.8, basket.Discounts);
            Assert.IsTrue(basket.BasketItems.ElementAt(0).Discount == 0);
            Assert.IsTrue(basket.BasketItems.ElementAt(1).Discount == 0);
            Assert.IsTrue(basket.BasketItems.ElementAt(2).Discount == 0);
            Assert.IsTrue(basket.BasketItems.ElementAt(3).Discount == 0);
            Assert.IsTrue(basket.BasketItems.ElementAt(4).Discount == 0);
            Assert.IsTrue(basket.BasketItems.ElementAt(5).Discount == 1.15); // 4th Milk
            Assert.IsTrue(basket.BasketItems.ElementAt(6).Discount == 0);
            Assert.IsTrue(basket.BasketItems.ElementAt(7).Discount == 0);
            Assert.IsTrue(basket.BasketItems.ElementAt(8).Discount == 0);
            Assert.IsTrue(basket.BasketItems.ElementAt(9).Discount == 1.15); // 8th Milk
            Assert.IsTrue(basket.BasketItems.ElementAt(10).Discount == 0.5); // Bread w/ 2 Butter
        }
    }
}
