using Binus.WS.Pattern.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace karcis_API.Model
{
    [DatabaseName("Local")]
    [Table("TrBooking")]
    public class Booking : BaseModel
    {
        [Column("BookingID")]
        public int BookingNumber { get; set; }

        [Column("UserID")]
        public int UserID { get; set; }

        [Column("TicketID")]
        public int TicketID { get; set; }

        [Column("Qty")]
        public int Qty { get; set; } = 1;

        [Column("Status")]
        public string Status { get; set; } = "Pending";

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }

}