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
        public DbSet<ArtEvent> ArtEvents { get; set; }
        public DbSet<ClassicMusic> ClassicMusics { get; set; }
        public DbSet<OpenAir> OpenAirs { get; set; }
        public DbSet<Party> Parties { get; set; }
        //public DbSet<OrderAndArtEvent> OrderAndArtEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ArtEvent>().HasCheckConstraint("AmounOfTicket", "AmounOfTicket >= 0");

            modelBuilder.Entity<OrderAndArtEvent>().HasKey(key => new { key.OrderId, key.ArtEventId });
            modelBuilder.Entity<OrderAndArtEvent>().HasIndex(index=> index.OrderId).IsUnique(false);
            modelBuilder.Entity<OrderAndArtEvent>().HasIndex(index => index.ArtEventId).IsUnique(false);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.ArtEvents)
                .WithMany(artEvent => artEvent.Orders)
                .UsingEntity<OrderAndArtEvent>(
                j => j
                .HasOne(a => a.ArtEvent)
                .WithMany(b => b.OrderAndArtEvents)
                .HasForeignKey(c=>c.ArtEventId),

                j=>j
                .HasOne(a=>a.Order)
                .WithMany(b=>b.OrderAndArtEvents)
                .HasForeignKey(c=>c.OrderId),

                j => {
                    j.Property(prop=>prop.NumberOfBookedTicket).HasDefaultValue(0);
                    j.HasKey(t => new { t.OrderId, t.ArtEventId });
                    j.ToTable("OrderAndArtEvents");
                    j.HasIndex(t => t.OrderId).IsUnique(false);
                    j.HasIndex(t => t.ArtEventId).IsUnique(false);
                });

            modelBuilder.Entity<ArtEvent>().Property(artEvent => artEvent.Latitude).HasColumnType("decimal(9,6)");
            modelBuilder.Entity<ArtEvent>().Property(artEvent => artEvent.Longitude).HasColumnType("decimal(9,6)");




            modelBuilder.Entity<Party>().HasData(
                new Party
                {
                    Id = 6,
                    EventName = "Fake TNT Party",
                    AgeLimitation = 18,
                    AmountOfTickets = 1500,
                    Date = new DateTime(2022, 10, 31, 19,0,0),
                    Place = "Беларусь, Минск, Революционная улица, 9А",
                    Latitude = 53.902375271214524m,
                    Longitude= 27.55158689814755m
                },
                new Party
                {
                    Id = 1,
                    EventName = " Fake Макс party",
                    AgeLimitation = 21,
                    AmountOfTickets = 300,
                    Date = new DateTime(2022, 09, 25, 22,0,0),
                    Place = "Беларусь, Минск, проспект Независимости, 73",
                    Latitude = 53.92206511236228m,
                    Longitude = 27.59704956223782m
                });
            modelBuilder.Entity<OpenAir>().HasData(
                new OpenAir
                {
                    Id = 3,
                    EventName = "Fake Gorky Party",                    
                    AmountOfTickets = 1500,
                    Date = new DateTime(2022, 12, 31, 15, 0, 0),
                    Place = "Беларусь, Минск, Первомайская улица, 3А",
                    Latitude = 53.90222207800099m,
                    Longitude = 27.57284678552759m,
                    HeadLiner = "The Best Headliner",
                    
                },
                 new OpenAir
                 {
                     Id = 2,
                     EventName = "Fake Avia Party",                     
                     AmountOfTickets = 100,
                     Date = new DateTime(2022, 07, 25, 19, 0, 0),
                     Place = "Беларусь, Минский район, Боровлянский сельсовет, деревня Копище",
                     Latitude = 53.96147426906447m,
                     Longitude = 27.65091340326826m,
                     HeadLiner = "The Best Headliner2",
                    
                 });
            modelBuilder.Entity<ClassicMusic>().HasData(
                new ClassicMusic
                {
                    Id = 4,
                    EventName = "Fake classic musik  1",
                    ConcertName = "classic musik  1",
                    AmountOfTickets = 200,
                    Date = new DateTime(2022, 07, 23,16,0,0),
                    Voice = "tenor",
                    Place = "Беларусь, Минск, проспект Независимости, 50",
                    Latitude = 53.91486434449279m,
                    Longitude = 27.584181354972173m,
                },
                new ClassicMusic
                {
                    Id = 5,
                    EventName = "Fake classic musik  2",
                    ConcertName = "classic musik  2",
                    AmountOfTickets = 250,
                    Date = new DateTime(2022, 08, 14, 17, 0, 0),
                    Voice = "bas",
                    Place = "Беларусь, Минск, проспект Независимости, 50",
                    Latitude = 53.91486434449279m,
                    Longitude = 27.584181354972173m,
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
