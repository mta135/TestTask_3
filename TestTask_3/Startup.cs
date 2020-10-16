using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Data;
using FlowerSaleStore.WebUI.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestTask_3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddDbContext<FlowerSaleStoreDbContext>(options => options.UseSqlServer(Configuration["Data:FlowerSaleStore:ConnectionString"]));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{page:int}",
                    defaults: new { controller = "Product", action = "List" }
                    );

                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new { controller = "Product", action = "List", page = 1 }
                    );

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        page = 1
                    }

                    );

                routes.MapRoute(
                    name:null,
                    template:"",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        page = 1
                    });


                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

                //routes.MapRoute(
                //    name: null,
                //    template: "Products/Pages{page}",
                //    defaults: new { Controller = "Product", action = "List" });

                //routes.MapRoute(
                //name: "default",
                //template: "{controller=Product}/{action=List}/{id?}");
            });
        }
    }
}
