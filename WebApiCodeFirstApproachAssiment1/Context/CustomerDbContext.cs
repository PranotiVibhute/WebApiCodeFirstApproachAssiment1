﻿using Microsoft.EntityFrameworkCore;
using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        { 

        }

        public DbSet<Customer>Customers{ get; set; }

        public DbSet<Product> Products{ get; set; }

        public DbSet<Order>Orders{ get; set; }
        public DbSet<OrderHistory> OrderHistorys{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=DESKTOP-NU1F9GM;" +
                "Initial Catalog=EFCompanyDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

    }
}
