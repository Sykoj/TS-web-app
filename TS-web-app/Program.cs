using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TsWebApp {

    public class Program {

        public static void Main(string[] args) {
            
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, config) => 
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true))
                .UseStartup<Startup>();
    }
}
