using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekatWP_bar.Model;
using Microsoft.EntityFrameworkCore;

namespace projekatWP_bar.Controllers
{
    public struct VoteBody
    {
        public int rating;
        public int userid;
        public int eventid;
    }
    [ApiController]
    [Route("Event")]
    public class EventController : Controller
    {
        public ClubContext Context { get; set; }
        public EventController(ClubContext context)
        {
            Context = context;
        }
        [Route("")]
        [HttpGet]
        public async Task<List<Event>> PreuzmiEvent([FromQuery(Name = "sortOrder")] string sortOrder)
        {


            var events = await Context.Eventi.Include(p => p.Izvodjac).Include(p => p.Klub).ToListAsync();
            return events;

        }
        [Route("{clubID}/{userID}")]
        [HttpPost]
        public async Task<IActionResult> NapraviEvent([FromBody] Event event1, [FromRoute] int clubID,[FromRoute] int userID)
        {
            var foundUser = await Context.FindAsync<User>(userID);
            if (foundUser == null)
                throw new Exception("User sa tim id-om nije pronadjen");
            var foundClub = await Context.FindAsync<Club>(clubID);
            if (foundClub==null)
                throw new Exception("klub sa tim ID-om nije pronadjen");
            event1.Izvodjac = foundUser;
            event1.Klub = foundClub;
            Context.Eventi.Add(event1);
            await Context.SaveChangesAsync();
            return Ok(event1);


        }   
        [Route("{EventID}")]
        [HttpPut]
        public async Task<IActionResult> IzmeniEvent([FromRoute] int EventID, [FromBody] Event event1)
        {
            try
            {
                var foundEvent = await Context.FindAsync<Event>(EventID);
                if (foundEvent == null)
                    return BadRequest("Event sa tim ID-om nije pronadjen");
                foundEvent.Ime = event1.Ime;
                foundEvent.Kategorija = event1.Kategorija;
                await Context.SaveChangesAsync();
                return Ok(event1);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        [Route("{EventID}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEvent([FromRoute] int EventID)
        {
            var foundEvent = await Context.FindAsync<Event>(EventID);
            if (foundEvent == null)
                throw new Exception("Event sa tim ID-om nije pronadjen");
            Context.Remove(foundEvent);
            await Context.SaveChangesAsync();
            return Ok(foundEvent);
        }
        
        [Route("Vote")]
        [HttpPost]
        public async Task<IActionResult> CreateVote([FromBody] Vote vote)
        {
            var foundVote = (await Context.Votes.Where(x => x.UserID == vote.UserID&& x.EventID == vote.EventID).ToListAsync()).FirstOrDefault();
            if (foundVote != null)
                return BadRequest("User already voted");
            Vote v = new Vote();
            var foundEvent = (await Context.Eventi.Where(x => x.ID == vote.EventID).Include(e => e.Izvodjac).ToListAsync()).FirstOrDefault();
            if (foundEvent == null)
                return BadRequest("Event sa tim ID-om nije pronadjen");
            var foundUser = await Context.FindAsync<User>(vote.UserID);
            if (foundUser == null)
                return BadRequest("User sa tim ID-om nije pronadjen");
            v.targetUser = foundEvent.Izvodjac;
            v.Event = foundEvent;
            v.Voter = foundUser;
            v.Rating = vote.Rating;
            Context.Votes.Add(v);
            await Context.SaveChangesAsync();
            return Ok(v);
        }
        [Route("Vote/{EventID}")]
        [HttpGet]
        public async Task<IActionResult> AverageVotes([FromRoute]int eventid)
        {
            var foundEvent = (await Context.Eventi.Where(x => x.ID == eventid).Include(e => e.Izvodjac).ToListAsync()).FirstOrDefault();
            var foundVotes = (await Context.Votes.Where (x=> x.targetUID==foundEvent.Izvodjac.ID).ToListAsync());
            int len = foundVotes.Count;
            if(len == 0)
            {
                return Ok(0);
            }
            
            float sum = 0;
            for (int i = 0; i < len; i++)
            {
                sum += foundVotes[i].Rating;
            }
            return Ok(sum/len);

        }

    }   }
