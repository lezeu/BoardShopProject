using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using WebAppShop.Model;
using Newtonsoft.Json;

namespace WebAppShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase 
    {
        private ProductContext _context;

        public CartController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.ShoppingCarts.ToList();
        }

        //GetById Products
        [HttpGet("{id}", Name = "GetCartProduct")]
        public IActionResult GetById(long id)
        {
            var item = _context.ShoppingCarts.FirstOrDefault(t => t.CartId == id);
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

            var item = new Cart {
                ProdId = ProdId,
                ProductNameCart = ProductNameCart,
                CategoryCart = CategoryCart,
                PriceCart = PriceCart,
                ShopTypeCart = ShopTypeCart
            };
            _context.ShoppingCarts.Add(item);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = item.ProdId }, item);
        }

        //Update existing data from data sever
        [HttpPut]
        public void Update([FromBody] Cart item)
        {

            _context.ShoppingCarts.Update(item);
            _context.SaveChanges();

        }

        //Delete existing resource from data store
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prod = _context.ShoppingCarts.FirstOrDefault(t => t.CartId == id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.ShoppingCarts.Remove(prod);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
