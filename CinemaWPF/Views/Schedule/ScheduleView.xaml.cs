using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CinemaWPF.ViewModels.Schedule; 

namespace CinemaWPF.Views.Schedule
{
    public partial class ScheduleView : UserControl
    {
        public ObservableCollection<ViewModels.Schedule.Schedule> Schedules { get; set; }

        public ScheduleView()
        {
            InitializeComponent();
            Schedules = new ObservableCollection<ViewModels.Schedule.Schedule>();
            ScheduleDataGrid.ItemsSource = Schedules;

            AddScheduleButton.Click += AddScheduleButton_Click;
        }

        private void AddScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            var newSchedule = new ViewModels.Schedule.Schedule
            {
                ScheduleId = Schedules.Count + 1,
                FilmTitle = "New Film",
                ScreeningTime = DateTime.Now.AddHours(2),
                Location = "Cinema Hall 1"
            };

            Schedules.Add(newSchedule);
            MessageBox.Show("Added!");
        }
    }
}