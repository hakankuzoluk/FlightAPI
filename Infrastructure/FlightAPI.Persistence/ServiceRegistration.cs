using FlightAPI.Application.Abstractions;
using FlightAPI.Application.Repositories;
using FlightAPI.Persistence.Concretes;
using FlightAPI.Persistence.Contexts;
using FlightAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<FlightAPIDbContext>(options => options.UseMySQL(Configuration.ConnectionString));
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IReservationReadRepository, ReservationReadRepository>();
            services.AddScoped<IReservationWriteRepository, ReservationWriteRepository>();
            services.AddScoped<IFlightReadRepository, FlightReadRepository>();
            services.AddScoped<IFlightWriteRepository, FlightWriteRepository>();
        }
    }
}
