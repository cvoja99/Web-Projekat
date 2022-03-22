using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekatWP_bar.Model;
using Microsoft.EntityFrameworkCore;

namespace projekatWP_bar.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        public ClubContext Context { get; set; }
        public UserController(ClubContext context)
        {
            Context = context;
        }
        [Route("")]
        [HttpGet]
        public async Task<List<User>> PreuzmiUsere()
        {
            return await Context.Users.ToListAsync();
        }
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> NapraviUsera([FromBody] User user)
        {
            var foundUser = (await Context.Users.Where(x => x.Email == user.Email).ToListAsync()).FirstOrDefault();
            if (foundUser!= null)
                return BadRequest();
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
            return Ok(user);
        }
        [Route("{email}")]
        [HttpPost]
        public async Task<IActionResult> NadjiUsera([FromRoute] string email)
        {
            var foundUser = (await Context.Users.Where(x => x.Email==email).ToListAsync()).FirstOrDefault();
            if (foundUser == null)
                return BadRequest();
            return Ok(foundUser);
        }
    }
}
