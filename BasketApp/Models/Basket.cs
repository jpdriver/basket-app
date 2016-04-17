using BasketApp.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BasketApp.Models
{
    public class Basket
    {
        [DisplayName("Basket ID")]
        public int BasketID { get; set; }

        [DisplayName("Items")]
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        [NotMapped]
        [DisplayName("Gross Total")]
        [DisplayFormat(DataFormatString = "£{0:0.00}")]
        public double GrossTotal {
            get
            {
                if (BasketItems == null)
                {
                    return 0.0;
                }
                return Math.Round(BasketItems.Sum(b => b.Item.Price), 2);
            }
        }

        [NotMapped]
        [DisplayFormat(DataFormatString = "-£{0:0.00}")]
        public double Discounts {
            get
            {
                if (BasketItems == null)
                {
                    return 0.0;
                }
                var calculator = new BasketCalculations();
                calculator.CalculateDiscount(BasketItems);
                return Math.Round(BasketItems.Sum(b => b.Discount), 2);
            }
        }

        [NotMapped]
        [DisplayFormat(DataFormatString = "£{0:0.00}")]
        public double Total
        {
            get
            {
                if (BasketItems == null)
                {
                    return 0.0;
                }
                return Math.Round(GrossTotal - Discounts, 2);
            }
        }
    }
}