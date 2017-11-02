using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // Create database
                context.Database.EnsureCreated();

                User u = new User()
                {
                    Name = "Ginazzo",
                    Surname = "Caggeggi",
                    Age = 22,
                };

                Concert c = new Concert()
                {
                    Name = "Wacken Open Air",
                    Place = "Wacken",
                    Date = DateTime.Now,
                };

                context.Concerts.Add(c);
                context.Users.Add(u);

                context.SaveChanges();
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
