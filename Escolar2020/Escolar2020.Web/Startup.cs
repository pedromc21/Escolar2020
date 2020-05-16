namespace Escolar2020.Web
{
    using Escolar2020.Web.Data;
    using Escolar2020.Web.Data.Entity;
    using Escolar2020.Web.Helpers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
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
            services.AddIdentity<App_User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<DataContext>();

            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            //Ejecuta el llenado de la Base de datos y mata la conexion al terminar
            services.AddTransient<SeedDb>();
            //La Inyeccion Queda viva
            services.AddScoped<ITutorRepository, TutorRepository>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
                app.UseExceptionHandler("/Error");
            }
            /*else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }*/

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            /*Nuevo
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });*/
            //______
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
