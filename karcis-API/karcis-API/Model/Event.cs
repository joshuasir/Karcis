using Binus.WS.Pattern.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace karcis_API.Model
{
    [DatabaseName("Local")]
    [Table("MsEvent")]
    public class Event : BaseModel
    {
        [Key]
        [Column("EventID")]
        public int EventID { get; set; }
        [Column("EventName")]
        public string EventName { get; set; }
        [Column("EventStartDate")]
        public DateTime? EventStart { get; set; }
        [Column("EventEndDate")]
        public DateTime? EventEnd { get; set; }
        [Column("EventDescription")]
        public string EventDescription { get; set; }
        [Column("EventLocation")]
        public string EventLocation { get; set; }
        [Column("UpdatedAt")]
        public DateTime? UpdateAt { get; set; }
        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [Column("UpdatedBy")]
        public int? UpdatedBy { get; set; }
        [Column("CreatedBy")]
        public int? CreatedBy { get; set; }
    }
}