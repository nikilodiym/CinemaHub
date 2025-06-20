using System.Windows;
using CinemaWPF.ViewModels.Films;

namespace CinemaWPF.Views.Auth;

public partial class UserWindow : Window
{
    public UserWindow()
    {
        InitializeComponent();
        DataContext = new UserFilmsViewModel();
    }
}

