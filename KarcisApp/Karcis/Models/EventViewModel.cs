using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Karcis.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    [JsonObject]
    public class EventViewModel
    {
        [JsonProperty("eventID")]
        public int EventID { get; set; }
        [JsonProperty("eventName")]
        public string EventName { get; set; }
        [JsonProperty("eventStart")]
        public DateTime EventStart { get; set; }
        [JsonProperty("eventEnd")]
        public DateTime EventEnd { get; set; }
        [JsonProperty("eventDescription")]
        public string EventDescription { get; set; }
        
        [JsonProperty("eventLocation")]
        public string EventLocation { get; set; }

        public int Days => (EventEnd - DateTime.Now).Days;

        public string EventEndDate => EventEnd.Date.ToString();

        public int UserID { get; set; }
        public string UserName { get; set; }
    }

    [JsonObject]
    public class Events
    {
        [JsonProperty("events")]
        public List<EventViewModel> events { get; set; }
    }

    public class HomeViewModel
    {

        public EventViewModel Event { get; set; }
        public UserModel User { get; set; }
    }
}
