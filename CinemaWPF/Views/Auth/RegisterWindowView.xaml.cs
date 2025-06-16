using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Supabase;

namespace CinemaWPF.Views.Auth;

public partial class RegisterWindowView : UserControl
{
    private static readonly HttpClient _httpClient = new HttpClient();
    public RegisterWindowView()
    {
        InitializeComponent();
    }
    private async void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameTextBox.Text;
        var password = PasswordBox.Password;
        var confirmPassword = ConfirmPasswordBox.Password;
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Всі поля обов'язкові!");
            return;
        }
        if (password != confirmPassword)
        {
            MessageBox.Show("Паролі не співпадають!");
            return;
        }
        try
        {
            var supabase = new Supabase.Client(
                "https://your-project.supabase.co", 
                "public-anon-key" 
            );
            var session = await supabase.Auth.SignUp(username, password);
            if (session != null && session.User != null)
            {
                var jwt = session.AccessToken;
                MessageBox.Show("Реєстрація успішна! Тепер увійдіть.");
                // Переключення на LoginView
                var mainWindow = Window.GetWindow(this);
                if (mainWindow != null)
                {
                    mainWindow.Content = new LoginWindowView();
                }
            }
            else
            {
                MessageBox.Show("Невідома помилка реєстрації.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка підключення: {ex.Message}");
        }
    }
}

