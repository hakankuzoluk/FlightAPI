﻿using FlightAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Repositories
{
    public interface IEndpointWriteRepository : IWriteRepository<Endpoint>
    {
    }
}
