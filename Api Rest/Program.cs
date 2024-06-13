
using Api_Rest.Data;

namespace Api_Rest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Configuration de la classe Startup pour l'application web
                    webBuilder.UseStartup<Startup>();
                });
    }
}