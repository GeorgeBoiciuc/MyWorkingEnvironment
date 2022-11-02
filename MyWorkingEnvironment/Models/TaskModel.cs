namespace MyWorkingEnvironment.Models
{
    public class TaskModel
    {
        public Guid IdTask { get; set; }
        public string Title { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? Description { get; set; }
    }
}
