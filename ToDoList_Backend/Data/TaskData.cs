using System.Collections.Generic;
using System.Threading.Tasks;
using to_do_list.Models;

namespace to_do_list.Data
{
    public class TaskData
    {
        private readonly List<TaskModel> _tasks = new();

        public TaskData()
        {
            _tasks.AddRange(new[]
            {
            new TaskModel { Id = 1, Name = "Task 1", Description = "Opis 1", IsCompleted = false },
            new TaskModel { Id = 2, Name = "Task 2", Description = "Opis 2", IsCompleted = true },
            new TaskModel { Id = 3, Name = "Task 3", Description = "Opis 3", IsCompleted = false },
        });
        }
        public IReadOnlyList<TaskModel> GetTasks() => _tasks;

        public void AddTask(TaskModel task)
        {
            task.Id = _tasks.Max(t => t.Id) + 1;
            _tasks.Add(task);
        }
        public bool RemoveTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            return task != null && _tasks.Remove(task);
        }
        public void SwapTasks(int task1Id, int task2Id)
        {
            var index1 = _tasks.FindIndex(t => t.Id == task1Id);
            var index2 = _tasks.FindIndex(t => t.Id == task2Id);
            if (index1 >= 0 && index2 >= 0)
            {
                (_tasks[index1], _tasks[index2]) = (_tasks[index2], _tasks[index1]);
            }
        }
        public void SetCompleted(int task1Id)
        {
            var index1 = _tasks.FindIndex(t => t.Id == task1Id);

            _tasks[index1].IsCompleted = !_tasks[index1].IsCompleted;
        }

    }
}
