﻿using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimpleOfficeRepository.Data.Entities;


namespace SimpleOfficeRepository.Data.Migrations
{
    class OfficeContextFactory : IDesignTimeDbContextFactory<OfficeContext>
    {
        public OfficeContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

        }
    }
}
