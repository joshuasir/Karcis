using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Output
{
    public class TicketOutput
    {
        public string TicketType { get; set; }
        public int Qty { get; set; }
        public int TicketPrice{ get; set; }
    }

}
