using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimpleOfficeRepositoryCore.Data.Entities;


namespace SimpleOfficeRepositoryCore.Data.Migrations
{
    class OfficeContextFactory : IDesignTimeDbContextFactory<OfficeContext>
    {
        public OfficeContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return new OfficeContext(new DbContextOptionsBuilder<OfficeContext>().Options, config);
        }
    }
}
