using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SimpleOfficeRepository.Data.Entities
{
    class OfficeContext : DbContext
    {
        private readonly IConfiguration _config;

        public OfficeContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _config = configuration;
        }

        DbSet<Desk> Desks { get; set; }
        DbSet<Office> Offices { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Office"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                 .HasData(new Person
                 {
                     PersonId = 1,
                     FirstName = "Matthew",
                     Surename = "Coolman",
                     Age = 22,
                     HireDate = new DateTime(2017, 10, 1),
                     Sex = Sex.Male
                 },
                 new Person
                 {
                     PersonId = 2,
                     FirstName = "Chris",
                     Surename = "Baldman",
                     Age = 32,
                     HireDate = new DateTime(2017, 3, 1),
                     Sex = Sex.Male
                 },
                 new Person
                 {
                     PersonId = 3,
                     FirstName = "Kate",
                     Surename = "Talklady",
                     Age = 38,
                     HireDate = new DateTime(2008, 4, 20),
                     Sex = Sex.Female
                 });
            modelBuilder.Entity<Office>()
                .HasData(new
                {
                    OfficeId = 1,
                    CompanyName = "Flying Cars Company",
                    Location = "Kornela Ujejskiego 75, 85-168 Bydgoszcz"
                },
                new
                {
                    OfficeId = 2,
                    CompanyName = "Hire Apprentice Only Company",
                    Location = "plac Politechniki 1, 00-661 Warszawa",
                }
             );
            modelBuilder.Entity<Room>()
                .HasData(new Room
                {
                   RoomId = 1,
                   RoomNumber = 233,
                   NumberOfWindows = 3,
                }, new Room
                {
                    RoomId = 2,
                    RoomNumber = 41,
                    NumberOfWindows = 2,
                }, new Room
                {
                    RoomId = 3,
                    RoomNumber = 74,
                    NumberOfWindows = 6,
                }, new Room
                {
                    RoomId = 4,
                    RoomNumber = 331,
                    NumberOfWindows = 0,
                }, new Room
                {
                    RoomId = 5,
                    RoomNumber = 15,
                    NumberOfWindows = 5,
                }
             );
        }
    }
}
