using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Model.DTO
{
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public int TicketID { get; set; }
        public int UserID { get; set; }
    }
    public class BookingDetailDTO
    {
        public string Status { get; set; }
        public List<OrderTicketDTO> Tickets { get; set; }
    }
    public class CreateBookingDTO
    {
        public int UserID { get; set; }
        public string UserToken { get; set; }
        public List<OrderTicketDTO> Tickets { get; set; }
        public string EventName { get; set; }

    }

    public class CancelBookingDTO
    {
        public int? BookingID { get; set; }
        public int? TicketID { get; set; }
        public string UserToken { get; set; }
        public int UserID { get; set; }
    }

    public class UpdateBookingDTO
    {
        public int BookingNumber { get; set; }
        public string Status { get; set; }
        public string UserToken { get; set; }
    }

}
