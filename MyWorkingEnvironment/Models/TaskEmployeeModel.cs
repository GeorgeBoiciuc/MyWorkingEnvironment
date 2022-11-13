using System.ComponentModel.DataAnnotations;

namespace MyWorkingEnvironment.Models
{
    public class TaskEmployeeModel
    {
        public Guid IdTask { get; set; }
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]

        public string Title { get; set; } = null!;
        public string Priority { get; set; } = null!;
        [StringLength(500, ErrorMessage = "Maximum 500 characters")]
        public string? Description { get; set; }
    }

    public enum PriorityType
    {
        High,
        Medium,
        Low
    }
}
