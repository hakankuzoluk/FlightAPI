using FlightAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Repositories
{
    //Solid'e aykırı bir yapı.
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table {  get; }

    }
}
