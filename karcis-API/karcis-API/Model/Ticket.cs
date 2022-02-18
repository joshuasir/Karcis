using Binus.WS.Pattern.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[DatabaseName("Local")]
[Table("MsTicket")]
public class Ticket : BaseModel
{
    [Key]
    [Column("TicketID")]
    public int TicketID { get; set; }
    [Column("EventID")]
    public int EventID { get; set; }
    [Column("TicketType")]
    public string TicketType { get; set; }
    [Column("TicketPrice")]
    public int TicketPrice { get; set; }

    [Column("TicketStatus")]
    public bool TicketStatus { get; set; } = true;
}