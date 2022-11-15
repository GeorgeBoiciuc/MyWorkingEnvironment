namespace MyWorkingEnvironment.Models
{
    public class TaskEmployeeModel
    {
        public Guid IdTaskEmployee { get; set; }
        public Guid? IdEmployee { get; set; }
        public string Title { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? Description { get; set; }
    }

    public enum PriorityType
    {
        High,
        Medium,
        Low
    }
}
