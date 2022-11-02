using System;
using System.Collections.Generic;

namespace MyWorkingEnvironment.Models.DBObbjects
{
    public partial class Task
    {
        public Task()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid IdTask { get; set; }
        public string Title { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
