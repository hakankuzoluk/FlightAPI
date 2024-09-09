using FlightAPI.Application.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.CustomAttributes
{
    public class AuthorizeDefinitionAttribute : Attribute, IFilterMetadata
    {
        public string Menu { get; set; }
        public string Definition { get; set; }
        public ActionType ActionType  { get; set; }
    }
}
