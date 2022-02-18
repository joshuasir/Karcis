using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Model.DTO
{
    public class TicketDTO
    {
        public string EventName { get; set; }

        public string TicketType { get; set; }


    }

    public class OrderTicketDTO
    {
        public string EventName { get; set; }

        public string TicketType { get; set; }

        public int Qty { get; set; }

    }

    public class CreateTicketDTO
    {
        public Ticket TicketData { get; set; }

        public int Qty { get; set; }

    }

}
