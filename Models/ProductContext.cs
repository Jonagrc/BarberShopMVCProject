using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Models
{//creating database and table for products 
    public class ProductContext : DbContext
    {
        //ProductContext wont behave like a DBcontext(database) if you dont inhereit from it /so you must inherit and keep the options
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)//this is calling the constructor of the base class(dbcontext)
        {

        }
        public DbSet<Product> Products { get; set; } //THIS IS THE TABLE
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {//making a model 
                    ProductId = 1,
                    ProductName = "Organic Oil Based Pomade",
                    Description = "The mixture of the therapeutic oils helps increase blood flow to the hair follicle, which also helps hair grow in its natural pattern.",
                    ProductStock = 5,
                    ProductType = ProdType.Style,
                }
                );
        }
    }

}
