namespace to_do_list.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsHidden { get; set; }
        public DateTime? CompletedAt { get; set; }

    }

}
