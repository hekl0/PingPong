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

namespace FinalProject {
    public class Program {

        public static void Main (string[] args) {
            //hubContext = GlobalHost.ConnectionManager.GetHubContext< GameHub>();
            Game test = new Game();
            test.id = "test";
            GameHub.games.Add(test);
            var host = CreateWebHostBuilder (args).Build ();
            Timer timer = new Timer (1000);
            timer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) => {
                using (var serviceScope = host.Services.CreateScope ()) {
                    var services = serviceScope.ServiceProvider;
                    try {
                        var hubContext = services.GetRequiredService<IHubContext<GameHub>> ();
                        foreach (Game game in GameHub.games) {
                            game.calculate();
                            hubContext.Clients.Group (game.id).SendAsync ("ReceiveData", game);
                        }
                    } catch (Exception ex) {
                        
                    }

                }
            };
            timer.AutoReset = true;
            timer.Enabled = true;
            host.Run ();
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ();

    }
}