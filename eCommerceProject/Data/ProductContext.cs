﻿using eCommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceProject.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options){}

        public DbSet<Product> Products { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
