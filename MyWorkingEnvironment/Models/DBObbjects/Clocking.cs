using System;
using System.Collections.Generic;

namespace MyWorkingEnvironment.Models.DBObbjects
{
    public partial class Clocking
    {
        public Guid IdClocking { get; set; }
        public Guid IdEmployee { get; set; }
        public string Type { get; set; } = null!;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
    }
}
