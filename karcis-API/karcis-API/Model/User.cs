using Binus.WS.Pattern.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[DatabaseName("Local")]
[Table("MsUser")]
public class User : BaseModel
{
    [Key]
    [Column("UserID")]
    public int UserID { get; set; }
    [Column("UserName")]
    public string UserName { get; set; }

    [Column("UserDOB")]
    public DateTime? UserDOB { get; set; }

    [Column("UserPhone")]
    public string UserPhone { get; set; }
    [Column("UserEmail")]
    public string UserEmail { get; set; }
    [Column("UserPassword")]
    public string UserPassword { get; set; }
    [Column("UserRole")]
    public bool UserRole { get; set; } = false;

    [Column("CreatedAt")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Column("UpdatedAt")]
    public DateTime? UpdateAt { get; set; }


}

