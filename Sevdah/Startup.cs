using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sevdah.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Sevdah.Helpers;
using System.Linq;
using Sevdah.Helpers.FloatModelBinder;
using Sevdah.Helpers.DoubleModelBinder;

namespace Sevdah
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("SevdahLocal_IIS_Host");
            //string connectionString = _configuration.GetConnectionString("SevdahLocal_Development");
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

            //tacka i zarez konfilt - https://dotnetcoretutorials.com/2017/06/22/request-culture-asp-net-core/
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(Configuration.DefaultCulture, Configuration.DefaultCulture);
                options.SupportedCultures = options.SupportedUICultures = Configuration.SupportedSystemLanguages.Select(sl => sl.CultureInfo).ToList();
            });

            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(2, new DoubleModelBinderProvider());
                options.ModelBinderProviders.Insert(3, new FloatModelBinderProvider());

            });

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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
