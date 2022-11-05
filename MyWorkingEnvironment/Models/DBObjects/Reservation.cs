using System;
using System.Collections.Generic;

namespace MyWorkingEnvironment.Models.DBObjects
{
    public partial class Reservation
    {
        public Reservation()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid IdReservation { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
