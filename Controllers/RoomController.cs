using System;
using FinalProject.Hubs;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers {

    [ApiController]
    public class RoomController : ControllerBase {

        [HttpGet("api/room/{room}/create")]
        public ActionResult CreateRoom(string room)
        {
            foreach (Game game in GameHub.games) 
                if (game.id == room) 
                    return BadRequest("Room already exists");

            Game newGame = new Game();
            newGame.id = room;
            GameHub.games.Add(newGame);

            return Ok();
        }

        [HttpGet("api/room/{room}/join")]
        public ActionResult JoinRoom(string room)
        {
            foreach (Game game in GameHub.games)
                if (game.id == room) { 
                    if (game.numplayer == 2) return BadRequest("Room is full");
                    if (game.inGame) return BadRequest("Room is in game");
                    return Ok();
                }

            return BadRequest("Room doesn't exist");
        }
    }
}