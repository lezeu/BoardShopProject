using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppShop.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<LogIn> Users { get; set; }

        public DbSet<Cart> ShoppingCarts { get; set; }

        public DbSet<Favourite> FavProd { get; set; }

        public DbSet<CheckOut> CheckOuts { get; set; }

    }
}
