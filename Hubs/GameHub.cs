using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.SignalR;

namespace FinalProject.Hubs {

    public class GameHub : Hub {
        static int index = 0;
        public static Pong pong = new Pong ();

        public async Task SendGameData (Pong pong) {
            await Clients.All.SendAsync ("ReceiveData", pong.x, pong.y, pong.paddle[1].x, Constants.upperPaddle, pong.paddle[2].x, Constants.lowerPaddle);
        }

        public override async Task OnConnectedAsync () {
            index++;
            await Clients.Caller.SendAsync ("ReceiveIndex", index);
            await base.OnConnectedAsync ();
        }

        public async Task movePaddle (int index, int dir) {
            Console.WriteLine("move", dir);
            pong.paddle[index].x += dir * Constants.paddleSpeed;
            await SendGameData (pong);
        }
    }
}