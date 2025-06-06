﻿using System.Collections.Generic;
using System.Threading.Tasks;
using to_do_list.Models;
using ToDoList_Backend.Models;

namespace to_do_list.Data
{
    public class TaskService
    {
        private readonly List<TaskModel> _tasks = new();
        

        public TaskService()
        {
            _tasks.AddRange(new[]
            {
            new TaskModel { Id = 0, Name = "Task 1", Description = "Opis 1", DueDate = DateTime.Parse("2025-03-25T14:00:00"), IsCompleted = false, IsHidden = false },
            new TaskModel { Id = 1, Name = "Task 2", Description = "Opis 2", DueDate = DateTime.Parse("2025-03-26T14:50:00"), IsCompleted = false, IsHidden = false },
            new TaskModel { Id = 2, Name = "Task 3", Description = "Opis 3", DueDate = DateTime.Parse("2025-04-25T14:21:37"), IsCompleted = false, IsHidden = false },
        });
        }
        public IReadOnlyList<TaskModel> GetTasks() 
        {
            CleanupCompletedTasks();
            return _tasks;
        }

        public void AddTask(TaskModel task)
        {
            task.Id = _tasks.Count();
            _tasks.Add(task);
        }
        public bool RemoveTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            return task != null && _tasks.Remove(task);
        }
        public void SwapTasks(int draggedId, int targetId)
        {
            var fromIndex = _tasks.FindIndex(t => t.Id == draggedId);
            var toIndex = _tasks.FindIndex(t => t.Id == targetId);

            if (fromIndex == -1 || toIndex == -1 || fromIndex == toIndex)
                return;

            var draggedTask = _tasks[fromIndex];
            _tasks.RemoveAt(fromIndex);

            _tasks.Insert(toIndex, draggedTask);
        }

        public void SetCompleted(int task1Id)
        {
            var index1 = _tasks.FindIndex(t => t.Id == task1Id);

            _tasks[index1].IsCompleted = !_tasks[index1].IsCompleted;
            _tasks[index1].CompletedAt = DateTime.UtcNow;
        }

        public void EditTask(TaskModel editedTask, int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
                throw new ArgumentException($"Task with ID {taskId} not found.");

            task.Name = editedTask.Name;
            task.Description = editedTask.Description;
            task.DueDate = editedTask.DueDate;
            task.IsCompleted = editedTask.IsCompleted;
        }

        public void SetHidden(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
                throw new ArgumentException($"Task with ID {taskId} not found.");

            task.IsHidden = !task.IsHidden;
        }
        public void CleanupCompletedTasks()
        {
            _tasks.RemoveAll(t =>
                t.IsCompleted &&
                t.CompletedAt.HasValue &&
                DateTime.UtcNow - t.CompletedAt.Value > TimeSpan.FromHours(24)
            );
        }

    }
}
