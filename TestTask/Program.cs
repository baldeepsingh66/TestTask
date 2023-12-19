using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TestTask;
using TestTask.IService;
using TestTask.Repository;
using TestTask.Service;

namespace TestTask
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
                    webBuilder.UseStartup<Startup>();
                });
    }
}
