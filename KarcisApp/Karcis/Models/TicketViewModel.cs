using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Karcis.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    [JsonObject]
    public class TicketViewModel
    {
        [JsonProperty("ticketType")]
        public string TicketType { get; set; }
        [JsonProperty("qty")]
        public int Qty { get; set; }

        [JsonProperty("ticketPrice")]
        public int TicketPrice { get; set; }

        public int TotalPrice => TicketPrice * Qty;
    }
    
    public class Ticket
    { 

    }
    // Extension method used to add the middleware to the HTTP request pipeline.

}
