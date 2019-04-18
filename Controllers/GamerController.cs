using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
// using csc-210-final-project.Models;
using UI.Models;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamerController : ControllerBase
    {
        private readonly GamerDbContext _context;

        public GamerController(GamerDbContext context)
        {
            _context = context;

            Console.WriteLine("xxx");
            if (_context.Gamers.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Gamers.Add(new Gamer { room = "123" });
                _context.SaveChanges();
            }
        }
        // GET: api/gamer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gamer>>> GetGamers()
        {
            Console.WriteLine("xxx");
            return await _context.Gamers.ToListAsync();
        }

        // GET: api/gamer/id
        [HttpGet("/{room}")]
        public async Task<ActionResult<Gamer>> GetGamer(string room)
        {
            Console.WriteLine("xxx");
            var Gamer = await _context.Gamers.FindAsync(room);

            if (Gamer == null)
            {
                return NotFound();
            }
            else
            {
                Console.Write("worked");
            }

            return Gamer;
        }

        // GET: api/gamer/id
        // [HttpGet("{userName}/{room}")]
        // public async Task<ActionResult<Gamer>> GetGamer(string userName, string room)
        // {
        //     // var Gamer = await _context.Gamers.FindAsync(id);
        //     var Gamer = await from userName in GamerContext.Gamers where

        //     if (Gamer == null)
        //     {
        //         return NotFound();
        //     }

        //     return Gamer;
        // }

        // post: api/gamer
        [HttpPost("gamer")]
        public ActionResult Creategamer([FromBody] Gamer gamer)
        {
            // using (var db = new GamerDbContext())
            // {
            if (!ModelState.IsValid)
                return BadRequest("Bad Author");
            // var gamerId = gamer.Id;
            // gamer.room = db.Gamers.Where(a => a.Id == gamerId).First();
            _context.Gamers.Add(gamer);
            _context.SaveChanges();
            // }

            // _context.Gamers.Add(gamer);
            // await _context.SaveChangesAsync();
            return Ok();
            // return CreatedAtAction(nameof(GetGamer), new { id = gamer.Id }, gamer);
        }
    }
}