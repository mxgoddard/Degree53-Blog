using Degree53_BlogTechTest.Data;
using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Degree53_BlogTechTest
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IConfigurationRoot _configurationRoot;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;

            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddControllersWithViews();

            // Database configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcBlogContext")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

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
