using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppShop.Model;

namespace WebAppShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavController : ControllerBase
    {
        private ProductContext _context;

        public FavController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.FavProd.ToList();
        }

        //GetById Products
        [HttpGet("{id}", Name = "GetFavProduct")]
        public IActionResult GetById(long id)
        {
            var item = _context.FavProd.FirstOrDefault(t => t.FavId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //Create new resource in the data store
        [HttpPost]
        [Route("{ProdId}/{ProductNameCart}/{CategoryCart}/{PriceCart}/{ShopTypeCart}")]
        public IActionResult Create([FromRoute] int ProdId, [FromRoute] string ProductNameCart, [FromRoute] String CategoryCart, [FromRoute] int PriceCart, [FromRoute] string ShopTypeCart)
        {

            var item = new Favourite
            {
                ProdId = ProdId,
                ProductNameFav = ProductNameCart,
                CategoryFav = CategoryCart,
                PriceFav = PriceCart,
                ShopTypeFav = ShopTypeCart
            };
            _context.FavProd.Add(item);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = item.ProdId }, item);
        }

        //Update existing data from data sever
        [HttpPut]
        public void Update([FromBody] Favourite item)
        {

            _context.FavProd.Update(item);
            _context.SaveChanges();

        }

        //Delete existing resource from data store
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prod = _context.FavProd.FirstOrDefault(t => t.FavId == id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.FavProd.Remove(prod);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
