using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;namespace Bookstore

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

{
    public class Program
    {
    //Main method
        public static void Main(string[] args)
        {
        var S = 0;
        //Create host, host web
            var webHost = CreateWebHostBuilder(args).Build();

            RunMigrations(webHost);
            
            webHost.Run();
        }

        private static void RunMigrations(IWebHost webHost)
        {
            using(var scope = webHost.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BookstoreDbContext>();
                db.Database.Migrate();
            }
        }
    //Call startup
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
