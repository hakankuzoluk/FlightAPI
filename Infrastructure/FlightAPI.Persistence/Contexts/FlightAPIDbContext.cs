using FlightAPI.Domain.Entities;
using FlightAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Persistence.Contexts
{
    public class FlightAPIDbContext : DbContext
    {
        public FlightAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas) 
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow, //Burada sadece bu ikisi vardı. Eğer 
                    _ => DateTime.UtcNow                                              //Bu kısmı yazmasaydım delete kısmında error alıyordum.
                };

            }
           return await base.SaveChangesAsync(cancellationToken);
        }

    
    
    
    
    
    }

}
