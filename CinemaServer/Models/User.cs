using Postgrest.Attributes;
using Postgrest.Models;
using System;

namespace CinemaWPF.Core.Models;

[Table("User")]
public class User : BaseModel
{
    [PrimaryKey("UserId")]
    public Guid UserId { get; set; }
    [Column("UserName")]
    public string UserName { get; set; } = string.Empty;
    [Column("UserPassword_hash")]
    public string UserPassword_hash { get; set; } = string.Empty;
    [Column("Email")]
    public string Email { get; set; } = string.Empty;
}
