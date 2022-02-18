using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API.Output
{
    public class BookingOutput
    {
        public int BookingNumber { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }


        public int TotalPrice { get; set; }

        public int Qty { get; set; }

        public string Status { get; set; }
    }
    public class SpecificBookingOutput
    {
        public int BookingNumber { get; set; }

        public int UserID { get; set; }

        public List<Ticket> BookingTickets { get; set; }

        public string UserName { get; set; }


        public int TotalPrice { get; set; }

        public int Qty { get; set; }

        public string Status { get; set; }
    }
}
