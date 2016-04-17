using System.Collections.Generic;
using System.ComponentModel;

namespace BasketApp.Models
{
    public class Basket
    {
        [DisplayName("Basket ID")]
        public int BasketID { get; set; }

        [DisplayName("Items")]
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}