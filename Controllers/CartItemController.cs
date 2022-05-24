/*using Microsoft.AspNetCore.Mvc;
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
    public class CartItemController : ControllerBase
    {


        private ProductContext _context;

        public CartItemController(ProductContext context)
        {
            _context = context;
        }

        /////
        ///

        [HttpGet]
        public IEnumerable GetAllCartProduct()
        {
            return _context.ShoppingCarts.ToList();
        }

        [HttpPost("{id}")]
        public IActionResult AddItem(int id)
        {
            var prod = _context.Products.FirstOrDefault(t => t.Id == id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.ItemsFromCart.Add(new CartItem
            {
                ProductId = id,
            });
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
*/