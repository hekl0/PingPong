using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using FinalProject.Hubs;
using FinalProject.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinalProject
{
    public class Program
    {

        public static void Main(string[] args)
        {
            List<Pong> games = new List<Pong>();
            //hubContext = GlobalHost.ConnectionManager.GetHubContext< GameHub>();
            var host = CreateWebHostBuilder(args).Build();
            Timer timer = new Timer(1000);
            timer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) =>
            {
                using (var serviceScope = host.Services.CreateScope())
                {
                    var services = serviceScope.ServiceProvider;
                    try
                    {
                        GameHub.pong.calculate();
                        var hubContext = services.GetRequiredService<IHubContext<GameHub>>();
                        if (hubContext.Clients.All == null) Console.WriteLine("axx");
                        Console.WriteLine(GameHub.pong.x);
                        Console.WriteLine(GameHub.pong.y);
                        Console.WriteLine(GameHub.pong.paddle[1]);
                        Console.WriteLine(GameHub.pong.paddle[1].x);
                        Console.WriteLine(Constants.upperPaddle);
                        hubContext.Clients.All
                            .SendAsync("ReceiveData",
                                 GameHub.pong.x, GameHub.pong.y, 
                                 GameHub.pong.paddle[1].x, Constants.upperPaddle, 
                                 GameHub.pong.paddle[2].x, Constants.lowerPaddle);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            };

            timer.AutoReset = true;
            timer.Enabled = true;

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}