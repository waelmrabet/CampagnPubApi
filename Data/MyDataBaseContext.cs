using Core.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class MyDataBaseContext : DbContext
    {
        // just for test
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        // real object for compagn Pub App
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<BusinessType> businessTypes { get; set; }       
        public DbSet<Compagn> Compagns { get; set; }
        public DbSet<CompagnBusiness> CompagnBusinesses { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public MyDataBaseContext(DbContextOptions<MyDataBaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CompagnBusinessConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
