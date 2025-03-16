using System.Collections.ObjectModel;
using System.ComponentModel;
using to_do_list.Data;
using to_do_list.Models;

namespace to_do_list.TaskViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Task_model> _tasks;
        public ObservableCollection<Task_model> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
        private readonly Task_data _taskData;

        public TaskViewModel(Task_data taskData)
        {
            _taskData = taskData;
            _tasks = new ObservableCollection<Task_model>(_taskData.GetTasks());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
