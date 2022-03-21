using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using projekatWP_bar.Model;

namespace projekatWP_bar.Controllers
{
    [Route("Klub")]
    [ApiController]
    public class ClubController : Controller
    {
        public ClubContext Context { get; set; }
        public ClubController(ClubContext context)
        {
            Context = context;
        }
        [Route("")]
        [HttpGet]
        public async Task<List<Club>> PreuzmiKlubove()
        {
            return await Context.Clubovi.ToListAsync();
        }
        [Route("")]
        [HttpPost]
        public async Task CreateClub([FromBody] Club club)
        {
            Context.Clubovi.Add(club);
            await Context.SaveChangesAsync();
        }
        [Route("{ClubID}")]
        [HttpPut]
        public async Task IzmeniClub([FromRoute] int ClubID, [FromBody] Club club)
        {
            try
            {
                var foundClub = await Context.FindAsync<Club>(ClubID);
                if (foundClub == null)
                    throw new Exception("klub sa tim ID-om nije pronadjen");
                foundClub.Ime = club.Ime;
                foundClub.Adresa = club.Adresa;
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        [Route("{ClubID}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClub([FromRoute] int ClubID)
        {
            var foundClub = await Context.FindAsync<Club>(ClubID);
            if (foundClub == null)
                throw new Exception("klub sa tim ID-om nije pronadjen");
            Context.Remove(foundClub);
            await Context.SaveChangesAsync();
            return Ok(foundClub);
        }
    }
}
