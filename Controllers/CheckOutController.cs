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
    public class CheckOutController : ControllerBase
    {
        private ProductContext _context;

        public CheckOutController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.CheckOuts.ToList();
        }

        //GetById Products
        [HttpGet("{id}", Name = "GetCheckOutProduct")]
        public IActionResult GetById(long id)
        {
            var item = _context.CheckOuts.FirstOrDefault(t => t.CheckOutId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //Create new resource in the data store
        [HttpPost]
        [Route("{ProdId}/{ProductNameCheckOut}/{CategoryCheckOut}/{PriceCheckOut}/{ShopTypeCheckOut}")]
        public IActionResult Create([FromRoute] int ProdId, [FromRoute] string ProductNameCheckOut, [FromRoute] string CategoryCheckOut, [FromRoute] int PriceCheckOut, [FromRoute] string ShopTypeCheckOut)
        {

            var item = new CheckOut
            {
                ProdId = ProdId,
                ProductNameCheckOut = ProductNameCheckOut,
                CategoryCheckOut = CategoryCheckOut,
                PriceCheckOut = PriceCheckOut,
                ShopTypeCheckOut = ShopTypeCheckOut,
                
            };
            _context.CheckOuts.Add(item);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = item.ProdId }, item);
        }

        //Update existing data from data sever
        [HttpPut]
        public void Update([FromBody] CheckOut item)
        {

            _context.CheckOuts.Update(item);
            _context.SaveChanges();

        }

        //Delete existing resource from data store
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prod = _context.CheckOuts.FirstOrDefault(t => t.CheckOutId == id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.CheckOuts.Remove(prod);
            _context.SaveChanges();
            return new NoContentResult();
        }

        

    }
}
