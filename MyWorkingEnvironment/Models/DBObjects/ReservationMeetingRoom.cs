using System;
using System.Collections.Generic;

namespace MyWorkingEnvironment.Models.DBObjects
{
    public partial class ReservationMeetingRoom
    {
        public Guid IdReservation { get; set; }
        public Guid IdMeetingRoom { get; set; }

        public virtual MeetingRoom IdMeetingRoomNavigation { get; set; } = null!;
        public virtual Reservation IdReservationNavigation { get; set; } = null!;
    }
}
