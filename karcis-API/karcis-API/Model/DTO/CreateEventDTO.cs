using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Model.DTO
{
    public class CreateEventDTO
    {
        public Event EventData { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public List<CreateTicketDTO> Tickets { get; set; }


    }



}
