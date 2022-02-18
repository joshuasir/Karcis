using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Karcis.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    [JsonObject]
    public class BookingViewModel
    {
        [JsonProperty("bookingNumber")]
        public int BookingNumber { get; set; }
        [JsonProperty("userID")]
        public int UserID { get; set; }
        [JsonProperty("userName")]
        public string Username { get; set; }
        [JsonProperty("totalPrice")]
        public int TotalPrice { get; set; }
        [JsonProperty("qty")]
        public int Qty { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class OrderDTO
    {
        public string EventName { get; set; }
        public List<TicketViewModel> Tickets { get; set; }

    }

    public class BookingDetail
    {
        public string Status { get; set; }
        public List<TicketViewModel> Tickets { get; set; }

    }

    [JsonObject]
    public class BookingHistoryViewModel
    {
        [JsonProperty("bookingNumber")]
        public int BookingNumber { get; set; }
        [JsonProperty("userID")]
        public int UserID { get; set; }
        [JsonProperty("userName")]
        public string Username { get; set; }
        [JsonProperty("totalPrice")]
        public int TotalPrice { get; set; }
        [JsonProperty("qty")]
        public int Qty { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

}
