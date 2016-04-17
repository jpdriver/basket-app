using System.ComponentModel.DataAnnotations;

namespace BasketApp.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Product { get; set; }

        [DisplayFormat(DataFormatString = "£{0:0.00}")]
        public double Price { get; set; }
    }
}