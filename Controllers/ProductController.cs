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
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;

            if (_context.Products.Count() == 0)
            {
                _context.Products.Add(new Product
                {
                    ProductName = "Long Board",
                    Category = "Boards",
                    Price = 400,
                    ShopType = "StreetShop",
                });

                _context.Products.Add(new Product
                {
                    ProductName = "Penny Board",
                    Category = "Boards",
                    Price = 200,
                    ShopType = "StreetShop",
                });

                _context.Products.Add(new Product
                {
                    ProductName = "Skate Board",
                    Category = "Boards",
                    Price = 300,
                    ShopType = "StreetShop",
                });
                _context.SaveChanges();
            }
        }

        //GetAll Products
        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.Products.ToList();
        }

        //GetById Products
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(long id)
        {
            var item = _context.Products.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //Create new resource in the data store
        [HttpPost]
        public IActionResult Create([FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Products.Add(item);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = item.Id }, item);
        }

        //Update existing data from data sever
        [HttpPut]
        public void  Update( [FromBody] Product item)
        {

            _context.Products.Update(item);
            _context.SaveChanges();

        }

        //Delete existing resource from data store
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prod = _context.Products.FirstOrDefault(t => t.Id == id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Products.Remove(prod);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
