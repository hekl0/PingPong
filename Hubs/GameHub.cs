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
                    Console.WriteLine(game.paddle[1].occupied);
                    Console.WriteLine(game.paddle[2].occupied);
                    if (game.paddle[1].occupied != "" && game.paddle[2].occupied != "") {
                        Console.WriteLine ("Room is full");
                        return;
                    }  
                    if (game.paddle[1].occupied == "" && game.paddle[2].occupied != Context.ConnectionId) {
                        game.paddle[1].occupied = Context.ConnectionId;
                        await Groups.AddToGroupAsync (Context.ConnectionId, groupName);
                        await Clients.Caller.SendAsync ("ReceiveIndex", 1);
                    } else if (game.paddle[2].occupied == "" && game.paddle[1].occupied != Context.ConnectionId) {
                        game.paddle[2].occupied = Context.ConnectionId;
                        await Groups.AddToGroupAsync (Context.ConnectionId, groupName);
                        await Clients.Caller.SendAsync ("ReceiveIndex", 2);
                    }
                    else break;
                    game.numplayer++;
                    if(game.paddle[1].occupied != "" && game.paddle[2].occupied != "") {
                        await Task.Delay(1000);
                        await Clients.Group(game.id).SendAsync ("StartGame");
                        game.inGame = true;
                        game.gameOver = false;
                    }
                    break;
                }
            }
        }

        public override async Task OnDisconnectedAsync (Exception exception) {
            foreach (Game game in games) {
                if (game.paddle[1].occupied == Context.ConnectionId) {
                    await Groups.RemoveFromGroupAsync (Context.ConnectionId, game.id);
                    game.paddle[1].occupied = "";
                    game.numplayer--;
                    break;
                }
                if (game.paddle[2].occupied == Context.ConnectionId) {
                    await Groups.RemoveFromGroupAsync (Context.ConnectionId, game.id);
                    game.paddle[2].occupied = "";
                    game.numplayer--;
                    break;
                }
            }
            await base.OnDisconnectedAsync (exception);
        }

        public async Task movePaddle(int index, int dir, string groupID) {
            foreach (Game game in games) {
                if (game.id == groupID) {
                    game.paddle[index].x += dir * Constants.paddleSpeed;
                    if (game.paddle[index].x < Constants.paddleSize / 2 + 1) game.paddle[index].x = Constants.paddleSize / 2 + 1;
                    if (game.paddle[index].x > Constants.mapWidth - Constants.paddleSize / 2 - 1) game.paddle[index].x = Constants.mapWidth - Constants.paddleSize / 2 - 1;
                    break;
                }
            }
        }

        public async Task restartGame (string groupID) {
            foreach (Game game in games) {
                if (game.id == groupID) {
                    if (game.paddle[1].occupied == "") {
                        game.paddle[1].occupied = Context.ConnectionId;
                        await Groups.AddToGroupAsync (Context.ConnectionId, groupID);
                        await Clients.Caller.SendAsync ("ReceiveIndex", 1);
                    } else if (game.paddle[2].occupied == "") {
                        game.paddle[2].occupied = Context.ConnectionId;
                        await Groups.AddToGroupAsync (Context.ConnectionId, groupID);
                        await Clients.Caller.SendAsync ("ReceiveIndex", 2);
                    }

                    if(game.paddle[1].occupied != "" && game.paddle[2].occupied != "") {
                        await Task.Delay(1000);
                        await Clients.Group(game.id).SendAsync("StartGame");
                        game.inGame = true;
                        game.gameOver = false;
                    }
                    break;
                }
            }
        }
    }
}