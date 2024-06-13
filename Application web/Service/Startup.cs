using Microsoft.AspNetCore.Authentication.Cookies;

namespace Application_web.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Cette méthode est appelée par le runtime. Utilisez cette méthode pour ajouter des services au conteneur.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddHttpClient<Application_web.Service.ApiService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5148/");
            });
        }

        // Cette méthode est appelée par le runtime. Utilisez cette méthode pour configurer le pipeline HTTP de l'application.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }


            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
