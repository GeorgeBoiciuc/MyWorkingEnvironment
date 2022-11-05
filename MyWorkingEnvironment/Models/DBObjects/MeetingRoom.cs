using System;
using System.Collections.Generic;

namespace MyWorkingEnvironment.Models.DBObjects
{
    public partial class MeetingRoom
    {
        public Guid IdMeetingRoom { get; set; }
        public string Name { get; set; } = null!;
    }
}
