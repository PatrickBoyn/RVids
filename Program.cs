using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RVids.Data;

namespace RVids
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"http://{VideoService.GetIpAddress()}:5000");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>().UseUrls("http://localhost:5000", "http://0.0.0.0:5000"); });
    }

}