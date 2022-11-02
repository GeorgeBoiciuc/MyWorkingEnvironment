using System;
using System.Collections.Generic;

namespace MyWorkingEnvironment.Models.DBObbjects
{
    public partial class Employee
    {
        public Employee()
        {
            Clockings = new HashSet<Clocking>();
        }

        public Guid IdEmployee { get; set; }
        public Guid IdTask { get; set; }
        public Guid IdReservation { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public int VacationDays { get; set; }

        public virtual Reservation IdReservationNavigation { get; set; } = null!;
        public virtual Task IdTaskNavigation { get; set; } = null!;
        public virtual ICollection<Clocking> Clockings { get; set; }
    }
}
