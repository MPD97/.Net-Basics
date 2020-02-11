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
    }
}
