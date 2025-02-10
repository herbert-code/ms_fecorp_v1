using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSFercorp.Gateway
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
                    webBuilder.ConfigureAppConfiguration((host, config) =>
                    {
                        //config.AddJsonFile("ocelot.json", optional: false);

                        config.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
                        config.AddJsonFile($"ocelot.{host.HostingEnvironment.EnvironmentName}.json", optional: true);
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
