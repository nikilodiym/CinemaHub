using Supabase.Gotrue;

namespace CinemaServer.CinemaSupabase;

public static class SupabaseClient
{
    public class SupabaseService
    {
        public Supabase.Client supabaseClient;

        private static string _supabaseUrl = "https://nvtstozbbftyzpnjmnyz.supabase.co";
        private static string _supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im52dHN0b3piYmZ0eXpwbmptbnl6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDc0NzM4NzcsImV4cCI6MjA2MzA0OTg3N30.etGp1-etVKGboYf8s00Nq4T5rM_sxjJxILGT_0zzUxo";

        public bool IsLoggedIn { get; private set; }
        public User? SupabaseUser { get; private set; }

        public SupabaseService()
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            supabaseClient = new Supabase.Client(_supabaseUrl, _supabaseKey, options);
        }
    }
}