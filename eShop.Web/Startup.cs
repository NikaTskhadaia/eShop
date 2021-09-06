using eShop.ApplicationService.ServiceInterfaces;
using eShop.ApplicationService.Services;
using eShop.DataBaseRepository;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.RepositoryInterfaces;
using eShop.DomainService.ServiceInterfaces;
using eShop.DomainService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDomainService, UserDomainService>();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<IProductApplicationService, ProductApplicationService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryDomainService, CategoryDomainService>();
            services.AddScoped<ICategoryApplicationService, CategoryApplicationService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDomainService, OrderDomainService>();
            services.AddScoped<IOrderApplicationService, OrderApplicationService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
