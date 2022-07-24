using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_APP_EF_DB_First.Models
{// This is singleton class reponsible for connecting to
    // db and doing crud operations
    public class ShoppingContext:DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options):base(options)
        {
            
        }
        public DbSet<Product> Prods { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
