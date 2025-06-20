using System.Windows;
using System.Windows.Controls;
using Core.Helpers;

namespace CinemaWPF.Views.Auth;

public partial class LoginWindowView : UserControl
{
    public LoginWindowView()
    {
        InitializeComponent();
    }
    
    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameTextBox.Text;
        var password = PasswordBox.Password;
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Всі поля обов'язкові!");
            return;
        }
        try
        {
            // Авторизація напряму через Supabase
            var supabase = new Supabase.Client(
                "https://nvtstozbbftyzpnjmnyz.supabase.co",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im52dHN0b3piYmZ0eXpwbmptbnl6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDc0NzM4NzcsImV4cCI6MjA2MzA0OTg3N30.etGp1-etVKGboYf8s00Nq4T5rM_sxjJxILGT_0zzUxo"
            );
            var users = await supabase.From<CinemaWPF.Models.User>()
                .Where(x => x.username == username)
                .Get();
            if (users.Models.Count == 0)
            {
                MessageBox.Show("Користувача не знайдено або невірний логін.");
                return;
            }
            var user = users.Models[0];
            var hasher = new PasswordHasher();
            if (!hasher.VerifyPassword(password, user.userpassword_hash))
            {
                MessageBox.Show("Невірний пароль.");
                return;
            }
            MessageBox.Show("Вхід успішний!");
            // TODO: Перейти на головне вікно або іншу логіку після входу
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка підключення: {ex.Message}");
        }
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var registerWindow = new RegisterWindowView();
            
        var currentWindow = Window.GetWindow(this);
        if (currentWindow != null)
        {
            currentWindow.Content = registerWindow;
        }
    }
}
