using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Data;
using FlowerSaleStore.WebUI.Infrastructure;
using FlowerSaleStore.WebUI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IOrder, OrderRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddDbContext<FlowerSaleStoreDbContext>(options => options.UseSqlServer(Configuration["Data:FlowerSaleStore:ConnectionString"]));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(

                    name: "default",
                    template: "{controller=Account}/{action=Login}"
                    );

                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{page:int}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List"
                    });



                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        page = 1
                    }); 


                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        page = 1
                    });
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
            });
        }
    }
}
