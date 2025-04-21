using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TaskTracker
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskItem>();
            DataContext = this; // Bind the ObservableCollection to the UI
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                MessageBox.Show("Please enter a title.");
                return;
            }

            TaskItem newTask = new TaskItem
            {
                Title = TitleBox.Text,
                Description = DescriptionBox.Text,
                DueDate = DueDatePicker.SelectedDate ?? DateTime.Now,
                Priority = (PriorityBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Non-Urgent"
            };

            Tasks.Add(newTask);

            // Clear inputs after adding
            TitleBox.Text = "";
            DescriptionBox.Text = "";
            DueDatePicker.SelectedDate = null;
            PriorityBox.SelectedIndex = -1;
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem is TaskItem selectedTask)
            {
                Tasks.Remove(selectedTask);
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Priority}) - Due {DueDate:MMM dd}";
        }
    }
}

