using System.ComponentModel.DataAnnotations;

namespace MyWorkingEnvironment.Models
{
    public class EmployeeModel
    {
        public Guid IdEmployee { get; set; }
        public Guid? IdTask { get; set; }
        public Guid? IdReservation { get; set; }
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string FirstName { get; set; } = null!;
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string LastName { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime StartDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int VacationDays { get; set; }
    }
}
