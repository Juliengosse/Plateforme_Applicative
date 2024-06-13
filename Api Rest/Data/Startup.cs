using Api_Rest.Models;
using Api_Rest.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api_Rest.Data
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Cette méthode est appelée lors de l'exécution. Utilisez cette méthode pour ajouter des services au conteneur.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStudentPresenceRepository, StudentPresenceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Configuration de la base de données (exemple avec SQL Server)
            services.AddDbContext<Context>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));

            // Configuration des services
            services.AddControllers();

            // Configuration de Swagger
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();

            // Configuration de l'authentification JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddAuthorization();
        }

        // Cette méthode est appelée lors de l'exécution. Utilisez cette méthode pour configurer le pipeline HTTP de l'application.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
