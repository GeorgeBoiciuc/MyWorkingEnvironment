using System;
using System.Collections.Generic;

namespace MyWorkingEnvironment.Models.DBObjects
{
    public partial class TaskEmployee
    {
        public Guid IdTask { get; set; }
        public string Title { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? Description { get; set; }
    }
}
