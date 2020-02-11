using Microsoft.EntityFrameworkCore.Design;
using SimpleOfficeRepository.Data.Entities;
using System;

namespace SimpleOfficeRepository.Data.Migrations
{
    class OfficeContextFactory : IDesignTimeDbContextFactory<OfficeContext>
    {
        public OfficeContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
