﻿using FlightAPI.Application.Repositories;
using FlightAPI.Domain.Entities;
using FlightAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Persistence.Repositories
{
    public class FlightWriteRepository : WriteRepository<Flight>, IFlightWriteRepository
    {
        public FlightWriteRepository(FlightAPIDbContext context) : base(context)
        {
        }
    }
}
