using Supabase.Gotrue;

namespace CinemaServer.CinemaSupabase;

public static class SupabaseClient
{
    public class SupabaseService
    {
        public Supabase.Client supabaseClient;

        public bool IsLoggedIn { get; private set; }
        public User? SupabaseUser { get; private set; }

        public SupabaseService()
        {
            // Завантаження секретів
            var secrets = Secrets.LoadFromFile("CinemaServer/CinemaSupabase/secrets.json");

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            // Використання зчитаних значень
            supabaseClient = new Supabase.Client(secrets.Supabase._supabaseUrl, secrets.Supabase._supabaseKey, options);
        }
    }
}