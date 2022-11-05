namespace MyWorkingEnvironment.Models
{
    public class TaskEmployeeModel
    {
        public Guid IdTask { get; set; }
        public string Title { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? Description { get; set; }
    }
}
