using FlightAPI.Domain.Entities.Common;
using FlightAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Domain.Entities
{
    public class Endpoint : BaseEntity
    {
        public Endpoint()
        {
            Roles = new HashSet<AppRole>();
        }
        public new Guid Id { get; set; } = Guid.NewGuid();

        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }
        public Menu Menu { get; set; }
        public ICollection<AppRole> Roles { get; set; }

    }
}
