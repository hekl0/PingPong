using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.SignalR;

namespace FinalProject.Hubs {

    public class GameHub : Hub {
        static int index = 0;
        public static List<Game> games = new List<Game> ();

        public async Task AddToGroup (string groupName) {
            foreach (Game game in games) {
                if (game.id == groupName) {
                    if (game.paddle[1].occupied != "" && game.paddle[2].occupied != "") {
                        Console.WriteLine ("Room is full muthafuka");
                        return;
                    }
                    if (game.paddle[1].occupied == "") {
                        game.paddle[1].occupied = Context.ConnectionId;
                        await Groups.AddToGroupAsync (Context.ConnectionId, groupName);
                        await Clients.Caller.SendAsync ("ReceiveIndex", 1);
                    }
                    if (game.paddle[2].occupied == "") {
                        game.paddle[2].occupied = Context.ConnectionId;
                        await Groups.AddToGroupAsync (Context.ConnectionId, groupName);
                        await Clients.Caller.SendAsync ("ReceiveIndex", 2);
                    }
                    break;
                }    
            }
        }

        public override async Task OnDisconnectedAsync (Exception exception) {
            foreach(Game game in games) {
                if(game.paddle[1].occupied == Context.ConnectionId) {
                    await Groups.RemoveFromGroupAsync (Context.ConnectionId,game.id);
                    break;
                }
                if(game.paddle[2].occupied == Context.ConnectionId) {
                    await Groups.RemoveFromGroupAsync (Context.ConnectionId,game.id);
                    break;
                }
            }
            await base.OnDisconnectedAsync (exception);
        }



        public async Task movePaddle (int index, int dir, string groupID) {
            Console.WriteLine(Context.ConnectionId);
            foreach (Game game in games) {
                if (game.id == groupID) {
                    game.paddle[index].x += dir * Constants.paddleSpeed;
                    await Clients.Group (groupID).SendAsync ("ReceiveData", game);
                    break;
                }
            }

        }
    }
}