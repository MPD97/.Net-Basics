using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SimpleOfficeRepositoryCore.Data.Entities
{
    public class OfficeContext : DbContext
    {
        private readonly IConfiguration _config;

        public OfficeContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _config = configuration;
        }

        public DbSet<Desk> Desks { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Office"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                });
            modelBuilder.Entity<Person>()
                .HasData(new
                {
                    PersonId = 1,
                    FirstName = "Matthew",
                    Surename = "Coolman",
                    Age = 22,
                    HireDate = new DateTime(2017, 10, 1),
                    OfficeId = 2,
                    Sex = Sex.Male
                },
                new
                {
                    PersonId = 2,
                    FirstName = "Chris",
                    Surename = "Baldman",
                    Age = 32,
                    HireDate = new DateTime(2017, 3, 1),
                    OfficeId = 1,
                    Sex = Sex.Male
                },
                new
                {
                    PersonId = 3,
                    FirstName = "Kate",
                    Surename = "Talklady",
                    Age = 38,
                    HireDate = new DateTime(2008, 4, 20),
                    OfficeId = 2,
                    Sex = Sex.Female
                });

            modelBuilder.Entity<Room>()
                .HasData(new
                {
                    RoomId = 1,
                    RoomNumber = 233,
                    OfficeId = 1,
                    NumberOfWindows = 3,
                }, new
                {
                    RoomId = 2,
                    RoomNumber = 41,
                    OfficeId = 2,
                    NumberOfWindows = 2,
                }, new
                {
                    RoomId = 3,
                    RoomNumber = 74,
                    OfficeId = 1,
                    NumberOfWindows = 6,
                }, new
                {
                    RoomId = 4,
                    RoomNumber = 331,
                    OfficeId = 1,
                    NumberOfWindows = 0,
                }, new
                {
                    RoomId = 5,
                    RoomNumber = 15,
                    OfficeId = 2,
                    NumberOfWindows = 5,
                }
             );
            modelBuilder.Entity<Desk>()
                .HasData(new
                {
                    DeskId = 1,
                    Length = 2.33,
                    Width = 1.15,
                    Height = 1.05,
                    OwnerPersonId = 1,
                    RoomId = 2
                },
                new
                {
                    DeskId = 2,
                    Length = 2.11,
                    Width = 1.35,
                    Height = 1.15,
                    OwnerPersonId = 3,
                    RoomId = 1
                }, new
                {
                    DeskId = 3,
                    Length = 1.83,
                    Width = 1.07,
                    Height = 0.95,
                    OwnerPersonId = 1,
                    RoomId = 2
                },
                new
                {
                    DeskId = 4,
                    Length = 1.70,
                    Width = 1.70,
                    Height = 1.35,
                    OwnerPersonId = 2,
                    RoomId = 4
                }
             );
        }
    }
}
