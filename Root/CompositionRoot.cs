using BL.ServicePattern;
using BL.Services;
using BL.Services.Impl;
using Data.Repositories;
using Data.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Root
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void injectDependencies(IServiceCollection services,  string connectionString)
        {
            #region // databases injection
            services.AddDbContext<MyDataBaseContext>(opts => opts.UseSqlServer(connectionString, b => b.MigrationsAssembly("Data")));
            services.AddScoped<MyDataBaseContext>();
            #endregion

            #region // generic repo and services injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IServicePattern<>), typeof(ServicePattern<>));
            #endregion


            #region // repositories injection
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<ITownRepository, TownRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IBusninessTypeRepository, BusninessTypeRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            // the implementation of IPlacesRepositoy is gonna be replaced by Places Repository
            services.AddScoped<IPlacesRepository, MockPlacesRepository>();

            
            #endregion

            #region // services injection
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<ITownService, TownService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IBusninessTypeService, BusninessTypeService>();
            services.AddScoped<ICampaignService, CampaignService>();

            services.AddScoped<IRoleService, RoleService>();
            


            #endregion

            //services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
