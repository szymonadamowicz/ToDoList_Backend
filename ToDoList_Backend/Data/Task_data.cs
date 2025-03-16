using to_do_list.Models;

namespace to_do_list.Data
{
    public class Task_data
    {
        List<Task_model> model = new List<Task_model>();

        public Task_data()
        {
            model.Add(new Task_model
            {
                Id = 1,
                Name = "Task 1",
                Description = "Opis pierwszego zadania",
                IsCompleted = false
            });

            model.Add(new Task_model
            {
                Id = 2,
                Name = "Task 2",
                Description = "Opis drugiego zadania",
                IsCompleted = true
            });

            model.Add(new Task_model
            {
                Id = 3,
                Name = "Task 3",
                Description = "Opis trzeciego zadania",
                IsCompleted = false
            });
        }

        public List<Task_model> GetTasks()
        {
            return model;
        }
    }
}
