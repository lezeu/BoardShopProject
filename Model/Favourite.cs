using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppShop.Model
{
    public class Favourite
    {
        [Key]
        public int FavId { get; set; }

        public int ProdId { get; set; }

        [Required]
        public string ProductNameFav { get; set; }

        [Required]
        public string CategoryFav { get; set; }

        [Required]
        public int PriceFav { get; set; }

        [Required]
        public string ShopTypeFav { get; set; }
    }
}
