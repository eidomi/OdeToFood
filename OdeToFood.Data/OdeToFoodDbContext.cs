﻿using Microsoft.EntityFrameworkCore;
using OddToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {
            
        }
        public DbSet<Resturant> Resturant { get; set; }
    }
}