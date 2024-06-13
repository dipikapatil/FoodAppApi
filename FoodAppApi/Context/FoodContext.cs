using FoodAppApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Context
{
    public class FoodContext:DbContext
    {
        public FoodContext(DbContextOptions options) : base(options) { }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; }
       
    }
}
