﻿using FlightAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public new Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
