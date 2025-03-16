namespace to_do_list.Models
{
    public class Task_model
    {
        public int Id { get; set; }

        public String Name { get; set; } = "";

        public string Description { get; set; } = "";

        public bool IsCompleted { get; set; }
    }
}
