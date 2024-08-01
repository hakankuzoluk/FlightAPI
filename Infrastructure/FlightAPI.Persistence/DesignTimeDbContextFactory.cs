using FlightAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FlightAPIDbContext>
    {
        public FlightAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<FlightAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseMySQL(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
