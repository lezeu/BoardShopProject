using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppShop.Model
{
    public class CheckOut
    {
        [Key]
        public int CheckOutId { get; set; }

        public int ProdId { get; set; }

        public string ProductNameCheckOut { get; set; }

        public string CategoryCheckOut { get; set; }

        public int PriceCheckOut { get; set; }

        public string ShopTypeCheckOut { get; set; }
    }
}
