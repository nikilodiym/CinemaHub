using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Supabase;
using Core.Helpers;
using CinemaWPF.Models;

namespace CinemaWPF.Views.Auth;

public partial class RegisterWindowView : UserControl
{
    public RegisterWindowView()
    {
        InitializeComponent();
        PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
        ConfirmPasswordBox.PasswordChanged += ConfirmPasswordBox_PasswordChanged;
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var placeholder = (TextBlock) ((Grid)PasswordBox.Parent).Children[1];
        placeholder.Visibility = string.IsNullOrEmpty(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
    }

    private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var placeholder = (TextBlock) ((Grid)ConfirmPasswordBox.Parent).Children[1];
        placeholder.Visibility = string.IsNullOrEmpty(ConfirmPasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
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
        if (!IsValidEmail(username))
        {
            MessageBox.Show("Введіть коректний email!");
            return;
        }
        if (password != confirmPassword)
        {
            MessageBox.Show("Паролі не співпадають!");
            return;
        }
        try
        {
            // Реєстрація напряму у Supabase
            var supabase = new Supabase.Client(
                "https://nvtstozbbftyzpnjmnyz.supabase.co",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im52dHN0b3piYmZ0eXpwbmptbnl6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDc0NzM4NzcsImV4cCI6MjA2MzA0OTg3N30.etGp1-etVKGboYf8s00Nq4T5rM_sxjJxILGT_0zzUxo"
            );
            var hasher = new PasswordHasher();
            var passwordHash = hasher.HashPassword(password);
            var user = new User
            {
                username = username,
                userpassword_hash = passwordHash
            };
            var response = await supabase.From<User>().Insert(user);
            if (response != null && response.Models != null && response.Models.Count > 0)
            {
                MessageBox.Show("Реєстрація успішна! Тепер увійдіть.");
                var mainWindow = Window.GetWindow(this);
                if (mainWindow != null)
                {
                    mainWindow.Content = new LoginWindowView();
                }
            }
            else
            {
                MessageBox.Show("Помилка при збереженні користувача у Supabase.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка підключення: {ex.Message}");
        }
    }
}

