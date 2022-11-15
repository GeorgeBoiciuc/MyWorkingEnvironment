using System.ComponentModel.DataAnnotations;

namespace MyWorkingEnvironment.Models
{
    public class EmployeeModel
    {
        public Guid IdEmployee { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Title { get; set; }
        public string Email { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime? JoinDate { get; set; }
        public int? VacationDays { get; set; }
    }
}
