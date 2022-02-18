using karcis_API.Model;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Output
{
    public class EventOutput
    {
        public List<Event> events { get; set; }
    }
}
