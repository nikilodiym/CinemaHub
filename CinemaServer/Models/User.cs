using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CinemaServer.Models
{
    [Table("User")]
    public class User : BaseModel
    {
        [PrimaryKey("UserId")]
        public Guid UserId { get; set; }
        [Column("UserName")]
        public string UserName { get; set; } = string.Empty;
        [Column("UserPasswordHash")]
        public string UserPasswordHash { get; set; } = string.Empty;
        [Column("Email")]
        public string Email { get; set; } = string.Empty;
    }
}
