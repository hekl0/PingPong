using System;
using System.Linq;
using FinalProject.Hubs;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{

    [ApiController]
    public class LoginController : ControllerBase
    {
        UserDB db = new UserDB();
        [HttpGet("api/Login/{room}/{password}/create")]
        public ActionResult CreateAccount(string room, string password)
        {
            foreach (Game game in GameHub.games)
                if (game.id == room)
                    return BadRequest("user already exists");

            User newUser = new User();
            newUser.id = room;
            newUser.password = password;
            db.users.Add(newUser);
            db.SaveChanges();
            // GameHub.games.Add(newGame);
            return Ok();
        }

        [HttpGet("api/Login/{room}/{password}/login")]
        public ActionResult Login(string room, string password)
        {
            foreach (User user in db.users)
            {
                if (user.id == room && user.password == password)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("either room or password is incorrect");
                }
            }

            return BadRequest("Room doesn't exist");
        }
    }
}