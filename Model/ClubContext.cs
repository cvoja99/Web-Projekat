using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace projekatWP_bar.Model
{
    public class ClubContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Club> Clubovi { get; set; }
            public DbSet<Event> Eventi { get; set; }
            public DbSet<Vote> Votes { get; set; }
            public DbSet<AttendingEvent> AttendingEvents { get; set; }
            public ClubContext(DbContextOptions options) : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder mb)
            {
            mb.Entity<User>().HasMany(q => q.Vote).WithOne(p => p.Voter).OnDelete(DeleteBehavior.Cascade);
            mb.Entity<User>().HasMany(q => q.Eventi).WithOne(p => p.Attendee).OnDelete(DeleteBehavior.Cascade);
            mb.Entity<Event>().HasMany(q => q.Gosti).WithOne(p => p.Event).OnDelete(DeleteBehavior.Cascade);
            mb.Entity<Event>().HasMany(q => q.Glasovi).WithOne(p => p.Event).OnDelete(DeleteBehavior.Cascade);
            mb.Entity<Club>().HasMany(q => q.listaEventova).WithOne(p => p.Klub).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
