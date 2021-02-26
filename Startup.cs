using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BabyTracker.Models;
using BabyTracker.Models.ViewModels;
using BabyTracker.Models.RepositoryModels;
using BabyTracker.Models.ViewModelFactories;

namespace BabyTracker
{
    public class Startup
    {
        public IConfiguration Configuration {get; set;}
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BabyTrackerContext>(opts => 
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:BabyTrackerConnection"]);
                opts.EnableSensitiveDataLogging(true);
            });

            services.AddDbContext<IdentityContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:BTIdentityConnection"]);
            });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
            services.Configure<IdentityOptions>(opts => {
                opts.User.RequireUniqueEmail = true;
            });


            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddMvc().AddRazorRuntimeCompilation();
            // services.AddScoped<IBabyTrackerRepository, EfBabyTrackerRepository>();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BabyTrackerContext context)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Infant}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            SeedData.SeedDatabase(context);
        }
    }
}
