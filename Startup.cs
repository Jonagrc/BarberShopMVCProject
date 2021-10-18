using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Services;
using BarberShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BarberShop
{//TODO add Nuget packages for MySql,entities framework 
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository, DBRepository>();//need to register the services here NEXT inject services  //should use Scooped

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddIdentity<User, IdentityRole>(options =>
            {
                //Set options for identity
                options.Password.RequiredLength = 8;


            }).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                   "Server=GARCIADIBLAPTOP;Database=BarbershopDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext applicationDbContext)
        {
            //applicationDbContext.Database.EnsureDeleted();
             applicationDbContext.Database.EnsureCreated(); /*only when working with model builder */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseRouting();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
