using Supabase.Postgrest.Models;

namespace CinemaWPF.Models
{
    public class User : BaseModel
    {
        public string? username { get; set; }
        public string? userpassword_hash { get; set; }
    }
}
