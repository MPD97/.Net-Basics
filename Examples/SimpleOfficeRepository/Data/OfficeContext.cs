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
            modelBuilder.Entity<Desk>()
                .HasData(new
                {
                   DeskId = 1,
                   PersonId = 1,

                    
                }
             );
        }
    }
}
