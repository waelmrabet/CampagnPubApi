﻿using Core.CompelxeTypes;
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

        #region test dbSets
        // just for test
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Book> Books { get; set; }
        #endregion

        // real object for compagn Pub App
        
        public DbSet<User> Users { get; set; }      
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<ProductType> ProductTypes { get; set; }  
        public DbSet<Town> Towns { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<BusinessType> businessTypes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
              
        // campaignBusnisses
        public DbSet<CampaignBusiness> CompaignBusinesses { get; set; }
               
        // CampaignProducts
        public DbSet<Product> Products { get; set; }

        public MyDataBaseContext(DbContextOptions<MyDataBaseContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Campaign Configurations
            modelBuilder.ApplyConfiguration(new CampaignConfigurations());
                        
            // Campaign Business Configurations
            modelBuilder.ApplyConfiguration(new CampaignBusinessConfigurations());            

            // Campaign Product Configurations
            modelBuilder.ApplyConfiguration(new CampaignProductsConfiguration());

            // Product types Configurations
            modelBuilder.ApplyConfiguration(new ProductTypeConfigurations());

            // Customer Configurations
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            
        }
    }
}
