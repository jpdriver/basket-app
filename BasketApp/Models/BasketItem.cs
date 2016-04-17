using System.ComponentModel.DataAnnotations.Schema;

namespace BasketApp.Models
{
    public class BasketItem
    {
        public int ID { get; set; }
        public int BasketID { get; set; }
        public int ItemID { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual Item Item { get; set; }

        [NotMapped]
        public double Discount { get; set; }
    }
}