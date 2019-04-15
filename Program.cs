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

<<<<<<< HEAD
        public static void Main (string[] args) {
            //hubContext = GlobalHost.ConnectionManager.GetHubContext< GameHub>();
            var host = CreateWebHostBuilder (args).Build ();
            Timer timer = new Timer (1000);
            timer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) => {
                using (var serviceScope = host.Services.CreateScope ()) {
                    var services = serviceScope.ServiceProvider;
                    try {
                        var hubContext = services.GetRequiredService<IHubContext<GameHub>> ();
                        foreach (Pong game in GameHub.games) {
                            game.calculate();
                            hubContext.Clients.Group (game.id).SendAsync ("ReceiveData", game);
                        }
                    } catch (Exception ex) {

=======
        public static void Main(string[] args)
        {
            List<Pong> games = new List<Pong>();
            //hubContext = GlobalHost.ConnectionManager.GetHubContext< GameHub>();
            var host = CreateWebHostBuilder(args).Build();
            Timer timer = new Timer(1000);
            timer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) =>
            {
                    try
                    {
                        GameHub.pong.calculate();
                        var hubContext = host.Services.CreateScope().ServiceProvider.GetRequiredService<IHubContext<GameHub>>();
                        hubContext.Clients.All.SendAsync("Test", "gud shit");
                        hubContext.Clients.All
                            .SendAsync("ReceiveData",
                                 GameHub.pong.x, GameHub.pong.y, 
                                 GameHub.pong.paddle[1].x, Constants.upperPaddle, 
                                 GameHub.pong.paddle[2].x, Constants.lowerPaddle);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
>>>>>>> c80f11a3a6749374a84330e3841c2f4c66185348
                    }
                

            };

            timer.AutoReset = true;
            timer.Enabled = true;

<<<<<<< HEAD
            host.Run ();
=======
            host.Run();
>>>>>>> c80f11a3a6749374a84330e3841c2f4c66185348
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}