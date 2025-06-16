using System.IO;
using System.Text.Json;

namespace CinemaServer.CinemaSupabase;

public class Secrets
{
    public SupabaseConfig Supabase { get; set; }

    public static Secrets LoadFromFile(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Secrets>(json);
    }
}

public class SupabaseConfig
{
    public string _supabaseUrl { get; set; }
    public string _supabaseKey { get; set; }
}