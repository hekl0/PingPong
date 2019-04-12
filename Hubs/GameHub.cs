using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using FinalProject.Models;

namespace FinalProject.Hubs
{
    public class GameHub : Hub
    {
        static int index = 0;
        static Pong t;
        public async Task SendGameData( Pong  x) 
        {
            await Clients.All.SendAsync("ReceiveData", x);
        }

        public override async Task OnConnectedAsync()
        {
            index++;
            await Clients.Caller.SendAsync("ReceiveIndex",index);
            await base.OnConnectedAsync();
        }

        public async Task movePaddle(int index, int dir)
        {
            t.p[index].x += dir*Constants.paddleSpeed;
            await SendGameData(t);
        }
    }
}