using System.Collections.ObjectModel;
using System.ComponentModel;
using to_do_list.Data;
using to_do_list.Models;

namespace to_do_list.TaskViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TaskModel> _tasks = new();
        public ObservableCollection<TaskModel> Tasks
        {
            get => _tasks;
            set { _tasks = value; OnPropertyChanged(nameof(Tasks)); }
        }

        private readonly TaskData _taskData;

        public TaskViewModel(TaskData taskData)
        {
            _taskData = taskData;
            RefreshTasks();
        }

        public void RefreshTasks()
        {
            Tasks = new ObservableCollection<TaskModel>(_taskData.GetTasks());
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } 
}
