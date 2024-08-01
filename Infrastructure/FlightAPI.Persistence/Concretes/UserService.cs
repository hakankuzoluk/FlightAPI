using FlightAPI.Application.Abstractions;
using FlightAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Persistence.Concretes
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
            => new()
            {
                new() { Password = "aaa", UserName="hako"},

                new() { Password = "bbb", UserName="hakole"},

                new() { Password = "ccc", UserName="hakolele"}
            };
    }
}
