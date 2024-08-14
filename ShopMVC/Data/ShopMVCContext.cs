using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ShopMVC.Models;

namespace ShopMVC.Data
{
    [Authorize(Roles = "Administrator")]
    public class ShopMVCContext : DbContext
    {

        public ShopMVCContext (DbContextOptions<ShopMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ShopMVC.Models.User> User { get; set; } = default!;
        public DbSet<ShopMVC.Models.Brand> Brand { get; set; } = default!;
        public DbSet<ShopMVC.Models.Category> Category { get; set; } = default!;
        public DbSet<ShopMVC.Models.Product> Product { get; set; } = default!;
        
    }
}
