using System.Windows;
using System.Windows.Controls;

namespace CinemaWPF.Views.Schedule;

public partial class ScreeningDetailsView : UserControl
{
    public ScreeningDetailsView()
    {
        InitializeComponent();
        SaveScreeningButton.Click += SaveScreeningButton_Click;
    }

    private void SaveScreeningButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Screening details saved!");
        // Add logic for saving screening details here
    }
}