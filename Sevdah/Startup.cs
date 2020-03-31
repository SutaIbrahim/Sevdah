using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sevdah.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;

namespace Sevdah
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

            string connectionString = Configuration.GetConnectionString("SevdahLocal_Development");
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

            //tacka i zarez konfilt - https://dotnetcoretutorials.com/2017/06/22/request-culture-asp-net-core/
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-GB"); //en-US kod datuma prvo stavi mjesec pa dan a en-GB prvo dan pa mjesec
            });

            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();

            app.UseStaticFiles();

            //tacka i zarez konfilt
            app.UseRequestLocalization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
