using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Core.Models
{
    public class Movie : BaseModel
    {
        [PrimaryKey("movieid", false)]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("releasedate")]
        public DateTime ReleaseDate { get; set; }
    }
}

