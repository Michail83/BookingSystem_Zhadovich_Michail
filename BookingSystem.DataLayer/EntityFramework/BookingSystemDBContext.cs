using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.DataLayer.EntityFramework
{
    public class BookingSystemDBContext : DbContext
    {
        public BookingSystemDBContext(DbContextOptions<BookingSystemDBContext> options) :base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<ArtEvent> ArtEvent { get; set; }
        public DbSet<ClassicMusic> ClassicMusics { get; set; }
        public DbSet<OpenAir> OpenAirs { get; set; }
        public DbSet<Party> Parties { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>().HasData(
                new Party
                {
                    Id = 6,
                    IventName = "SuperParty",
                    AgeLimitation = 18,
                    AmounOfTicket = 100,
                    Date = new DateTime(2021, 12, 31),
                    Place = "InResearch"
                },
                new Party
                {
                    Id = 1,
                    IventName = "MegaParty",
                    AgeLimitation = 21,
                    AmounOfTicket = 10,
                    Date = new DateTime(2021, 12, 31),
                    Place = "InResearchToo"
                });
            modelBuilder.Entity<OpenAir>().HasData(
                new OpenAir
                {
                    Id = 2,
                    IventName = "BeerFest",
                    AmounOfTicket = 2000,
                    Date = new DateTime(2021, 12, 25),
                    HeadLiner = "aassddffgg",
                    Place = "stillInReserch"
                },
                 new OpenAir
                 {
                     Id = 3,
                     IventName = "BeeeerFast",
                     AmounOfTicket = 9000,
                     Date = new DateTime(2021, 12, 23),
                     HeadLiner = "ggffddssaa",
                     Place = "stillInReserchToo"
                 });
            modelBuilder.Entity<ClassicMusic>().HasData(
                new ClassicMusic
                {
                    Id = 4,
                    IventName = "music1",
                    ConcertName = "Bah",
                    AmounOfTicket = 200,
                    Date = new DateTime(2021, 12, 23),
                    Voice = "tenor",
                    Place = "unknown"
                },
                new ClassicMusic
                {
                    Id = 5,
                    IventName = "music2",
                    ConcertName = "Babah",
                    AmounOfTicket = 200,
                    Date = new DateTime(2021, 12, 23),
                    Voice = "bas",
                    Place = "unknown"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
