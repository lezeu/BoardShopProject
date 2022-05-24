using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppShop.Model
{
    public class Cart 
    {
        [Key]
        public int CartId { get; set; }
        
        public int ProdId { get; set; }

        [Required]
        public string ProductNameCart { get; set; }

        [Required]
        public string CategoryCart { get; set; }

        [Required]
        public int PriceCart { get; set; }

        [Required]
        public string ShopTypeCart { get; set; }

        

        ///public List<CartItem> CartItems;

    }
}
