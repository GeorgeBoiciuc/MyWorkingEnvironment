namespace MyWorkingEnvironment.Models
{
    public class EmployeeModel
    {
        public Guid IdEmployee { get; set; }
        public Guid IdTask { get; set; }
        public Guid IdReservation { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public int VacationDays { get; set; }
    }
}
